using InfraStructure.DataBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BussinessLogic.Entity
{
    /// <summary>
    /// 招聘经理
    /// </summary>
    public partial class M_HiringManager : MasterTable
    {
        #region "model"

            /// <summary>
            /// 图片名称
            /// </summary>
            [DisplayName("图片名称")]
            public string PictureName { get; set; }

            /// <summary>
            /// 展示位置行
            /// </summary>
            [DisplayName("展示位置行")]
            [Range(0 , 10 )]
            public int Row { get; set; }

            /// <summary>
            /// 展示位置列
            /// </summary>
            [DisplayName("展示位置列")]
            [Range(0 , 3 )]
            public int Column { get; set; }

            /// <summary>
            /// 部门名称
            /// </summary>
            [DisplayName("部门名称")]
            public string Department { get; set; }

            /// <summary>
            /// 职能名称
            /// </summary>
            [DisplayName("职能名称")]
            public string Position { get; set; }

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
