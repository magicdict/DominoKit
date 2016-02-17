using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using InfraStructure.DataBase;
using InfraStructure.FilterSet;
using InfraStructure.Helper;
using InfraStructure.Utility;
using MongoDB.Bson;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

namespace InfraStructure.Table
{
    public abstract class OwnerTable : EntityBase
    {
        /// <summary>
        /// 持有者号码
        /// </summary>
        public static string DefaultOwnerId = 1.ToString(OwnerIdFormat);

        /// <summary>
        /// 共通持有者号码
        /// </summary>
        public static string CommonOwnerId = new string("9".ToCharArray()[0],OwnerIdLength);

        /// <summary>
        ///     OwnerId格式
        /// </summary>
        public const string OwnerIdFormat = "D8";

        /// <summary>
        ///     OwnerId长度
        /// </summary>
        public const int OwnerIdLength = 8;

        /// <summary>
        ///     Code格式
        /// </summary>
        public const string CodeFormat = "D6";

        /// <summary>
        ///     Code长度
        /// </summary>
        public const int CodeLength = 6;

        /// <summary>
        /// 
        /// </summary>
        public const string SystemImport = "SYSTEM_IMPORT";


        /// <summary>
        ///     组织编号
        /// </summary>
        public string OwnerId;

        /// <summary>
        ///     组织内部编号
        /// </summary>
        [DisplayName("编号")]
        public string Code { set; get; }

        /// <summary>
        ///     采番
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetNewCodeByOwnerId(OwnerTable obj)
        {
            var count = EasyQuery.GetCountByOwnerId(obj.GetCollectionName(), obj.OwnerId, true);
            return (count + 1).ToString(CodeFormat);
        }

        /// <summary>
        ///     采番
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetCodeByCreateUser(OwnerTable obj)
        {
            var count = EasyQuery.GetCountByCreateUser(obj.GetCollectionName(), obj.CreateUser, true);
            return (count + 1).ToString(CodeFormat);
        }

        /// <summary>
        ///     采番
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string GetNewCodeByOwnerId(string collectionName, string ownerId)
        {
            var count = EasyQuery.GetCountByOwnerId(collectionName, ownerId, true);
            return (count + 1).ToString(CodeFormat);
        }

        /// <summary>
        ///     采番
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static string GetCodeByCreateUser(string collectionName, string accountId)
        {
            var count = EasyQuery.GetCountByCreateUser(collectionName, accountId, true);
            return (count + 1).ToString(CodeFormat);
        }


        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="recordList"></param>
        /// <param name="outPutFields"></param>
        /// <returns></returns>
        public static MemoryStream ExportToExcel<T>(List<T> recordList, List<string> outPutFields)
            where T : OwnerTable, new()
        {
            var workbook = new HSSFWorkbook();
            var ms = new MemoryStream();
            var sheet = workbook.CreateSheet(EasyQuery.GetDisplayName(typeof(T)));
            var rowcnt = 0;
            var colcnt = 0;
            // Header
            var header = sheet.CreateRow(rowcnt); rowcnt++;
            var typeObj = typeof(T);
            header.CreateCell(colcnt).SetCellValue(nameof(Code)); colcnt++;
            foreach (var property in typeObj.GetProperties())
            {
                if (outPutFields.Contains(property.Name))
                {
                    header.CreateCell(colcnt).SetCellValue(EasyQuery.GetDisplayName(property.Name, typeObj));
                    colcnt++;
                }
            }

            T t;
            for (var i = 0; i < recordList.Count; i++)
            {
                t = recordList[i];
                var row = sheet.CreateRow(rowcnt); rowcnt++;
                colcnt = 0;
                row.CreateCell(colcnt).SetCellValue(t.Code); colcnt++;
                foreach (var property in typeObj.GetProperties())
                {
                    if (outPutFields.Contains(property.Name))
                    {
                        //根据类型进行处理
                        var displayValue = GetDisplayValue(t, property);
                        row.CreateCell(colcnt).SetCellValue(displayValue);
                        colcnt++;
                    }
                }
            }
            workbook.Write(ms);
            return ms;
        }

