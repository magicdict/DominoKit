using InfraStructure;
using InfraStructure.FilterSet;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 招聘经理
    /// </summary>
    [DisplayName("招聘经理")]
    public partial class M_HiringManager : MasterTable
    {
        #region "model"

            /// <summary>
            /// 图片名称
            /// </summary>
            public List<string> PictureName { get; set; }

            /// <summary>
            /// 展示位置行
            /// </summary>
            [Range(10 , 0 )]
            public List<int> Row { get; set; }

            /// <summary>
            /// 展示位置列
            /// </summary>
            [Range(3 , 0 )]
            public List<int> Column { get; set; }

            /// <summary>
            /// 部门名称
            /// </summary>
            public List<string> Department { get; set; }

            /// <summary>
            /// 职能名称
            /// </summary>
            public List<string> Position { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "M_HiringManager";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "M_HiringManager";


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
            public static string MvcTitle = "招聘经理";

        #endregion
    }
}
