using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 招聘追踪
    /// </summary>
    public partial class HiringTrack : CompanyTable
    {
        #region "model"

            /// <summary>
            /// 候选人编号
            /// </summary>
            [DisplayName("候选人编号")]
            [Required]
            public string TalentCode { get; set; }

            /// <summary>
            /// 职位编号
            /// </summary>
            [HiddenInput]
            [DisplayName("职位编号")]
            public string PositionCode { get; set; }

            /// <summary>
            /// 起始时间
            /// </summary>
            [DisplayName("起始时间")]
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime ScreenDate { get; set; }

            /// <summary>
            /// 面试记录
            /// </summary>
            [DisplayName("面试记录")]
            public List<string> InterviewList { get; set; }

            /// <summary>
            /// 最终结果
            /// </summary>
            [DisplayName("最终结果")]
            public string FinalStatus { get; set; }

            /// <summary>
            /// 确认录用时间
            /// </summary>
            [DisplayName("确认录用时间")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime OfferDate { get; set; }

            /// <summary>
            /// 入职时间
            /// </summary>
            [DisplayName("入职时间")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime OnBoardDate { get; set; }

            /// <summary>
            /// 拒绝入职的原因
            /// </summary>
            [DisplayName("拒绝入职的原因")]
            public string RefuseReason { get; set; }

            /// <summary>
            /// 是否关闭
            /// </summary>
            [DisplayName("是否关闭")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool IsClosed { get; set; }

            /// <summary>
            /// 招聘渠道
            /// </summary>
            [HiddenInput]
            [DisplayName("招聘渠道")]
            public string Channel { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "HiringTrack";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "HiringTrack";


            /// <summary>
            /// 数据主键前缀
            /// </summary>
            public override string GetPrefix()
            {
                return string.Empty;
            }

            /// <summary>
            /// 数据主键前缀静态字段
            /// </summary>
            public static string Prefix = string.Empty;

            /// <summary>
            /// Mvc画面的标题
            /// </summary>
            [BsonIgnore]
            public static string MvcTitle = "招聘追踪";

        #endregion
    }
}
