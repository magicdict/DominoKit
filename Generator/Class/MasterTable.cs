using InfraStructure.DataBase;
using InfraStructure.Utility;
using MongoDB.Driver.Builders;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
namespace BussinessLogic.Entity
{
    /// <summary>
    /// 辅助表
    /// </summary>
    public abstract class MasterTable : CompanyTable
    {
        /// <summary>
        ///     名字
        /// </summary>
        [DisplayName("名称")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }

        /// <summary>
        ///     等级
        /// </summary>
        [DisplayName("等级")]
        [Range(1, 99, ErrorMessage = "请输入1-99的数字")]
        [Required]
        public int Rank { get; set; }

        /// <summary>
        ///     是否启用
        /// </summary>
        [DisplayName("启用")]
        public bool IsActive { get; set; }

        /// <summary>
        /// 未知
        /// </summary>
        public const string UnKnownCode = "000000";
        /// <summary>
        /// 最大
        /// </summary>
        public const string MaxCode = "999999";

        #region Method
        /// <summary>
        ///     获得Rank列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetCodeRankDic<T>(string CompanyId) where T : MasterTable, new()
        {
            var RankDic = new Dictionary<string, int>();
            var t = EasyQuery.GetRecListByCompanyId<T>(new T().GetCollectionName(), CompanyId);
            foreach (var item in t)
            {
                RankDic.Add(item.Code, item.Rank);
            }
            return RankDic;
        }

        /// <summary>
        ///     将MasterCode列表转换为Master描述字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MasterCodeList"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static List<string> GetMasterNameList<T>(List<string> MasterCodeList, string CompanyId)
            where T : MasterTable, new()
        {
            var rtn = new List<string>();
            if (MasterCodeList == null) return rtn;
            foreach (var code in MasterCodeList)
            {
                rtn.Add(GetMasterName<T>(code, CompanyId));
            }
            return rtn;
        }

        public static List<string> GetMasterNameList<T>(List<ItemWithGrade> MasterCodeList, string CompanyId)
            where T : MasterTable, new()
        {
            var rtn = new List<string>();
            if (MasterCodeList == null) return rtn;
            foreach (var gradeItem in MasterCodeList)
            {
                rtn.Add(GetMasterName<T>(gradeItem.MasterCode, CompanyId) + "-" + gradeItem.Grade.ToString());
            }
            return rtn;
        }


        /// <summary>
        ///     将MasterCode转换为Master描述字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MasterCode"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static string GetMasterName<T>(string MasterCode, string CompanyId) where T : MasterTable, new()
        {
            if (MasterCode == null || string.IsNullOrEmpty(MasterCode) || MasterCode == UnKnownCode)
            {
                return "未知";
            }
            var CacheKey = CompanyId + "." + new T().GetCollectionName() + "." + MasterCode;
            var CacheValue = CacheSystem.GetMasterNameCache(CacheKey);
            if (!string.IsNullOrEmpty(CacheValue)) return CacheValue;
            //检索
            var m = EasyQuery.GetRecByCodeAtCompany<T>(new T().GetCollectionName(), CompanyId, MasterCode);
            if (m == null)
            {
                return "未知";
            }
            CacheSystem.PutMasterNameCache(CacheKey, m.Name);
            return m.Name;
        }

        /// <summary>
        /// GetMasterCode
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MasterName"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>

        public static string GetMasterCode<T>(string MasterName, string CompanyId) where T : MasterTable, new()
        {
            if (MasterName == null || string.IsNullOrEmpty(MasterName))
            {
                return UnKnownCode;
            }
            var CacheKey = CompanyId + "." + new T().GetCollectionName() + "." + MasterName;
            var CacheValue = CacheSystem.GetMasterCodeCache(CacheKey);
            if (!string.IsNullOrEmpty(CacheValue)) return CacheValue;

            var CompanyQuery = EasyQuery.CompanyIdQuery(CompanyId);
            var NameQuery = Query.EQ("Name", MasterName);
            var query = Query.And(CompanyQuery, NameQuery);
            var m = InfraStructure.DataBase.Repository.GetFirstRec<T>(new T().GetCollectionName(), query);
            if (m == null)
            {
                return UnKnownCode;
            }
            CacheSystem.PutMasterCodeCache(CacheKey, m.Code);
            return m.Code;
        }
        /// <summary>
        /// GetMasterCodeList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MasterNameList"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static List<string> GetMasterCodeList<T>(List<string> MasterNameList, string CompanyId) where T : MasterTable, new()
        {
            var rtn = new List<string>();
            if (MasterNameList == null) return rtn;
            foreach (var code in MasterNameList)
            {
                rtn.Add(GetMasterCode<T>(code, CompanyId));
            }
            return rtn;
        }