        /// <summary>
        ///     获得表示值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private static string GetDisplayValue<T>(T t, PropertyInfo property) where T : OwnerTable, new()
        {
            var displayValue = string.Empty;
            var filterAttrs = property.GetCustomAttributes(typeof(FilterItemAttribute), false);
            if (filterAttrs.Length == 1)
            {
                var filterAttr = (FilterItemAttribute)filterAttrs[0];
                switch (filterAttr.MetaStructType)
                {
                    case FilterItemAttribute.StructType.SingleMasterTable:
                        var masterCode = (string)property.GetValue(t);
                        var masterName = filterAttr.MetaType.Name;
                        displayValue = MasterTable.GetMasterName(masterName, masterCode, t.OwnerId);
                        break;
                    case FilterItemAttribute.StructType.MultiMasterTable:
                    case FilterItemAttribute.StructType.MultiCatalogMasterTable:
                        var masterCodeList = (List<string>)property.GetValue(t);
                        var masterListName = filterAttr.MetaType.Name;
                        displayValue = MasterTable.GetMasterNameList(masterListName, masterCodeList, t.OwnerId).GetJoinString(";");
                        break;
                    case FilterItemAttribute.StructType.MultiMasterTableWithGrade:
                        var masterGradeCodeList = (List<ItemWithGrade>)property.GetValue(t);
                        var masterGradeName = filterAttr.MetaType.Name;
                        displayValue = MasterTable.GetMasterNameGradeList(masterGradeName, masterGradeCodeList, t.OwnerId).GetJoinString(";");
                        break;
                    case FilterItemAttribute.StructType.Datetime:
                        displayValue = ((DateTime)property.GetValue(t)).ToString("yyyy-MM-dd");
                        break;
                    case FilterItemAttribute.StructType.Boolean:
                        displayValue = (bool)property.GetValue(t) ? "是" : "否";
                        break;
                    case FilterItemAttribute.StructType.SingleEnum:
                        displayValue = Enum.GetName(filterAttr.MetaType, property.GetValue(t));
                        break;
                    default:
                        displayValue = property.GetValue(t).ToString();
                        break;
                }
            }
            else
            {
                if (property.GetValue(t) != null)
                {
                    displayValue = property.GetValue(t).ToString();
                }
            }
            return displayValue;
        }
        /// <summary>
        ///     GetDisplayValue
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="document"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetDisplayValue(string ownerId, BsonDocument document, PropertyInfo property)
        {
            var displayValue = string.Empty;
            var elementName = property.Name;
            var filterAttrs = property.GetCustomAttributes(typeof(FilterItemAttribute), false);
            if (document.GetValue(elementName) == BsonNull.Value)
            {
                return displayValue;
            }
            if (filterAttrs.Length == 1)
            {
                var filterAttr = (FilterItemAttribute)filterAttrs[0];
                switch (filterAttr.MetaStructType)
                {
                    case FilterItemAttribute.StructType.SingleMasterTable:
                        var masterCode = document.GetValue(elementName).ToString();
                        var masterName = filterAttr.MetaType.Name;
                        displayValue = MasterTable.GetMasterName(masterName, masterCode, ownerId);
                        break;
                    case FilterItemAttribute.StructType.MultiMasterTable:
                    case FilterItemAttribute.StructType.MultiCatalogMasterTable:
                        var bsonList = document.GetValue(elementName).AsBsonArray.ToList();
                        var masterCodeList = bsonList.Select(item => item.ToString()).ToList();
                        var masterListName = filterAttr.MetaType.Name;
                        displayValue = MasterTable.GetMasterNameList(masterListName, masterCodeList, ownerId).GetJoinString("<br />");
                        break;
                    case FilterItemAttribute.StructType.MultiMasterTableWithGrade:
                        bsonList = document.GetValue(elementName).AsBsonArray.ToList();
                        var masterGradeCodeList = new List<ItemWithGrade>();
                        foreach (var bsonValue in bsonList)
                        {
                            var item = (BsonDocument) bsonValue;
                            masterGradeCodeList.Add(new ItemWithGrade
                            { 
                                 Grade = (CommonGrade)item.GetValue(nameof(ItemWithGrade.Grade)).ToInt32(),
                                 MasterCode = item.GetValue(nameof(ItemWithGrade.MasterCode)).ToString()
                            });
                        }
                        var masterGradeName = filterAttr.MetaType.Name;
                        displayValue = MasterTable.GetMasterNameGradeList(masterGradeName, masterGradeCodeList, ownerId).GetJoinString("<br />");
                        break;
                    case FilterItemAttribute.StructType.Datetime:
                        displayValue = (document.GetValue(elementName).ToLocalTime()).ToString("yyyy-MM-dd");
                        break;
                    case FilterItemAttribute.StructType.Boolean:
                        displayValue = (document.GetValue(elementName).AsBoolean) ? "是" : "否";
                        break;
                    case FilterItemAttribute.StructType.SingleEnum:
                        displayValue = Enum.GetName(filterAttr.MetaType, document.GetValue(elementName).ToInt32());
                        break;
                    default:
                        displayValue = document.GetValue(elementName).ToString();
                        break;
                }
            }
            else
            {
                displayValue = document.GetValue(elementName).ToString();
            }
            return displayValue;
        }

