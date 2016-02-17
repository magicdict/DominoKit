using DevKit.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DevKit.MVCTool
{
    /// <summary>
    /// 工程名称
    /// </summary>
    public class ProjectInfo
    {
        /// <summary>
        /// 工程名
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// NET-命名空间
        /// Java-Package
        /// </summary>
        public string NameSpace = string.Empty;
        /// <summary>
        /// 开发语言
        /// </summary>
        public EnumAndConst.Language DevLanguage = EnumAndConst.Language.CSharp;
        /// <summary>
        /// 开发框架
        /// </summary>
        public string DevFramework = CSharp.strCSharpMVC5;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public EnumAndConst.DataBase DataBaseType = EnumAndConst.DataBase.MySql;
        /// <summary>
        /// 数据库Schema
        /// </summary>
        public string DataBaseSchema = "";
        /// <summary>
        /// 工程路径
        /// </summary>
        public string PrjToolPath = string.Empty;
        /// <summary>
        /// 真实工程路径
        /// </summary>
        public string PrjRootPath = string.Empty;

        /// <summary>
        /// 路径
        /// </summary>
        public struct PathSet
        {
            /// <summary>
            /// 根目录
            /// </summary>
            public string RootPath
            {
                get;
                set;
            }
            /// <summary>
            /// 模型的文档
            /// </summary>
            public string DocPath
            {
                get
                {
                    return RootPath + "\\Document";
                }
            }
            /// <summary>
            /// 模型的代码
            /// </summary>
            public string SourcePath
            {
                get
                {
                    return RootPath + "\\SourceCode";
                }
            }

            public void CreatePath()
            {
                if (!Directory.Exists(RootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }
                if (!Directory.Exists(DocPath))
                {
                    Directory.CreateDirectory(DocPath);
                }
                if (!Directory.Exists(SourcePath))
                {
                    Directory.CreateDirectory(SourcePath);
                }
            }
        }
        /// <summary>
        /// Model目录
        /// </summary>
        public PathSet EntityPath = new PathSet();
        /// <summary>
        /// Enum目录
        /// </summary>
        public PathSet EnumPath = new PathSet();
        /// <summary>
        /// Master目录
        /// </summary>
        public PathSet MasterPath = new PathSet();
        /// <summary>
        /// 枚举相关类
        /// </summary>
        public string EnumExtendSourceCodePath
        {
            get
            {
                return EnumPath.RootPath + "\\ExtendSourceCode";
            }
        }
        /// <summary>
        /// 基本类
        /// </summary>
        public string ClassSourcePath
        {
            get
            {
                return PrjToolPath + "\\Class";
            }
        }
        /// <summary>
        /// 视图路径
        /// </summary>
        public string ViewerPath
        {
            get
            {
                return PrjToolPath + "\\Viewer";
            }
        }
        /// <summary>
        /// 新建一个模型文件
        /// </summary>
        /// <param name="ModelName"></param>
        public void NewModel(string ModelName)
        {
            PathSet _PathSet;
            if (ModelName.StartsWith("M_"))
            {
                _PathSet = MasterPath;
            }
            else
            {
                _PathSet = EntityPath;
            }
            if (File.Exists(_PathSet.DocPath + "\\" + ModelName + ".xlsx"))
            {
                if (Interaction.MsgBox("发现同名模型，是否删除", MsgBoxStyle.OkCancel, "询问") == Microsoft.VisualBasic.MsgBoxResult.Cancel)
                {
                    return;
                }
                File.Delete(_PathSet.DocPath + "\\" + ModelName + ".xlsx");
            }
            File.Copy(Application.StartupPath + "\\Template\\ModelTemplate.xlsx", _PathSet.DocPath + "\\" + ModelName + ".xlsx");
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(_PathSet.DocPath + "\\" + ModelName + ".xlsx");
            workbook.Sheets(1).Name = ModelName;
            workbook.Sheets(1).Cells(2, 3).Value = ModelName;
            workbook.Sheets(1).Cells(2, 6).Value = ModelName;
            if (ModelName.StartsWith("M_"))
            {
                workbook.Sheets(1).Cells(2, 9).Value = "MasterTable";
            }
        }
        /// <summary>
        /// 新建一个枚举文件
        /// </summary>
        /// <param name="EnumlName"></param>
        public void NewEnum(string EnumlName)
        {
            if (File.Exists(EnumPath.DocPath + "\\" + EnumlName + ".xlsx"))
            {
                if (Interaction.MsgBox("发现同名枚举，是否删除", MsgBoxStyle.OkCancel, "询问") == Microsoft.VisualBasic.MsgBoxResult.Cancel)
                {
                    return;
                }
                File.Delete(EnumPath.DocPath + "\\" + EnumlName + ".xlsx");
            }
            File.Copy(Application.StartupPath + "\\Template\\EnumTemplate.xlsx", EnumPath.DocPath + "\\" + EnumlName + ".xlsx");
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(EnumPath.DocPath + "\\" + EnumlName + ".xlsx");
            workbook.Sheets(1).Name = EnumlName;
            workbook.Sheets(1).Cells(3, 4).Value = EnumlName;
        }
        /// <summary>
        /// 初始化目录结构
        /// </summary>
        public void InitFolder()
        {
            //目录新建
            if (!Directory.Exists(PrjToolPath))
            {
                Directory.CreateDirectory(PrjToolPath);
            }
            EntityPath.RootPath = PrjToolPath + "\\Entity";
            EnumPath.RootPath = PrjToolPath + "\\Enum";
            MasterPath.RootPath = PrjToolPath + "\\Master";
            EntityPath.CreatePath();
            EnumPath.CreatePath();
            MasterPath.CreatePath();
            //视图
            if (!Directory.Exists(ViewerPath))
            {
                Directory.CreateDirectory(ViewerPath);
            }
            //保存
            Utility.SaveObjAsXml<ProjectInfo>(PrjToolPath + "\\ProjectInfo.xml", this);
            //枚举扩展
            if (!Directory.Exists(EnumExtendSourceCodePath))
            {
                Directory.CreateDirectory(EnumExtendSourceCodePath);
            }
            Utility.getResource(EnumExtendSourceCodePath + "\\EnumExtention.cs", "EnumExtention.cs");
            Utility.getResource(EnumExtendSourceCodePath + "\\EnumFlagsTemplate.cs", "EnumFlagsTemplate.cs");
            Utility.getResource(EnumExtendSourceCodePath + "\\EnumTemplate.cs", "EnumTemplate.cs");
            Utility.getResource(EnumExtendSourceCodePath + "\\EnumDisplayNameAttribute.cs", "EnumDisplayNameAttribute.cs");
            //基本类
            if (!Directory.Exists(ClassSourcePath))
            {
                Directory.CreateDirectory(ClassSourcePath);
            }

            Utility.getResource(ClassSourcePath + "\\EntityBase.cs", "EntityBase.cs");
            Utility.getResource(ClassSourcePath + "\\OwnerTable.cs", "OwnerTable.cs");
            Utility.getResource(ClassSourcePath + "\\MasterTable.cs", "MasterTable.cs");
        }
        /// <summary>
        /// 将工程结构用树型控件表示
        /// </summary>
        /// <param name="trvProj"></param>
        public void SetProjectTree(TreeView trvProj)
        {
            trvProj.Nodes.Clear();
            TreeNode root = new TreeNode(Name + "[" + NameSpace + "]");
            root.Nodes.Add(CreateNode("数据模型", EntityPath));
            root.Nodes.Add(CreateNode("枚举", EnumPath));
            root.Nodes.Add(CreateNode("辅助表", MasterPath));
            root.Nodes.Add(CreateNode("视图", ViewerPath));
            trvProj.Nodes.Add(root);
            trvProj.ExpandAll();
        }
        /// <summary>
        /// 生成节点
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        private TreeNode CreateNode(string strTitle, string Path)
        {
            TreeNode mNode = new TreeNode(strTitle);
            foreach (var filename in Directory.GetFiles(Path))
            {
                mNode.Nodes.Add(new TreeNode(new FileInfo(filename).Name) { Tag = "SourceCode:" + filename });
            }
            return mNode;
        }
        /// <summary>
        /// 生成节点
        /// </summary>
        /// <param name="RootTest"></param>
        /// <param name="RootSet"></param>
        /// <returns></returns>
        private TreeNode CreateNode(string RootTest, PathSet RootSet)
        {
            //数据模型
            TreeNode ModelCollection = new TreeNode(RootTest);
            TreeNode ExcelModel = new TreeNode("设计书");
            foreach (var filename in Directory.GetFiles(RootSet.DocPath))
            {
                var f = new FileInfo(filename).Name;
                //Office临时备份文件开头为"~$"
                if (!f.StartsWith("~$")) ExcelModel.Nodes.Add(new TreeNode(f) { Tag = "Excel:" + filename });
            }
            TreeNode SourceModel = new TreeNode("代码");
            foreach (var filename in Directory.GetFiles(RootSet.SourcePath))
            {
                SourceModel.Nodes.Add(new TreeNode(new FileInfo(filename).Name) { Tag = "SourceCode:" + filename });
            }
            ModelCollection.Nodes.Add(SourceModel);
            ModelCollection.Nodes.Add(ExcelModel);
            return ModelCollection;
        }

        /// <summary>
        /// 生成全部模型
        /// </summary>
        public void GenerateAllModelCode(bool SingleFileMode, PathSet _PathSet)
        {
            foreach (var filename in Directory.GetFiles(_PathSet.DocPath))
            {
                List<ModelInfo> models = ModelUtility.ReadModelFromExcel(SingleFileMode,filename);
                //model.NameSpace = NameSpace;
                if (DevLanguage == EnumAndConst.Language.CSharp)
                {
                    foreach (ModelInfo model in models)
                    {
                        ModelGenerator.GenerateCSharp(_PathSet.SourcePath + "\\" + model.ModelName + ".cs", model);
                        ViewerGenerator.GenerateCSharp(ViewerPath + "\\" + model.ModelName + ".cshtml", model, model.Items);
                    }
                }
            }
            GC.Collect();
        }
        /// <summary>
        /// 生成所有枚举
        /// </summary>
        public void GenerateAllEnumCode()
        {
            foreach (var filename in Directory.GetFiles(EnumPath.DocPath))
            {
                //model.NameSpace = NameSpace;
                if (DevLanguage == EnumAndConst.Language.CSharp)
                {
                    FileInfo f = new FileInfo(filename);
                    EnumGenerator.Generate(filename, EnumPath.SourcePath + "\\" + f.Name.Replace(".xlsx", ".cs"));
                }
            }
            GC.Collect();
        }
        /// <summary>
        /// 导出到MVC
        /// </summary>
        public void CopyToProJ()
        {
            //枚举的复制
            foreach (var filename in Directory.GetFiles(EnumPath.SourcePath))
            {
                FileInfo f = new FileInfo(filename);
                var targetfilename = PrjRootPath + "\\Entity\\Enum\\" + f.Name;
                File.Copy(filename, targetfilename, true);
            }
            //辅助表格的复制
            foreach (var filename in Directory.GetFiles(MasterPath.SourcePath))
            {
                FileInfo f = new FileInfo(filename);
                var targetfilename = PrjRootPath + "\\Entity\\Master\\" + f.Name;
                File.Copy(filename, targetfilename, true);
            }
            //数据模型的复制
            foreach (var filename in Directory.GetFiles(EntityPath.SourcePath))
            {
                FileInfo f = new FileInfo(filename);
                var targetfilename = PrjRootPath + "\\Entity\\" + f.Name;
                File.Copy(filename, targetfilename, true);
            }
        }
    }
}