        /// <summary>
        /// GetMasterCodeList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="MasterNameList"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static List<ItemWithGrade> GetMasterCodeGradeList<T>(List<string> MasterNameList, string CompanyId) where T : MasterTable, new()
        {
            var rtn = new List<ItemWithGrade>();
            if (MasterNameList == null) return rtn;
            foreach (var gradeItem in MasterNameList)
            {
                var t = gradeItem.Split("-".ToCharArray());
                rtn.Add( new ItemWithGrade(){ 
                    MasterCode = GetMasterCode<T>(t[0], CompanyId),
                    Grade = t[1].GetEnum<CommonGrade>(CommonGrade.NotAvaliable)
                });
            }
            return rtn;
        }


        /// <summary>
        /// 根据Rank获得Code
        /// </summary>
        /// <param name="Rank"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static string GetCodeByRank<T>(int Rank, string CompanyId) where T : MasterTable, new()
        {
            var t = EasyQuery.GetRecListByCompanyId<T>(new T().GetCollectionName(), CompanyId);
            var r = string.Empty;
            foreach (var status in t)
            {
                if (status.Rank == Rank)
                {
                    return status.Code;
                }
            }
            return r;
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="obj"></param>
        public static void UpdateCache(EntityBase obj)
        {
            string typeName = obj.GetType().Name;
            if (typeName.StartsWith(CacheSystem.MasterPrefix))
            {
                MasterTable masterTable = (MasterTable)obj;
                string CacheKey = masterTable.CompanyId + "." + typeName + "." + masterTable.Code;
                CacheSystem.PutMasterNameCache(CacheKey, masterTable.Name);
                CacheKey = masterTable.CompanyId + "." + typeName + "." + masterTable.Name;
                CacheSystem.PutMasterCodeCache(CacheKey, masterTable.Code);
            }

            if (typeName == typeof(MasterWrapper).Name)
            {
                //MasterWrapper
                MasterWrapper masterWrapper = (MasterWrapper)obj;
                string CacheKey = masterWrapper.CompanyId + "." + masterWrapper.CollectionName + "." + masterWrapper.Code;
                CacheSystem.PutMasterNameCache(CacheKey, masterWrapper.Name);
                CacheKey = masterWrapper.CompanyId + "." + masterWrapper.CollectionName + "." + masterWrapper.Name;
                CacheSystem.PutMasterCodeCache(CacheKey, masterWrapper.Code);
            }
        }
        #endregion

        #region Import & Export

        public static MemoryStream ExportToExcel(List<string> MasterNameList, string CompanyId)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            foreach (var mastername in MasterNameList)
            {
                ExportToExcelSheet(workbook.CreateSheet(mastername), EasyQuery.GetRecListByCompanyId<MasterWrapper>(mastername, CompanyId)); ;
            }
            workbook.Write(ms);
            workbook = null;
            return ms;
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="MasterList"></param>
        /// <returns></returns>
        private static void ExportToExcelSheet<T>(ISheet sheet, List<T> MasterList) where T : MasterTable
        {
            int colcnt = 0;
            int rowcnt = 0;
            // Header
            var header = sheet.CreateRow(rowcnt); rowcnt++;
            colcnt = 0;

            var typeObj = typeof(T);
            Func<string, string> GetName = (x) =>
            {
                return EasyQuery.GetDisplayName(x, typeObj);
            };

            header.CreateCell(colcnt).SetCellValue("Code"); colcnt++;
            header.CreateCell(colcnt).SetCellValue(GetName("Name")); colcnt++;
            header.CreateCell(colcnt).SetCellValue(GetName("Description")); colcnt++;
            header.CreateCell(colcnt).SetCellValue(GetName("Rank")); colcnt++;
            header.CreateCell(colcnt).SetCellValue(GetName("IsActive")); colcnt++;

            for (int i = 0; i < MasterList.Count; i++)
            {
                T t = MasterList[i];
                var row = sheet.CreateRow(rowcnt); rowcnt++;
                colcnt = 0;
                row.CreateCell(colcnt).SetCellValue(t.Code); colcnt++;
                //BAD SMELL！！
                row.CreateCell(colcnt).SetCellValue(t.Name); colcnt++;
                row.CreateCell(colcnt).SetCellValue(t.Description); colcnt++;
                row.CreateCell(colcnt).SetCellValue(t.Rank); colcnt++;
                row.CreateCell(colcnt).SetCellValue(t.IsActive ? "是" : "否"); colcnt++;
            }
        }

        /// <summary>
        /// 从Excel导入
        /// </summary>
        /// <param name="file"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static string ImportFromExcelSheet(HttpPostedFileBase file, string CollectionName, string CompanyId)
        {
            string strResult = string.Empty;
            int colcnt = 0;
            try
            {
                var excelFileStream = file.InputStream;
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                ISheet sheet = workbook.GetSheetAt(0);
                int rowCount = sheet.LastRowNum;
                List<MasterWrapper> MasterList = new List<MasterWrapper>();
                Boolean ErrorFlg = false;
                for (int i = 1; i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (string.IsNullOrEmpty(row.GetCell(1).ToString())) break;
                    colcnt = 0;
                    var code = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(); colcnt++;
                    MasterWrapper t = null;
                    if (string.IsNullOrEmpty(code))
                    {
                        t = new MasterWrapper();
                    }
                    else
                    {
                        t = EasyQuery.GetRecByCodeAtCompany<MasterWrapper>(CollectionName, CompanyId, code);
                        if (t == null)
                        {
                            strResult += "记录号码为:[" + code + "]的记录没有找到！" + System.Environment.NewLine;
                            ErrorFlg = true;
                            continue;
                        }
                        else
                        {
                            t.Code = code;
                        }
                    }
                    t.CompanyId = CompanyId;
                    t.Name = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(); colcnt++;
                    t.Description = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(); colcnt++;
                    t.Rank = NPOIExtend.GetInt(row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK), 0); colcnt++;
                    t.IsActive = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString().Equals("是"); colcnt++;
                    MasterList.Add(t);
                }
                if (!ErrorFlg)
                {
                    int InsertCnt = 0;
                    int UpDateCnt = 0;
                    for (int i = 0; i < MasterList.Count; i++)
                    {
                        //根据有无Code进行不同操作
                        if (string.IsNullOrEmpty(MasterList[i].Code))
                        {
                            //新增模式
                            MasterList[i].Code = CompanyTable.GetCode(CollectionName, CompanyId);
                            InfraStructure.DataBase.Repository.InsertRec(MasterList[i], CollectionName, "SYSTEM_IMPORT");
                            InsertCnt++;
                        }
                        else
                        {
                            //修改模式
                            InfraStructure.DataBase.Repository.UpdateRec(MasterList[i], CollectionName, "SYSTEM_IMPORT");
                            UpDateCnt++;
                        }
                    }
                    strResult = "全体件数:" + MasterList.Count.ToString() + System.Environment.NewLine;
                    strResult += "追加件数:" + InsertCnt + System.Environment.NewLine;
                    strResult += "修改件数:" + UpDateCnt + System.Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                strResult = ex.ToString();
            }
            return strResult;
        }
        #endregion

    }

