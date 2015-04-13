using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Misc.Models
{
    public class Candidate
    {
        #region "model"

            /// <summary>
            /// 个数
            /// </summary>
            [DisplayName("个数")]
            [HiddenInput]
            public int No { get; set; }

            /// <summary>
            /// 招聘职位
            /// </summary>
            [DisplayName("招聘职位")]
            [Required(ErrorMessage = "招聘职位是必须信息")]
            public string Position { get; set; }

            /// <summary>
            /// 名字
            /// </summary>
            [DisplayName("名字")]
            [Required(ErrorMessage = "名字是必须信息")]
            public string Name { get; set; }

            /// <summary>
            /// 联系方式
            /// </summary>
            [DisplayName("联系方式")]
            [Required(ErrorMessage = "联系方式是必须信息")]
            public string Contact { get; set; }

            /// <summary>
            /// 语言
            /// </summary>
            [DisplayName("语言")]
            [Required(ErrorMessage = "语言是必须信息")]
            [UIHint("FlagsEnum")]
            public Language.LanguageEnum Language { get; set; }

            /// <summary>
            /// 大学
            /// </summary>
            [DisplayName("大学")]
            [Required(ErrorMessage = "大学是必须信息")]
            public string University { get; set; }

            /// <summary>
            /// 专业
            /// </summary>
            [DisplayName("专业")]
            [Required(ErrorMessage = "专业是必须信息")]
            public string Major  { get; set; }

            /// <summary>
            /// 市场背景
            /// </summary>
            [DisplayName("市场背景")]
            public bool MarketBackground { get; set; }

            /// <summary>
            /// 技术背景
            /// </summary>
            [DisplayName("技术背景")]
            public bool ITBackground { get; set; }

            /// <summary>
            /// 备注
            /// </summary>
            [DisplayName("备注")]
            public string Comments { get; set; }

        #endregion
    }
}
