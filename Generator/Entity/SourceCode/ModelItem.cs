using InfraStructure;
using InfraStructure.FilterSet;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCTool
{
    /// <summary>
    /// 字段定义
    /// </summary>
    [DisplayName("字段定义")]
    public partial class ModelItem : CompanyTable
    {
        #region "model"

            /// <summary>
            /// 模型名称
            /// </summary>
            [HiddenInput]
            [DisplayName("模型名称")]
            [Required]
            public string ModelInfoCode { get; set; }

            /// <summary>
            /// 标示位
            /// </summary>
            [DisplayName("标示位")]
            [FilterItem(MetaType = typeof(M_Flag), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string Flag { get; set; }

            /// <summary>
            /// 领域名
            /// </summary>
            [DisplayName("领域名")]
            [Required]
            public string DomainName { get; set; }

            /// <summary>
            /// 变量名称
            /// </summary>
            [DisplayName("变量名称")]
            [Required]
            public string VarName { get; set; }

            /// <summary>
            /// 数据类型
            /// </summary>
            [DisplayName("数据类型")]
            [Required]
            [FilterItem(MetaType = typeof(M_MetaData), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string MetaType { get; set; }

            /// <summary>
            /// 辅助/枚举
            /// </summary>
            [DisplayName("辅助/枚举")]
            [FilterItem(MetaType = typeof(M_MasterEnum), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string EnumOrMasterType { get; set; }

            /// <summary>
            /// 目录类型
            /// </summary>
            [DisplayName("目录类型")]
            [FilterItem(MetaType = typeof(M_MasterEnum), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string CatalogType { get; set; }

            /// <summary>
            /// 是否为列表
            /// </summary>
            [DisplayName("是否为列表")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool IsList { get; set; }

            /// <summary>
            /// 显示名称
            /// </summary>
            [DisplayName("显示名称")]
            public string DisplayName { get; set; }

            /// <summary>
            /// 关键字项目
            /// </summary>
            [DisplayName("关键字项目")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool KeyField { get; set; }

            /// <summary>
            /// 长度
            /// </summary>
            [DisplayName("长度")]
            public int Length { get; set; }

            /// <summary>
            /// 默认值
            /// </summary>
            [DisplayName("默认值")]
            public string DefaultValue { get; set; }

            /// <summary>
            /// 必须项目
            /// </summary>
            [DisplayName("必须项目")]
            [FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]
            public bool Required { get; set; }

            /// <summary>
            /// 必须项目错误信息
            /// </summary>
            [DisplayName("必须项目错误信息")]
            public string RequiredMessage { get; set; }

            /// <summary>
            /// 最小值
            /// </summary>
            [DisplayName("最小值")]
            public int RangeMin { get; set; }

            /// <summary>
            /// 最大值
            /// </summary>
            [DisplayName("最大值")]
            public int RangeMax { get; set; }

            /// <summary>
            /// 范围错误
            /// </summary>
            [DisplayName("范围错误")]
            public string RangeMessage { get; set; }

            /// <summary>
            /// 最小文字列长度
            /// </summary>
            [DisplayName("最小文字列长度")]
            public int MinLength { get; set; }

            /// <summary>
            /// 最大文字列长度
            /// </summary>
            [DisplayName("最大文字列长度")]
            public int MaxLength { get; set; }

            /// <summary>
            /// 文字列长度错误信息
            /// </summary>
            [DisplayName("文字列长度错误信息")]
            public string LengthMessage { get; set; }

            /// <summary>
            /// 正则表达式
            /// </summary>
            [DisplayName("正则表达式")]
            public string RegularExpress { get; set; }

            /// <summary>
            /// 正则表达式错误信息
            /// </summary>
            [DisplayName("正则表达式错误信息")]
            public string RegularMessage { get; set; }

            /// <summary>
            /// 数据类型
            /// </summary>
            [DisplayName("数据类型")]
            [FilterItem(MetaType = typeof(M_DataUsage), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]
            public string DataType { get; set; }

            /// <summary>
            /// 数据表示格式
            /// </summary>
            [DisplayName("数据表示格式")]
            public string DisplayFormat { get; set; }

            /// <summary>
            /// 数据集名称
            /// </summary>
            public override string GetCollectionName()
            {
                return "ModelItem";
            }

            /// <summary>
            /// 数据集名称静态字段
            /// </summary>
            public static string CollectionName = "ModelItem";


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
            public static string MvcTitle = "字段定义";

        #endregion
    }
}
