using DevKit.Common;
using DevKit.MVCTool;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DevKit
{
    public partial class ModelCodeGenerator : Form
    {
        /// <summary>
        /// 当前工程
        /// </summary>
        public static ProjectInfo CurrentProject = null;

        public ModelCodeGenerator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDocumentPath_Click(object sender, EventArgs e)
        {
            txtDocumentPath.Text = Utility.PickFile(Utility.FileDialogMode.Open, Utility.XlsxFilter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPageSourcePath_Click(object sender, EventArgs e)
        {
            if (radCSharpMVC5.Checked)
            {
                txtViewSourcePath.Text = Utility.PickFile(Utility.FileDialogMode.Save, Utility.CSHTMLFilter);
            }
        }
        /// <summary>
        /// Sql Path Pick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSqlPath_Click(object sender, EventArgs e)
        {
            txtSqlPath.Text = Utility.PickFile(Utility.FileDialogMode.Save, Utility.SqlFilter);
        }
        /// <summary>
        /// Source Code Pick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            if (radCSharpMVC5.Checked)
            {
                txtModelSourcePath.Text = Utility.PickFile(Utility.FileDialogMode.Save, Utility.CSFilter);
            }
            if (radJavaSpring.Checked || radJavaJFinal.Checked)
            {
                txtModelSourcePath.Text = Utility.PickFile(Utility.FileDialogMode.Save, Utility.JavaFilter);
            }
            if (radJavaStruts2.Checked)
            {
                txtModelSourcePath.Text = Utility.PickFile(Utility.FileDialogMode.Save, Utility.XmlFilter);
            }
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGernerateCode_Click(object sender, EventArgs e)
        {
            bool singleFileMode = chkSingleFileMode.Checked;
            List<ModelInfo> models = ModelUtility.ReadModelFromExcel(singleFileMode, txtDocumentPath.Text);
            FileInfo f = new FileInfo(txtDocumentPath.Text);
            if (string.IsNullOrEmpty(txtModelSourcePath.Text))
            {
                string extendsion = "_Model.cs";
                if (radJavaSpring.Checked || radJavaStruts2.Checked || radJavaJFinal.Checked) {
                    extendsion = ".java";
                }
                if (!singleFileMode)
                {
                    //如果是单文件模式
                    var model = models[0];
                    if (model.ModelName.StartsWith(EnumAndConst.MasterPrefix))
                    {
                        txtModelSourcePath.Text = CurrentProject.MasterPath.SourcePath + "\\" + f.Name.Replace(".xlsx", extendsion);
                    }
                    else
                    {
                        txtModelSourcePath.Text = CurrentProject.EntityPath.SourcePath + "\\" + f.Name.Replace(".xlsx", extendsion);
                    }
                }
            }
            if (string.IsNullOrEmpty(txtViewSourcePath.Text))
            {
                string extendsion = ".cshtml";
                if (radJavaSpring.Checked || radJavaStruts2.Checked)
                {
                    extendsion = ".jsp";
                }
                if (!singleFileMode) txtViewSourcePath.Text = CurrentProject.ViewerPath + "\\" + f.Name.Replace(".xlsx", extendsion);
            }
            //MVC5
            if (radCSharpMVC5.Checked)
            {
                if (!singleFileMode)
                {
                    var model = models[0];
                    if (chkCreateModel.Checked)
                    {
                        ModelGenerator.GenerateCSharp(txtModelSourcePath.Text, model,chkWithAttr.Checked);
                    }
                    if (chkCreateView.Checked)
                    {
                        ViewerGenerator.GenerateCSharp(txtViewSourcePath.Text, model, model.Items);
                    }
                }
                else {
                    //单文件模式
                    foreach (var model in models)
                    {
                        var sourcefilename = CurrentProject.EntityPath.SourcePath + "\\" + model.ModelName + "_Model.cs";
                        ModelGenerator.GenerateCSharp(sourcefilename, model, chkWithAttr.Checked);
                    }
                    if (chkSingleFileModeWithEnum.Checked)
                    {
                        //单文档模式带枚举
                        dynamic excelObj = Interaction.CreateObject("Excel.Application");
                        excelObj.Visible = true;
                        dynamic workbook;
                        workbook = excelObj.Workbooks.Open(txtDocumentPath.Text);
                        for (int i = 0; i < workbook.Sheets.Count; i++) {
                            dynamic ExcelSheet = workbook.Sheets(i + 1);
                            var SourceCodefilename = CurrentProject.EntityPath.SourcePath + "\\" + workbook.Sheets(i+1).name + ".cs"; ;
                            EnumGenerator.GenerateEnum(ExcelSheet, SourceCodefilename);
                        }
                        workbook.Close();
                        excelObj.Quit();
                        excelObj = null;
                    }
                }
            }
            //Spring
            if (radJavaSpring.Checked)
            {
                if (!singleFileMode)
                {
                    var model = models[0];
                    ModelGenerator.GenerateJavaSpring(txtModelSourcePath.Text, model, chkHibernateORM.Checked);
                }
                else
                {
                    MessageBox.Show("该功能的单文件模式未完成");
                }

            }
            if (radJavaJFinal.Checked)
            {
                if (!singleFileMode)
                {
                    var model = models[0];
                    ModelGenerator.GenerateJavaJFinal(txtModelSourcePath.Text, model);
                }
                else
                {
                    //单文件模式
                    foreach (var model in models)
                    {
                        var sourcefilename = CurrentProject.EntityPath.SourcePath + "\\" + model.ModelName + ".java";
                        ModelGenerator.GenerateJavaJFinal(sourcefilename, model);
                    }
                }

            }
            //建表Sql文
            if (chkCreateDDL.Checked)
            {
                if (!singleFileMode)
                {
                    if (string.IsNullOrEmpty(txtSqlPath.Text))
                    {
                        txtSqlPath.Text = CurrentProject.EntityPath.SourcePath + "\\" + f.Name.Replace(".xlsx", ".sql");
                    }
                    var model = models[0];
                    DDLGenerator.MySql(model, txtSqlPath.Text, txtSchema.Text);
                }
                else
                {
                    //单文件模式
                    foreach (var model in models)
                    {
                        var sourcefilename = CurrentProject.EntityPath.SourcePath + "\\" + model.ModelName + ".sql";
                        DDLGenerator.MySql(model, sourcefilename, txtSchema.Text);
                    }
                }

            }
            GC.Collect();
            MessageBox.Show("代码生成完毕！");
        }
        /// <summary>
        /// Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelCodeGenerator_Load(object sender, EventArgs e)
        {
            txtSchema.Text = CurrentProject.DataBaseSchema;
            if (CurrentProject != null) {
                //Load Project Configuration
                switch (CurrentProject.DevFramework) {
                    case Java.strJavaJFinal:
                        radJavaJFinal.Checked = true;
                        break;
                    case Java.strJavaSpring:
                        radJavaSpring.Checked = true;
                        break;
                    case Java.strJavaStruts2:
                        radJavaStruts2.Checked = true;
                        break;
                    case CSharp.strCSharpMVC5:
                        radCSharpMVC5.Checked = true;
                        break;
                }

                switch (CurrentProject.DataBaseType) {
                    case EnumAndConst.DataBase.MongoDB:
                        radMongoDB.Checked = true;
                        break;
                    case EnumAndConst.DataBase.MSSql:
                        radMsSql.Checked = true;
                        break;
                    case EnumAndConst.DataBase.MySql:
                        radMySql.Checked = true;
                        break;
                    case EnumAndConst.DataBase.Oracle:
                        radOracle.Checked = true;
                        break;
                }
            }
        }
    }
}
