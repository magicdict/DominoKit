using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevKit.MVCTool
{
    public static partial class ModelGenerator
    {
        /// <summary>
        /// 项目信息
        /// </summary>
        public static ProjectInfo proinfo;

        #region 过滤器列表

        /// <summary>
        /// 日期格式
        /// </summary>
        private const string DateFormat = "[DisplayFormat(DataFormatString = \"{0:yyyy-MM-dd}\",ApplyFormatInEditMode= true)]";

        /// <summary>
        /// 日期型 的过滤器
        /// </summary>
        private const string FilterDateTime = "[FilterItem(MetaStructType = FilterItemAttribute.StructType.Datetime)]";

        /// <summary>
        /// Multi Master 的过滤器
        /// </summary>
        private const string FilterMultiMasterTable = "[FilterItem(MetaType = typeof(@MasterName@), MetaStructType = FilterItemAttribute.StructType.MultiMasterTable)]";
        /// <summary>
        /// Single Master 的过滤器
        /// </summary>
        private const string FilterSingleMasterTable = "[FilterItem(MetaType = typeof(@MasterName@), MetaStructType = FilterItemAttribute.StructType.SingleMasterTable)]";

        /// <summary>
        /// Single MasterTable WithGrade的过滤器
        /// </summary>
        private const string FilterSingleMasterTableWithGrade = "[FilterItem(MetaType = typeof(@MasterName@), MetaStructType = FilterItemAttribute.StructType.SingleMasterTableWithGrade)]";
        /// <summary>
        /// Multi MasterTable WithGrade 的过滤器
        /// </summary>
        private const string FilterMultiMasterTableWithGrade = "[FilterItem(MetaType = typeof(@MasterName@), MetaStructType = FilterItemAttribute.StructType.MultiMasterTableWithGrade)]";

        /// <summary>
        /// Single MasterTable Catalog的过滤器
        /// </summary>
        private const string FilterSingleCatalogMasterTable = "[FilterItem(MetaType = typeof(@MasterName@), CatalogType = typeof(@CatalogName@), MetaStructType = FilterItemAttribute.StructType.SingleCatalogMasterTable)]";
        /// <summary>
        /// Multi MasterTable Catalog 的过滤器
        /// </summary>
        private const string FilterMulitCatalogMasterTable = "[FilterItem(MetaType = typeof(@MasterName@), CatalogType = typeof(@CatalogName@), MetaStructType = FilterItemAttribute.StructType.MultiCatalogMasterTable)]";

        /// <summary>
        /// Multi Enum 的过滤器
        /// </summary>
        private const string FilterMultiEnum = "[FilterItem(MetaType = typeof(@MasterName@), MetaStructType = FilterItemAttribute.StructType.MultiEnum)]";
        /// <summary>
        /// Single Enum 的过滤器
        /// </summary>
        private const string FilterSingleEnum = "[FilterItem(MetaType = typeof(@MasterName@), MetaStructType = FilterItemAttribute.StructType.SingleEnum)]";

        /// <summary>
        /// Boolean 的过滤器
        /// </summary>
        private const string FilterBoolean = "[FilterItem(MetaStructType = FilterItemAttribute.StructType.Boolean)]";

        #endregion

        #region Using列表

        private const string UsingSystem = "using System;";
        private const string UsingComponentModel = "using System.ComponentModel;";
        private const string UsingDataAnnotations = "using System.ComponentModel.DataAnnotations;";
        private const string UsingWebMvc = "using System.Web.Mvc;";
        private const string UsingMongo = "using MongoDB.Bson.Serialization.Attributes;";
        private const string UsingCollections = "using System.Collections.Generic;";
        private const string UsingInfraDataBase = "using InfraStructure.DataBase;";
        private const string UsingFilterSet = "using InfraStructure.FilterSet;";
        private const string UsingInfraTable = "using InfraStructure.Table;";
        private const string UsingBSon = "using MongoDB.Bson;";
        #endregion

        /// <summary>
        /// 生成ModelCode
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        /// <param name="WithAttr"></param>
        public static void GenerateCSharp(string filename, ModelInfo model, bool WithAttr = false)
        {
            List<ModelItem> ModelItems = model.Items;
            //数据操作
            bool NeedComponentModel = false;
            bool NeedDataAnnotations = false;
            bool NeedWebMvc = false;
            bool NeedMongo = false;
            bool NeedList = false;
            // 缩进
            int indent = 0;
            StreamWriter codeWriter = new StreamWriter(filename, false, Encoding.Unicode);
            StringBuilder code = new StringBuilder();
            //缩进用空格
            char space = " ".ToCharArray()[0];

            if (string.IsNullOrEmpty(model.NameSpace))
            {
                code.AppendLine("namespace " + proinfo.NameSpace);
            }
            else
            {
                code.AppendLine("namespace " + model.NameSpace);
            }
            code.AppendLine("{");
            indent += 4;
            //基类设定
            string SuperClass = "EntityBase";
            bool isOrgClass;
            if (!string.IsNullOrEmpty(model.SuperClass))
            {
                SuperClass = model.SuperClass;
            }
            isOrgClass = SuperClass == "EntityBase" || SuperClass == "CacheEntityBase" ||
                         SuperClass == "OwnerTable" ||
                         SuperClass == "MasterTable" ||
                         SuperClass == "StatusMasterTable" ||
                         SuperClass == "CatalogMasterTable";

            //EntityBase ORM用
            code.AppendLine(new string(space, indent) + "/// <summary>");
            code.AppendLine(new string(space, indent) + "/// " + model.Description);
            code.AppendLine(new string(space, indent) + "/// </summary>");
            if (WithAttr) code.AppendLine(new string(space, indent) + "[DisplayName(\"" + model.Description + "\")]");
            code.AppendLine(new string(space, indent) + "public partial class " + model.ModelName + " : " + SuperClass);
            code.AppendLine(new string(space, indent) + "{");
            indent += 4;
            code.AppendLine(new string(space, indent) + "#region \"model\"");
            code.AppendLine(string.Empty);
            //indent += 4;
            foreach (var item in ModelItems)
            {
                //# Skip
                if (item.Flag.Equals("SKIP")) continue;
                code.AppendLine(new string(space, indent) + "/// <summary>");
                code.AppendLine(new string(space, indent) + "/// " + item.DomainName);
                code.AppendLine(new string(space, indent) + "/// </summary>");
                if (WithAttr)
                {
                    if (item.Flag.Equals("HIDDEN"))
                    {
                        //Hidden
                        code.AppendLine(new string(space, indent) + "[HiddenInput]");
                        NeedWebMvc = true;
                    }

                    if (!string.IsNullOrEmpty(item.DisplayName))
                    {
                        //DisplayName
                        code.AppendLine(new string(space, indent) + "[DisplayName(\"" + item.DisplayName + "\")]");
                        NeedComponentModel = true;
                    }
                    if (item.KeyField)
                    {
                        //HiddenInput
                        code.AppendLine(new string(space, indent) + "[HiddenInput]");
                        //数据库的主键（EF用）
                        code.AppendLine(new string(space, indent) + "[Key]");
                        NeedWebMvc = true;
                        NeedDataAnnotations = true;
                    }
                    if (item.Required)
                    {
                        //Required Without Error Message
                        if (!string.IsNullOrEmpty(item.RequiredMessage))
                        {
                            code.AppendLine(new string(space, indent) + "[Required(ErrorMessage = \"" + item.RequiredMessage + "\")]");
                        }
                        else
                        {
                            code.AppendLine(new string(space, indent) + "[Required]");
                        }
                        NeedDataAnnotations = true;
                    }

                    if (item.RangeMin != 0 || item.RangeMax != 0)
                    {
                        string strRange = new string(space, indent) + "[Range(@Min , @Max @ErrorMessage)]";
                        strRange = strRange.Replace("@ErrorMessage", (string.IsNullOrEmpty(item.RangeMessage) ? string.Empty : ", ErrorMessage = \"@ErrorMessage\""));
                        code.AppendLine(strRange.Replace("@Min", item.RangeMin.ToString())
                                                .Replace("@Max", item.RangeMax.ToString())
                                                .Replace("@ErrorMessage", item.RangeMessage));
                        NeedDataAnnotations = true;
                    }

                    if (item.MinLength != 0 || item.MaxLength != 0)
                    {
                        string strLength = string.Empty;
                        if (item.MinLength != 0 && item.MaxLength != 0)
                        {
                            strLength = new string(space, indent) + "[StringLength(@Max , MinimumLength= @Min @ErrorMessage)]";
                        }
                        else
                        {
                            if (item.MinLength != 0)
                            {
                                strLength = new string(space, indent) + "[MinLength(@Min @ErrorMessage)]";
                            }
                            else
                            {
                                strLength = new string(space, indent) + "[MaxLength(@Max @ErrorMessage)]";
                            }
                        }
                        strLength = strLength.Replace("@ErrorMessage", (string.IsNullOrEmpty(item.LengthMessage) ? string.Empty : ", ErrorMessage = \"@ErrorMessage\""));
                        code.AppendLine(strLength.Replace("@Min", item.MinLength.ToString())
                                                 .Replace("@Max", item.MaxLength.ToString())
                                                 .Replace("@ErrorMessage", item.LengthMessage));
                        NeedDataAnnotations = true;
                    }

                    if (!string.IsNullOrEmpty(item.RegularExpress))
                    {
                        string strRange = new string(space, indent) + "[RegularExpression(@\"@express\" @ErrorMessage)]";
                        strRange = strRange.Replace("@ErrorMessage", (string.IsNullOrEmpty(item.RegularMessage) ? string.Empty : ", ErrorMessage = \"@ErrorMessage\""));
                        code.AppendLine(strRange.Replace("@express", item.RegularExpress)
                                                .Replace("@ErrorMessage", item.RegularMessage));
                        NeedDataAnnotations = true;
                    }
                    if (!string.IsNullOrEmpty(item.DataType))
                    {
                        code.AppendLine(new string(space, indent) + GetDataType(item.DataType));
                        NeedDataAnnotations = true;
                    }
                    if (!string.IsNullOrEmpty(item.DisplayFormat))
                    {
                        code.AppendLine(new string(space, indent) + "[DisplayFormat(DataFormatString = \"{0:" + item.DisplayFormat + "}\")]");
                        NeedDataAnnotations = true;
                    }
                }
                //类型
                string strType = string.Empty;

                //特性设定
                switch (item.MetaType)
                {
                    case "日期":
                        strType = Common.CSharp.MetaData[item.MetaType];
                        if (!WithAttr) break;
                        code.AppendLine(new string(space, indent) + FilterDateTime);
                        if (string.IsNullOrEmpty(item.DisplayFormat))
                        {
                            code.AppendLine(new string(space, indent) + DateFormat);
                        }
                        if (proinfo.DataBaseType == Common.EnumAndConst.DataBase.MongoDB)
                        {
                            code.AppendLine(new string(space, indent) + "[BsonDateTimeOptions(Kind = DateTimeKind.Local)]");
                            NeedMongo = true;
                        }
                        break;
                    case "旗标枚举":
                        strType = item.EnumOrMasterType;
                        if (!WithAttr) break;
                        code.AppendLine(new string(space, indent) + "[UIHint(\"EnumFlags\")]");
                        NeedDataAnnotations = true;
                        code.AppendLine(new string(space, indent) + FilterMultiEnum.Replace("@MasterName@", strType));
                        break;
                    case "普通枚举":
                        strType = item.EnumOrMasterType;
                        if (!WithAttr) break;
                        code.AppendLine(new string(space, indent) + "[UIHint(\"Enum\")]");
                        NeedDataAnnotations = true;
                        code.AppendLine(new string(space, indent) + FilterSingleEnum.Replace("@MasterName@", strType));
                        break;
                    case "布尔值":
                        strType = Common.CSharp.MetaData[item.MetaType];
                        if (!WithAttr) break;
                        code.AppendLine(new string(space, indent) + FilterBoolean);
                        strType = Common.CSharp.MetaData[item.MetaType];
                        break;
                    case "辅助表":
                        strType = Common.CSharp.MetaData["字符串"];
                        if (!WithAttr) break;
                        if (!string.IsNullOrEmpty(item.EnumOrMasterType))
                        {
                            if (item.IsList)
                            {
                                code.AppendLine(new string(space, indent) + FilterMultiMasterTable.Replace("@MasterName@", item.EnumOrMasterType));

                            }
                            else
                            {
                                code.AppendLine(new string(space, indent) + FilterSingleMasterTable.Replace("@MasterName@", item.EnumOrMasterType));
                            }
                        }
                        break;
                    case "辅助评价表":
                        strType = "ItemWithGrade";
                        if (!WithAttr) break;
                        if (!string.IsNullOrEmpty(item.EnumOrMasterType))
                        {
                            if (item.IsList)
                            {
                                code.AppendLine(new string(space, indent) + FilterMultiMasterTableWithGrade.Replace("@MasterName@", item.EnumOrMasterType));

                            }
                            else
                            {
                                code.AppendLine(new string(space, indent) + FilterSingleMasterTableWithGrade.Replace("@MasterName@", item.EnumOrMasterType));
                            }
                        }
                        break;
                    case "目录表":
                        strType = Common.CSharp.MetaData["字符串"];
                        if (!WithAttr) break;
                        if (string.IsNullOrEmpty(item.CatalogType))
                        {
                            item.CatalogType = item.EnumOrMasterType + "Catalog";
                        }
                        if (item.IsList)
                        {
                            code.AppendLine(new string(space, indent) +
                                FilterMulitCatalogMasterTable.Replace("@MasterName@", item.EnumOrMasterType)
                                                             .Replace("@CatalogName@", item.CatalogType));

                        }
                        else
                        {
                            code.AppendLine(new string(space, indent) +
                                FilterSingleCatalogMasterTable.Replace("@MasterName@", item.EnumOrMasterType)
                                                              .Replace("@CatalogName@", item.CatalogType));
                        }
                        break;
                    default:
                        //字符，整型
                        strType = Common.CSharp.MetaData[item.MetaType];
                        break;
                }

                if (item.IsList)
                {
                    strType = "List<" + strType + ">";
                    NeedList = true;
                }
                code.AppendLine(new string(space, indent) + "public @type @name { get; set; }"
                    .Replace("@type", strType)
                    .Replace("@name", item.VarName)
                );
                code.AppendLine(string.Empty);
            }

            //*定制
            code.AppendLine(new string(space, indent) + "/// <summary>");
            code.AppendLine(new string(space, indent) + "/// 数据集名称");
            code.AppendLine(new string(space, indent) + "/// </summary>");
            code.AppendLine(new string(space, indent) + "public override string GetCollectionName()");
            code.AppendLine(new string(space, indent) + "{");
            code.AppendLine(new string(space, indent) + "    return \"" + model.CollectionName + "\";");
            code.AppendLine(new string(space, indent) + "}");
            code.AppendLine(string.Empty);

            code.AppendLine(new string(space, indent) + "/// <summary>");
            code.AppendLine(new string(space, indent) + "/// 数据集名称静态字段");
            code.AppendLine(new string(space, indent) + "/// </summary>");
            code.AppendLine(new string(space, indent) + "public static " + (!isOrgClass ? "new " : "") + "string CollectionName = \"" + model.CollectionName + "\";");

            code.AppendLine(string.Empty);

            code.AppendLine(string.Empty);
            code.AppendLine(new string(space, indent) + "/// <summary>");
            code.AppendLine(new string(space, indent) + "/// 数据主键前缀");
            code.AppendLine(new string(space, indent) + "/// </summary>");
            code.AppendLine(new string(space, indent) + "public override string GetPrefix()");
            code.AppendLine(new string(space, indent) + "{");
            if (string.IsNullOrEmpty(model.Prefix))
            {
                code.AppendLine(new string(space, indent) + "    return string.Empty;");
            }
            else
            {
                code.AppendLine(new string(space, indent) + "    return \"" + model.Prefix + "\";");
            }
            code.AppendLine(new string(space, indent) + "}");
            code.AppendLine(string.Empty);

            code.AppendLine(new string(space, indent) + "/// <summary>");
            code.AppendLine(new string(space, indent) + "/// 数据主键前缀静态字段");
            code.AppendLine(new string(space, indent) + "/// </summary>");
            if (string.IsNullOrEmpty(model.Prefix))
            {
                code.AppendLine(new string(space, indent) + "public static " + (!isOrgClass ? "new " : "") + "string Prefix = string.Empty;");
            }
            else
            {
                code.AppendLine(new string(space, indent) + "public static " + (!isOrgClass ? "new " : "") + "string Prefix = \"" + model.Prefix + "\";");
            }
            code.AppendLine(string.Empty);

            code.AppendLine(new string(space, indent) + "/// <summary>");
            code.AppendLine(new string(space, indent) + "/// Mvc画面的标题");
            code.AppendLine(new string(space, indent) + "/// </summary>");
            //静态字段默认不保存，下面的代码注释掉
            //if (proinfo.DataBaseType == Common.EnumAndConst.DataBase.MongoDB)
            //{
            //    code.AppendLine(new string(space, indent) + "[BsonIgnore]");
            //    NeedMongo = true;
            //}
            code.AppendLine(new string(space, indent) + "public static " + (!isOrgClass ? "new " : "") + "string MvcTitle = \"" + model.Description + "\";");
            code.AppendLine(string.Empty);

            //基本数据操作
            if (model.SuperClass == "CacheEntityBase")
            {
                code.AppendLine(new string(space, indent) + "/// <summary>");
                code.AppendLine(new string(space, indent) + "/// 插入" + model.Description);
                code.AppendLine(new string(space, indent) + "/// </summary>");
                code.AppendLine(new string(space, indent) + "/// <param name=\"New@\">".Replace("@", model.ModelName) + model.Description + "</param>");
                code.AppendLine(new string(space, indent) + "public static ObjectId Insert@(@ New@)".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "{");
                code.AppendLine(new string(space, indent) + "    return MongoDbRepository.InsertCacheRec(New@);".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "}");
            }
            else
            {
                code.AppendLine(new string(space, indent) + "/// <summary>");
                code.AppendLine(new string(space, indent) + "/// 按照序列号查找" + model.Description);
                code.AppendLine(new string(space, indent) + "/// </summary>");
                code.AppendLine(new string(space, indent) + "/// <param name=\"Sn\"></param>");
                code.AppendLine(new string(space, indent) + "/// <returns>" + model.Description + "</returns>");
                code.AppendLine(new string(space, indent) + "public static @ Get@BySn(string Sn)".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "{");
                code.AppendLine(new string(space, indent) + "    return MongoDbRepository.GetRecBySN<@>(Sn);".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "}");
                code.AppendLine(string.Empty);

                code.AppendLine(new string(space, indent) + "/// <summary>");
                code.AppendLine(new string(space, indent) + "/// 插入" + model.Description);
                code.AppendLine(new string(space, indent) + "/// </summary>");
                code.AppendLine(new string(space, indent) + "/// <param name=\"New@\"></param>".Replace("@", model.ModelName.ToLower()));
                if (model.SuperClass == "OwnerTable")
                {
                    code.AppendLine(new string(space, indent) + "/// <param name=\"OwnerId\"></param>".Replace("@", model.ModelName.ToLower()));
                }
                code.AppendLine(new string(space, indent) + "/// <returns>序列号</returns>");
                if (model.SuperClass == "OwnerTable")
                {
                    code.AppendLine(new string(space, indent) + "public static string Insert@(@ New@, string OwnerId)".Replace("@", model.ModelName));
                    code.AppendLine(new string(space, indent) + "{");
                    code.AppendLine(new string(space, indent) + "    return OwnerTableOperator.InsertRec(New@, OwnerId);".Replace("@", model.ModelName));
                    code.AppendLine(new string(space, indent) + "}");
                }
                else
                {
                    code.AppendLine(new string(space, indent) + "public static string Insert@(@ New@)".Replace("@", model.ModelName));
                    code.AppendLine(new string(space, indent) + "{");
                    code.AppendLine(new string(space, indent) + "    return MongoDbRepository.InsertRec(New@);".Replace("@", model.ModelName));
                    code.AppendLine(new string(space, indent) + "}");
                }
                code.AppendLine(string.Empty);

                code.AppendLine(new string(space, indent) + "/// <summary>");
                code.AppendLine(new string(space, indent) + "/// 删除" + model.Description);
                code.AppendLine(new string(space, indent) + "/// </summary>");
                code.AppendLine(new string(space, indent) + "/// <param name=\"Drop@\"></param>".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "public static void Drop@(@ Drop@)".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "{");
                code.AppendLine(new string(space, indent) + "    MongoDbRepository.DeleteRec(Drop@);".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "}");
                code.AppendLine(string.Empty);
                code.AppendLine(new string(space, indent) + "/// <summary>");
                code.AppendLine(new string(space, indent) + "/// 修改" + model.Description);
                code.AppendLine(new string(space, indent) + "/// </summary>");
                code.AppendLine(new string(space, indent) + "/// <param name=\"Old@\"></param>".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "public static void Update@(@ Old@)".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "{");
                code.AppendLine(new string(space, indent) + "    MongoDbRepository.UpdateRec(Old@);".Replace("@", model.ModelName));
                code.AppendLine(new string(space, indent) + "}");
            }
 

            //indent -= 4;
            code.AppendLine(string.Empty);
            code.AppendLine(new string(space, indent) + "#endregion");
            indent -= 4;
            code.AppendLine(new string(space, indent) + "}");
            indent -= 4;
            code.AppendLine("}");
            //Using List
            codeWriter.WriteLine(UsingInfraDataBase);
            if (!SuperClass.Equals("EntityBase"))
            {
                codeWriter.WriteLine(UsingInfraTable);
            }
            if (WithAttr) codeWriter.WriteLine(UsingFilterSet);
            if (NeedMongo) codeWriter.WriteLine(UsingMongo);
            codeWriter.WriteLine(UsingSystem);
            if (NeedList) codeWriter.WriteLine(UsingCollections);
            if (NeedComponentModel) codeWriter.WriteLine(UsingComponentModel);
            if (NeedDataAnnotations) codeWriter.WriteLine(UsingDataAnnotations);
            if (NeedWebMvc) codeWriter.WriteLine(UsingWebMvc);
            if (SuperClass == "CacheEntityBase") codeWriter.WriteLine(UsingBSon);
            codeWriter.WriteLine(string.Empty);
            //Entity Code
            codeWriter.Write(code);
            codeWriter.Close();
        }

        /// <summary>
        /// 获得数据类型注解
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
        private static string GetDataType(string DataType)
        {
            //https://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.datatype.aspx

            string strDataType = string.Empty;

            switch (DataType)
            {
                case "密码":
                    strDataType = "[DataType(DataType.Password)]";
                    break;
                case "电子邮件":
                    strDataType = "[DataType(DataType.EmailAddress)]";
                    break;
                case "日期时间":
                    strDataType = "[DataType(DataType.DateTime)]";
                    break;
                case "日期":
                    strDataType = "[DataType(DataType.Date)]";
                    break;
                case "时间":
                    strDataType = "[DataType(DataType.Time)]";
                    break;
                case "手机":
                    strDataType = "[DataType(DataType.PhoneNumber)]";
                    break;
                case "网络地址":
                    strDataType = "[DataType(DataType.Url)]";
                    break;
                default:
                    break;
            }
            return strDataType;
        }

    }
}
