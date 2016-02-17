using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using InfraStructure.DataBase;
using InfraStructure.Helper;
using InfraStructure.Utility;
using MongoDB.Driver.Builders;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace InfraStructure.Table
{
    /// <summary>
    /// 辅助表
    /// </summary>
    public abstract class MasterTable : OwnerTable
    {

        //MasterCode和Owner的Code（内部编号）合并为一个编号

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

        /// <summary>
        /// Code格式
        /// </summary>
        public new const string CodeFormat = "D6";

        /// <summary>
        /// 辅助表前缀 
        /// </summary>
        public const string MasterPrefix = "M_";
        /// <summary>
        /// 空列表
        /// </summary>
        public const string StrEmptyList = "[空列表]";
        /// <summary>
        /// 未知
        /// </summary>
        public const string StrUnknown = "[未知]";

        #region Method
        /// <summary>
        ///     获得Rank列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetCodeRankDic<T>(string ownerId) where T : MasterTable, new()
        {
            var rankDic = new Dictionary<string, int>();
            var t = EasyQuery.GetRecListByOwnerId<T>(new T().GetCollectionName(), ownerId);
            foreach (var item in t)
            {
                rankDic.Add(item.Code, item.Rank);
            }
            return rankDic;
        }

        /// <summary>
        ///     将MasterCode列表转换为Master描述字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterCodeList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<string> GetMasterNameList<T>(List<string> masterCodeList, string ownerId)
            where T : MasterTable, new()
        {
            var rtn = new List<string>();
            if (masterCodeList == null) return rtn;
            foreach (var code in masterCodeList)
            {
                rtn.Add(GetMasterName<T>(code, ownerId));
            }
            if (rtn.Count == 0)
            {
                rtn.Add(StrEmptyList);
            }
            return rtn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="masterCodeList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<string> GetMasterNameList(string collectionName, List<string> masterCodeList, string ownerId)
        {
            var rtn = new List<string>();
            if (masterCodeList == null) return rtn;
            foreach (var code in masterCodeList)
            {
                rtn.Add(GetMasterName(collectionName, code, ownerId));
            }
            if (rtn.Count == 0)
            {
                rtn.Add(StrEmptyList);
            }
            return rtn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterCodeList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<string> GetMasterNameList<T>(List<ItemWithGrade> masterCodeList, string ownerId)
            where T : MasterTable, new()
        {
            var rtn = new List<string>();
            if (masterCodeList == null) return rtn;
            foreach (var gradeItem in masterCodeList)
            {
                rtn.Add(GetMasterName<T>(gradeItem.MasterCode, ownerId) + "-" + gradeItem.Grade);
            }
            if (rtn.Count == 0)
            {
                rtn.Add(StrEmptyList);
            }
            return rtn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="masterCodeList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<string> GetMasterNameList(string collectionName, List<ItemWithGrade> masterCodeList, string ownerId)
        {
            var rtn = new List<string>();
            if (masterCodeList == null) return rtn;
            foreach (var gradeItem in masterCodeList)
            {
                rtn.Add(GetMasterName(collectionName, gradeItem.MasterCode, ownerId) + "-" + gradeItem.Grade);
            }
            if (rtn.Count == 0)
            {
                rtn.Add(StrEmptyList);
            }
            return rtn;
        }

        /// <summary>
        ///     将MasterCode转换为Master描述字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterCode"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string GetMasterName<T>(string masterCode, string ownerId) where T : MasterTable, new()
        {
            if (masterCode == null || string.IsNullOrEmpty(masterCode) || masterCode == UnKnownCode)
            {
                return StrUnknown;
            }
            var cacheKey = ownerId + "." + new T().GetCollectionName() + "." + masterCode;
            var cacheValue = CacheSystem.GetMasterNameCache(cacheKey);
            if (!string.IsNullOrEmpty(cacheValue)) return cacheValue;
            //检索
            var m = EasyQuery.GetRecByCodeAtOwner<T>(new T().GetCollectionName(), ownerId, masterCode);
            if (m == null)
            {
                return StrUnknown;
            }
            CacheSystem.PutMasterNameCache(cacheKey, m.Name);
            return m.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="masterCode"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string GetMasterName(string collectionName, string masterCode, string ownerId)
        {
            if (masterCode == null || string.IsNullOrEmpty(masterCode) || masterCode == UnKnownCode)
            {
                return StrUnknown;
            }
            var cacheKey = ownerId + "." + collectionName + "." + masterCode;
            var cacheValue = CacheSystem.GetMasterNameCache(cacheKey);
            if (!string.IsNullOrEmpty(cacheValue)) return cacheValue;
            //检索
            var m = EasyQuery.GetRecByCodeAtOwner(collectionName, ownerId, masterCode);
            if (m == null)
            {
                return StrUnknown;
            }
            CacheSystem.PutMasterNameCache(cacheKey, m.GetValue(nameof(Name)).ToString());
            return m.GetValue(nameof(Name)).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="CollectionName"></typeparam>
        /// <param name="gradeList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<string> GetMasterNameGradeList(string collectionName, List<ItemWithGrade> gradeList, string ownerId)
        {
            var resultList = new List<string>();
            foreach (var item in gradeList)
            {
                resultList.Add(GetMasterName(collectionName, item.MasterCode, ownerId) + "-" + item.Grade);
            }
            if (resultList.Count == 0)
            {
                resultList.Add(StrEmptyList);
            }
            return resultList;
        }


        /// <summary>
        /// GetMasterCode
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterName"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>

        public static string GetMasterCode<T>(string masterName, string ownerId) where T : MasterTable, new()
        {
            if (masterName == null || string.IsNullOrEmpty(masterName))
            {
                return UnKnownCode;
            }
            var cacheKey = ownerId + "." + new T().GetCollectionName() + "." + masterName;
            var cacheValue = CacheSystem.GetMasterCodeCache(cacheKey);
            if (!string.IsNullOrEmpty(cacheValue)) return cacheValue;

            var ownerQuery = EasyQuery.OwnerIdQuery(ownerId);
            var nameQuery = Query.EQ(nameof(Name), masterName);
            var query = Query.And(ownerQuery, nameQuery);
            var m = MongoDbRepository.GetFirstRec<T>(query);
            if (m == null)
            {
                return UnKnownCode;
            }
            CacheSystem.PutMasterCodeCache(cacheKey, m.Code);
            return m.Code;
        }

        public static string GetMasterCode(string collectionName, string masterName, string ownerId)
        {
            if (masterName == null || string.IsNullOrEmpty(masterName))
            {
                return UnKnownCode;
            }
            var cacheKey = ownerId + "." + collectionName + "." + masterName;
            var cacheValue = CacheSystem.GetMasterCodeCache(cacheKey);
            if (!string.IsNullOrEmpty(cacheValue)) return cacheValue;

            var ownerIdQuery = EasyQuery.OwnerIdQuery(ownerId);
            var nameQuery = Query.EQ(nameof(Name), masterName);
            var query = Query.And(ownerIdQuery, nameQuery);
            var m = MongoDbRepository.GetFirstRec(collectionName, query);
            if (m == null)
            {
                return UnKnownCode;
            }
            CacheSystem.PutMasterCodeCache(cacheKey, m.GetValue(nameof(Code)).ToString());
            return m.GetValue(nameof(Code)).ToString();
        }

        /// <summary>
        /// GetMasterCodeList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterNameList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<string> GetMasterCodeList<T>(List<string> masterNameList, string ownerId) where T : MasterTable, new()
        {
            var rtn = new List<string>();
            if (masterNameList == null) return rtn;
            foreach (var code in masterNameList)
            {
                rtn.Add(GetMasterCode<T>(code, ownerId));
            }
            if (rtn.Count == 0)
            {
                rtn.Add(StrEmptyList);
            }
            return rtn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="masterNameList"></param>
        /// <param name="OrganizationId"></param>
        /// <returns></returns>
        public static List<string> GetMasterCodeList(string collectionName, List<string> masterNameList, string ownerId)
        {
            var rtn = new List<string>();
            if (masterNameList == null) return rtn;
            foreach (var code in masterNameList)
            {
                rtn.Add(GetMasterCode(collectionName, code, ownerId));
            }
            if (rtn.Count == 0)
            {
                rtn.Add(StrEmptyList);
            }
            return rtn;
        }
        /// <summary>
        /// GetMasterCodeList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterNameList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<ItemWithGrade> GetMasterCodeGradeList<T>(List<string> masterNameList, string ownerId) where T : MasterTable, new()
        {
            var rtn = new List<ItemWithGrade>();
            if (masterNameList == null) return rtn;
            foreach (var gradeItem in masterNameList)
            {
                var t = gradeItem.Split("-".ToCharArray());
                rtn.Add(new ItemWithGrade
                {
                    MasterCode = GetMasterCode<T>(t[0], ownerId),
                    Grade = t[1].GetEnum(CommonGrade.NotAvaliable)
                });
            }
            return rtn;
        }


        /// <summary>
        /// 根据Rank获得Code
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string GetCodeByRank<T>(int rank, string ownerId) where T : MasterTable, new()
        {
            var t = EasyQuery.GetRecListByOwnerId<T>(new T().GetCollectionName(), ownerId);
            foreach (var status in t)
            {
                if (status.Rank == rank)
                {
                    return status.Code;
                }
            }
            return string.Empty;
        }
        #region Master

        /// <summary>
        /// 获得启用Master
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<MasterWrapper> GetActiveMasterWrapper(string collectionName, string ownerId) 
        {
            var query = Query.And(EasyQuery.OwnerIdQuery(ownerId), Query.EQ(nameof(IsActive), true));
            return MongoDbRepository.GetRecList<MasterWrapper>(collectionName, query);
        }
        /// <summary>
        /// 获得启用Master
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static List<MasterWrapper> GetActiveMasterWrapper(string collectionName)
        {
            var query = Query.And(EasyQuery.OwnerIdQuery(DefaultOwnerId), Query.EQ(nameof(IsActive), true));
            return MongoDbRepository.GetRecList<MasterWrapper>(collectionName, query);
        }
        /// <summary>
        ///     获得启用Master
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        [Obsolete]
        public static List<T> GetActiveMasterRec<T>(string collectionName, string ownerId) where T : MasterTable
        {
            var query = Query.And(EasyQuery.OwnerIdQuery(ownerId), Query.EQ(nameof(IsActive), true));
            return MongoDbRepository.GetRecList<T>(collectionName, query);
        }

        /// <summary>
        ///     获得启用Master
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static List<T> GetActiveMasterRec<T>(string ownerId) where T : MasterTable, new()
        {
            var query = Query.And(EasyQuery.OwnerIdQuery(ownerId), Query.EQ(nameof(IsActive), true));
            return MongoDbRepository.GetRecList<T>(new T().GetCollectionName(), query);
        }
        #endregion
        /// <summary>
        /// 插入Master
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ownerId"></param>
        /// <param name=nameof(MasterTable.Name)></param>
        /// <param name="rank"></param>
        public static void InsertMasterItem<T>(string ownerId, string name, int rank)
            where T : MasterTable, new()
        {
            var master = new T
            {
                OwnerId = ownerId,
                Name = name,
                Description = name,
                Rank = rank,
                IsActive = true
            };
            master.Code = GetNewCodeByOwnerId(master);
            MongoDbRepository.InsertRec(master);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="rank"></param>
        public static void InsertMasterItem<T>(string ownerId, string name, string description, int rank)
            where T : MasterTable, new()
        {
            var master = new T
            {
                OwnerId = ownerId,
                Name = name,
                Description = description,
                Rank = rank,
                IsActive = true
            };
            master.Code = GetNewCodeByOwnerId(master);
            MongoDbRepository.InsertRec(master);
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="obj"></param>
        public static void UpdateCache(EntityBase obj)
        {
            var typeName = obj.GetType().Name;
            if (typeName.StartsWith(MasterPrefix))
            {
                var masterTable = (MasterTable)obj;
                var cacheKey = masterTable.OwnerId + "." + typeName + "." + masterTable.Code;
                CacheSystem.PutMasterNameCache(cacheKey, masterTable.Name);
                cacheKey = masterTable.OwnerId + "." + typeName + "." + masterTable.Name;
                CacheSystem.PutMasterCodeCache(cacheKey, masterTable.Code);
            }

            if (typeName == typeof(MasterWrapper).Name)
            {
                //MasterWrapper
                var masterWrapper = (MasterWrapper)obj;
                var cacheKey = masterWrapper.OwnerId + "." + masterWrapper.CollectionName + "." + masterWrapper.Code;
                CacheSystem.PutMasterNameCache(cacheKey, masterWrapper.Name);
                cacheKey = masterWrapper.OwnerId + "." + masterWrapper.CollectionName + "." + masterWrapper.Name;
                CacheSystem.PutMasterCodeCache(cacheKey, masterWrapper.Code);
            }
        }
        #endregion

        #region WithoutOwner
        /// <summary>
        /// 获得启用Master
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetActiveMasterRec<T>() where T : MasterTable, new()
        {
            return GetActiveMasterRec<T>(DefaultOwnerId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<MasterWrapper> GetActiveMasterWrapperByCache(string masterName)
        {
            return CacheSystem.GetMasterTableCache(masterName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public static MasterWrapper GetMasterWrapper(int code, string name, string description, int rank)
        {
            var master = new MasterWrapper
            {
                Code = code.ToString(CodeFormat),
                OwnerId = DefaultOwnerId,
                Name = description,
                Description = name,
                Rank = rank,
                IsActive = true
            };
            return master;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="catalogCode"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        public static MasterWrapper GetCatalogMasterWrapper(int code, string name, string description, int catalogCode, int rank)
        {
            var master = new MasterWrapper
            {
                Code = code.ToString(CodeFormat),
                CatalogCode = catalogCode.ToString(CodeFormat),
                OwnerId = DefaultOwnerId,
                Name = description,
                Description = name,
                Rank = rank,
                IsActive = true
            };
            return master;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterCode"></param>
        /// <returns></returns>
        public static string GetMasterName<T>(string masterCode) where T : MasterTable, new()
        {
            return GetMasterName<T>(masterCode, DefaultOwnerId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="catalogCode"></param>
        /// <param name="name"></param>
        /// <param name="rank"></param>
        public static void InsertCatalogMasterItem<T>(string catalogCode, string name, int rank)
            where T : CatalogMasterTable, new()
        {
            var master = new T
            {
                OwnerId = DefaultOwnerId,
                CatalogCode = catalogCode,
                Name = name,
                Description = name,
                Rank = rank,
                IsActive = true
            };
            master.Code = GetNewCodeByOwnerId(master);
            MongoDbRepository.InsertRec(master);
        }
        #endregion

        #region Import & Export
        /// <summary>
        /// 
        /// </summary>
        /// <param name="masterNameList"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static MemoryStream ExportToExcel(List<string> masterNameList, string ownerId)
        {
            var workbook = new HSSFWorkbook();
            var ms = new MemoryStream();
            foreach (var mastername in masterNameList)
            {
                ExportToExcelSheet(workbook.CreateSheet(mastername), EasyQuery.GetRecListByOwnerId<MasterWrapper>(mastername, ownerId)); ;
            }
            workbook.Write(ms);
            workbook = null;
            return ms;
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="masterList"></param>
        /// <returns></returns>
        private static void ExportToExcelSheet<T>(ISheet sheet, List<T> masterList) where T : MasterTable
        {
            var colcnt = 0;
            var rowcnt = 0;
            // Header
            var header = sheet.CreateRow(rowcnt); rowcnt++;
            colcnt = 0;

            var typeObj = typeof(T);
            Func<string, string> getName = x =>
            {
                return EasyQuery.GetDisplayName(x, typeObj);
            };

            header.CreateCell(colcnt).SetCellValue(nameof(Code)); colcnt++;
            header.CreateCell(colcnt).SetCellValue(getName(nameof(Name))); colcnt++;
            header.CreateCell(colcnt).SetCellValue(getName("Description")); colcnt++;
            header.CreateCell(colcnt).SetCellValue(getName("Rank")); colcnt++;
            header.CreateCell(colcnt).SetCellValue(getName("IsActive")); colcnt++;

            for (var i = 0; i < masterList.Count; i++)
            {
                var t = masterList[i];
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
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public static string ImportFromExcelSheet(HttpPostedFileBase file, string collectionName, string ownerId)
        {
            var strResult = string.Empty;
            var colcnt = 0;
            try
            {
                var excelFileStream = file.InputStream;
                IWorkbook workbook = new HSSFWorkbook(excelFileStream);
                var sheet = workbook.GetSheetAt(0);
                var rowCount = sheet.LastRowNum;
                var masterList = new List<MasterWrapper>();
                var errorFlg = false;
                for (var i = 1; i <= rowCount; i++)
                {
                    var row = sheet.GetRow(i);
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
                        t = EasyQuery.GetRecByCodeAtOwner<MasterWrapper>(collectionName, ownerId, code);
                        if (t == null)
                        {
                            strResult += "记录号码为:[" + code + "]的记录没有找到！" + Environment.NewLine;
                            errorFlg = true;
                            continue;
                        }
                        t.Code = code;
                    }
                    t.OwnerId = ownerId;
                    t.Name = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(); colcnt++;
                    t.Description = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString(); colcnt++;
                    t.Rank = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).GetInt(0); colcnt++;
                    t.IsActive = row.GetCell(colcnt, MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString().Equals("是"); colcnt++;
                    masterList.Add(t);
                }
                if (!errorFlg)
                {
                    var insertCnt = 0;
                    var upDateCnt = 0;
                    for (var i = 0; i < masterList.Count; i++)
                    {
                        //根据有无Code进行不同操作
                        if (string.IsNullOrEmpty(masterList[i].Code))
                        {
                            //新增模式
                            masterList[i].Code = GetNewCodeByOwnerId(collectionName, ownerId);
                            MongoDbRepository.InsertRec(masterList[i], collectionName, "SYSTEM_IMPORT");
                            insertCnt++;
                        }
                        else
                        {
                            //修改模式
                            MongoDbRepository.UpdateRec(masterList[i], collectionName, "SYSTEM_IMPORT");
                            upDateCnt++;
                        }
                    }
                    strResult = "全体件数:" + masterList.Count + Environment.NewLine;
                    strResult += "追加件数:" + insertCnt + Environment.NewLine;
                    strResult += "修改件数:" + upDateCnt + Environment.NewLine;
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


}