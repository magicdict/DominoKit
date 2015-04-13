using InfraStructure.DataBase;

namespace BussinessLogic.Entity
{
    public abstract class CompanyTable : EntityBase
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public string CompanyId;
        /// <summary>
        /// 内部编号
        /// </summary>
        public string Code;
        /// <summary>
        /// 采番
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public string GetCode(string collectionName, string companyId)
        {
            int count = EasyQuery.GetCountByCompanyId(collectionName, companyId, true);
            return (count + 1).ToString("D5");
        }
    }
}
