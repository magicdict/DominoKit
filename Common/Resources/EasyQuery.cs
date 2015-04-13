using InfraStructure.DataBase;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace BussinessLogic.Enterprise
{
    /// <summary>
    /// 业务相关数据库操作
    /// </summary>
    public static class EasyQuery
    {
        /// <summary>
        /// 仅查询未删除的记录
        /// </summary>
        static IMongoQuery CompanyIdQuery(string CompanyId)
        {
            return Query.EQ("CompanyId", CompanyId);
        }
        /// <summary>
        /// 获得指定CompanyId的指定表的数据数量
        /// </summary>
        /// <param name="CollectionName"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static int GetCountByCompanyId(string CollectionName, string CompanyId)
        {
            return Repository.GetRecordCount(CollectionName, CompanyIdQuery(CompanyId));
        }
        /// <summary>
        /// 获得指定CompanyId的指定表的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static List<T> GetRecListByCompanyId<T>(string CollectionName, string CompanyId) where T:EntityBase
        {
            return Repository.GetRecList<T>(CollectionName, CompanyIdQuery(CompanyId));
        }
        /// <summary>
        /// 获得指定CompanyId的指定表的第一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static T GetFirstRecByCompanyId<T>(string CollectionName, string CompanyId) where T : EntityBase
        {
            return Repository.GetFirstRec<T>(CollectionName, CompanyIdQuery(CompanyId));
        }
        /// <summary>
        /// 将MasterCode列表转换为Master描述字符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="interviewlist"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public static string GetInterviewListDescriptionByCompanyId<T>(List<string> interviewlist, string CompanyId) where T : MasterTable, new()
        {
            return MasterTable.GetNameListString<T>(interviewlist, CompanyIdQuery(CompanyId));
        }
    }
}
