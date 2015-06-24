using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;

namespace DevKit.MVCTool
{
    /// <summary>
    /// Model Utility
    /// </summary>
    public static class ModelUtility
    {
        /// <summary>
        /// ExcelSheet 结构
        /// </summary>
        private enum ModelSheetStruct
        {
            //Domain
            Flag = 2,
            DomainName,
            Meaning,
            InputRule,
            //Developer
            VarName,
            MetaType,
            EnumOrMasterType,
            CatalogType,
            IsList,
            DisplayName,
            //数据库
            KeyField,
            Length,
            DefaultValue,
            //必须项目
            IsRequired,
            RequiredMessage,
            //范围
            RangeMin,
            RangeMax,
            RangeMessage,
            //字符串长度
            MinLength,
            MaxLength,
            LengthMessage,
            //Patten
            RegularExpress,
            RegularMessage,
            //格式
            DataType,
            DisplayFormat,
            //版本控制
            Comment,
            UpdateUser,
            UddateDate
        }
        /// <summary>
        /// 首行位置
        /// </summary>
        private static int firstRow = 8;
        /// <summary>
        /// 从Excel读取Model
        /// </summary>
        /// <returns></returns>
        public static ModelInfo ReadModelFromExcel(string ExcelFilename = "")
        {
            if (String.IsNullOrEmpty(ExcelFilename))
            {
                ExcelFilename = Common.Utility.PickFile(Common.Utility.FileDialogMode.Open, Common.Utility.XlsxFilter);
            }
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(ExcelFilename);
            ModelInfo model = ModelUtility.ReadModelFromExcelSheet(workbook.Sheets(1));
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
            if (model.SuperClass == "MasterTable")
            {
                FileInfo f = new FileInfo(ExcelFilename);
                if (!f.Name.StartsWith("M_"))
                {
                    var msg = "MasterTable没有以\"M_\"作为模型类型名字的开始字母，是否要重命名文件?" + System.Environment.NewLine +
                             "[" + f.Name + "] -> [" + "M_" + f.Name + "]";
                    if (Microsoft.VisualBasic.Interaction.MsgBox(msg, MsgBoxStyle.OkCancel) == MsgBoxResult.Ok)
                    {
                        var targetfilename = ExcelFilename.Replace(f.Name, "M_" + f.Name);
                        File.Move(ExcelFilename, targetfilename);
                    }
                }
            }
            return model;
        }
        /// <summary>
        /// 从ExcelSheet中读取单个Model信息
        /// </summary>
        /// <param name="ExcelSheet"></param>
        /// <returns></returns>
        public static ModelInfo ReadModelFromExcelSheet(dynamic ExcelSheet)
        {
            ModelInfo model = new ModelInfo();
            model.ModelName = ExcelSheet.Cells(2, 3).Text;
            model.NameSpace = ExcelSheet.Cells(3, 3).Text;
            model.CollectionName = ExcelSheet.Cells(2, 6).Text;
            model.Prefix = ExcelSheet.Cells(3, 6).Text;
            model.SuperClass = ExcelSheet.Cells(2, 9).Text;
            model.Description = ExcelSheet.Cells(3, 9).Text;

            if (model.SuperClass == "MasterTable")
            {
                var IsNeedSave = false;
                if (!model.ModelName.StartsWith("M_"))
                {
                    model.ModelName = "M_" + model.ModelName;
                    ExcelSheet.Cells(2, 3).Value = model.ModelName;
                    IsNeedSave = true;
                }
                if (!model.CollectionName.StartsWith("M_"))
                {
                    model.CollectionName = "M_" + model.CollectionName;
                    ExcelSheet.Cells(2, 6).Value = model.CollectionName;
                    IsNeedSave = true;
                }
                if (ExcelSheet.Name != model.ModelName)
                {
                    ExcelSheet.Name = model.ModelName;
                    IsNeedSave = true;
                }
                if (IsNeedSave) ExcelSheet.Parent.Save();
            }

            int seekrow = firstRow;
            while (!String.IsNullOrEmpty(ExcelSheet.Cells(seekrow, ModelSheetStruct.DomainName).Text))
            {
                ModelItem item = new ModelItem();
                item.Flag = ExcelSheet.Cells(seekrow, ModelSheetStruct.Flag).Text;
                item.DomainName = ExcelSheet.Cells(seekrow, ModelSheetStruct.DomainName).Text;
                //基本校验
                item.VarName = ExcelSheet.Cells(seekrow, ModelSheetStruct.VarName).Text;
                item.MetaType = ExcelSheet.Cells(seekrow, ModelSheetStruct.MetaType).Text;
                item.EnumOrMasterType = ExcelSheet.Cells(seekrow, ModelSheetStruct.EnumOrMasterType).Text;
                item.CatalogType = ExcelSheet.Cells(seekrow, ModelSheetStruct.CatalogType).Text;
                item.IsList = !string.IsNullOrEmpty(ExcelSheet.Cells(seekrow, ModelSheetStruct.IsList).Text);
                item.DisplayName = ExcelSheet.Cells(seekrow, ModelSheetStruct.DisplayName).Text;
                //数据库
                item.KeyField = Common.Utility.GetExcelBooleanValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.KeyField));
                item.Length = Common.Utility.GetExcelIntValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.Length));
                item.DefaultValue = ExcelSheet.Cells(seekrow, ModelSheetStruct.DefaultValue).Text;
                //必须校验
                item.Required = Common.Utility.GetExcelBooleanValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.IsRequired));
                item.RequiredMessage = ExcelSheet.Cells(seekrow, ModelSheetStruct.RequiredMessage).Text;
                //范围校验
                item.RangeMin = Common.Utility.GetExcelIntValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.RangeMin));
                item.RangeMax = Common.Utility.GetExcelIntValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.RangeMax));
                item.RangeMessage = ExcelSheet.Cells(seekrow, ModelSheetStruct.RangeMessage).Text;
                //字符串长度
                item.MinLength = Common.Utility.GetExcelIntValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.MinLength));
                item.MaxLength = Common.Utility.GetExcelIntValue(ExcelSheet.Cells(seekrow, ModelSheetStruct.MaxLength));
                item.LengthMessage = ExcelSheet.Cells(seekrow, ModelSheetStruct.LengthMessage).Text;
                //正则表达式
                item.RegularExpress = ExcelSheet.Cells(seekrow, ModelSheetStruct.RegularExpress).Text;
                item.RegularMessage = ExcelSheet.Cells(seekrow, ModelSheetStruct.RegularMessage).Text;
                //格式
                item.DataType = ExcelSheet.Cells(seekrow, ModelSheetStruct.DataType).Text;
                item.DisplayFormat = ExcelSheet.Cells(seekrow, ModelSheetStruct.DisplayFormat).Text;
                model.Items.Add(item);

                seekrow++;
            }
            return model;
        }
    }
    /// <summary>
    /// 模型信息
    /// </summary>
    [Serializable]
    public class ModelInfo
    {
        /// <summary>
        /// 工程 Package名称
        /// </summary>
        public string NameSpace { set; get; }
        /// <summary>
        /// 数据模型名称
        /// </summary>
        public string ModelName { set; get; }
        /// <summary>
        /// 数据表名称
        /// </summary>
        public string CollectionName { set; get; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { set; get; }
        /// <summary>
        /// 基类
        /// </summary>
        public string SuperClass { set; get; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        /// 模型项目
        /// </summary>
        public List<ModelItem> Items = new List<ModelItem>();
    }
    /// <summary>
    /// 数据项目
    /// </summary>
    [Serializable]
    public class ModelItem
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Flag;
        /// <summary>
        /// 领域名
        /// </summary>
        public string DomainName;
        /// <summary>
        /// 变量名称
        /// </summary>
        public string VarName;
        /// <summary>
        /// 数据类型
        /// </summary>
        public string MetaType;
        /// <summary>
        /// 枚举/MasterTable类型
        /// </summary>
        public string EnumOrMasterType;
        /// <summary>
        /// 目录类型
        /// </summary>
        public string CatalogType;
        /// <summary>
        /// 是否为列表
        /// </summary>
        public bool IsList;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// 关键字项目
        /// </summary>
        public bool KeyField;
        /// <summary>
        /// 长度
        /// </summary>
        public int Length;
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue;
        /// <summary>
        /// 必须项目
        /// </summary>
        public bool Required;
        /// <summary>
        /// 必须项目错误信息
        /// </summary>
        public string RequiredMessage;
        /// <summary>
        /// 最小值
        /// </summary>
        public int RangeMin;
        /// <summary>
        /// 最大值
        /// </summary>
        public int RangeMax;
        /// <summary>
        /// 范围错误
        /// </summary>
        public string RangeMessage;
        /// <summary>
        /// 最小文字列长度
        /// </summary>
        public int MinLength;
        /// <summary>
        /// 最大文字列长度
        /// </summary>
        public int MaxLength;
        /// <summary>
        /// 文字列长度错误信息
        /// </summary>
        public string LengthMessage;
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string RegularExpress;
        /// <summary>
        /// 正则表达式错误信息
        /// </summary>
        public string RegularMessage;
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType;
        /// <summary>
        /// 数据表示格式
        /// </summary>
        public string DisplayFormat;
    }
}