        /// <summary>
        ///     从Excel导入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string ImportFromExcel<T>(HttpPostedFileBase file,string ownerId) where T : OwnerTable, new()
        {
            string strResult;
            try
            {
                var excelFileStream = file.InputStream;
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                var sheet = workbook.GetSheetAt(0);
                return ImportFromSheet<T>(sheet, ownerId);
            }
            catch (OfficeXmlFileException)
            {
                strResult = "请确认一下文件格式，暂时只支持Office2003和Office2007。请将文件另存为Office2003格式（*.xls）";
            }
            catch (Exception ex)
            {
                strResult = ex.ToString();
            }
            return strResult;
        }

        /// <summary>
        ///     从Excel导入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string ImportFromSheet<T>(ISheet sheet, string ownerId) where T : OwnerTable, new()
        {
            var strResult = string.Empty;
            try
            {
                var rowCount = sheet.LastRowNum;
                var entityList = new List<T>();
                var errorFlg = false;
                for (var i = 1; i <= rowCount; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(1) == null || string.IsNullOrEmpty(row.GetCell(1).ToString())) break;
                    T t;
                    var code = row.GetCell(0, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetCode();
                    if (string.IsNullOrEmpty(code))
                    {
                        t = new T();
                    }
                    else
                    {
                        t = EasyQuery.GetRecByCodeAtOwner<T>(ownerId, code);
                        if (t == null)
                        {
                            strResult += "记录号码为:[" + code + "]的记录没有找到！" + Environment.NewLine;
                            errorFlg = true;
                            continue;
                        }
                    }
                    GenerateRecord(row, t);
                    entityList.Add(t);
                }
                if (!errorFlg)
                {
                    var insertCnt = 0;
                    var upDateCnt = 0;
                    strResult = string.Empty;
                    for (var i = 0; i < entityList.Count; i++)
                    {
                        //根据有无Code进行不同操作
                        if (string.IsNullOrEmpty(entityList[i].Code))
                        {
                            //新增模式
                            entityList[i].Code = GetNewCodeByOwnerId(entityList[i]);
                            MongoDbRepository.InsertRec(entityList[i], SystemImport);
                            insertCnt++;
                        }
                        else
                        {
                            //修改模式
                            MongoDbRepository.UpdateRec(entityList[i], SystemImport);
                            upDateCnt++;
                        }
                    }
                    strResult += "全体件数:" + entityList.Count + Environment.NewLine;
                    strResult += "追加件数:" + insertCnt + Environment.NewLine;
                    strResult += "修改件数:" + upDateCnt + Environment.NewLine;
                    return strResult;
                }
            }
            catch (Exception ex)
            {
                strResult = ex.ToString();
            }
            return strResult;

        }
        /// <summary>
        /// 读取记录内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="t"></param>
        protected static void GenerateRecord<T>(IRow row, T t)
             where T : OwnerTable, new()
        {
            //StringCellValue
            //如果Cell里面是Formal的话，ToString方法获得的是公式的文本，不是 Text属性
            //所以这里使用StringCellValue
            var typeObj = typeof(T);
            var organizationId = t.OwnerId;
            var colcnt = 1;
            foreach (var property in typeObj.GetProperties())
            {
                //根据类型进行处理
                var filterAttrs = property.GetCustomAttributes(typeof(FilterItemAttribute), false);
                if (filterAttrs.Length == 1)
                {
                    var filterAttr = (FilterItemAttribute)filterAttrs[0];
                    switch (filterAttr.MetaStructType)
                    {
                        case FilterItemAttribute.StructType.SingleMasterTable:
                            var masterName = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetCellText();
                            var masterTableName = filterAttr.MetaType.Name;
                            property.SetValue(t, MasterTable.GetMasterCode(masterTableName, masterName, organizationId));
                            break;
                        case FilterItemAttribute.StructType.MultiMasterTable:
                            var masterNameList = (List<string>)property.GetValue(t);
                            var masterListTableName = filterAttr.MetaType.Name;
                            property.SetValue(t, MasterTable.GetMasterCodeList(masterListTableName, masterNameList, organizationId));
                            break;
                        case FilterItemAttribute.StructType.Datetime:
                            property.SetValue(t, row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetDate(DateTime.MinValue));
                            break;
                        case FilterItemAttribute.StructType.Boolean:
                            property.SetValue(t, row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetCellText() == "是");
                            break;
                        default:
                            property.SetValue(t, row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetCellText());
                            break;
                    }
                }
                else
                {
                    property.SetValue(t, row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetCellText());
                }
                colcnt++;
            }
        }

    }
}