    /// <summary>
    /// StatusMasterTable
    /// </summary>
    public abstract class StatusMasterTable : MasterTable
    {
        /// <summary>
        ///     表示顺序
        /// </summary>
        [DisplayName("表示顺序")]
        [Range(1, 99, ErrorMessage = "请输入1-99的数字")]
        public int SortRank { get; set; }

        /// <summary>
        ///     背景颜色
        /// </summary>
        [DisplayName("背景颜色")]
        public WarningType BGColor { get; set; }

        /// <summary>
        /// 获得Code Vs SortRank 字典
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetCodeSortRankDic<T>(string CompanyId) where T : StatusMasterTable, new()
        {
            var RankDic = new Dictionary<string, int>();
            var t = EasyQuery.GetRecListByCompanyId<T>(new T().GetCollectionName(), CompanyId);
            foreach (var item in t)
            {
                RankDic.Add(item.Code, item.SortRank);
            }
            return RankDic;
        }
    }

    /// <summary>
    ///     MasterTable的包装
    /// </summary>
    public class MasterWrapper : MasterTable
    {
        /// <summary>
        /// 这个字段不是Static的，所以必须要忽略，不然的话，会保存到数据库中
        /// 在反序列化的时候会报错，因为真实的Master没有这个非静态字段
        /// </summary>
        [BsonIgnore]
        public string CollectionName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetCollectionName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetPrefix()
        {
            throw new NotImplementedException();
        }

        public static List<MasterWrapper> GenerateFromEnum<T>()
        {
            List<MasterWrapper> t = new List<MasterWrapper>();
            foreach (var ItemName in Enum.GetNames(typeof(T)))
            {
                t.Add(new MasterWrapper()
                {
                    Name = ItemName,
                    Description = ItemName,
                    Rank = Enum.Parse(typeof(T), ItemName).GetHashCode(),
                    Code = Enum.Parse(typeof(T), ItemName).GetHashCode().ToString()
                });
            }
            return t;
        }
    }
}