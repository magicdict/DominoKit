using System.IO;
using System.Text;

namespace DevKit.MVCTool
{
    public static partial class ModelGenerator
    {
        /// <summary>
        /// 生成ModelCode
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        public static void GenerateJavaSpring(string filename, ModelInfo model)
        {
            StreamWriter codeWriter = new StreamWriter(filename, false);
            StringBuilder code = new StringBuilder();
            //缩进用空格
            char space = " ".ToCharArray()[0];
            int indent = 0;
            code.AppendLine("package " + model.NameSpace + ";");
            code.AppendLine(string.Empty);
            //Hibernate实现验证
            code.AppendLine("import org.hibernate.validator.constraints.*;");
            code.AppendLine(string.Empty);
            code.AppendLine("public class " + model.ModelName + " {");
            code.AppendLine(string.Empty);
            indent += 4;
            foreach (var item in model.Items)
            {
                if (!string.IsNullOrEmpty(item.DisplayName))
                {
                    code.AppendLine(new string(space, indent) + "//" + item.DisplayName);
                }
                else
                {
                    code.AppendLine(new string(space, indent) + "//" + item.VarName);
                }

                //验证注解
                //必须
                if (item.Required)
                {
                    if (!string.IsNullOrEmpty(item.RequiredMessage))
                    {
                        code.AppendLine(new string(space, indent) + "@NotEmpty(message = \"" + item.RequiredMessage + "\")");
                    }
                    else
                    {
                        code.AppendLine(new string(space, indent) + "@NotEmpty");
                    }
                }
                //范围
                if (item.RangeMin != 0 || item.RangeMax != 0)
                {
                    string strRange = new string(space, indent) + " @Range(min = @Min, max = @Max @ErrorMessage )";
                    strRange = strRange.Replace("@ErrorMessage", (string.IsNullOrEmpty(item.RangeMessage) ? string.Empty : ", message = \"@ErrorMessage\""));
                    code.AppendLine(strRange.Replace("@Min", item.RangeMin.ToString())
                                            .Replace("@Max", item.RangeMax.ToString())
                                            .Replace("@ErrorMessage", item.RangeMessage));
                }
                //字符长度
                if (item.MinLength != 0 || item.MaxLength != 0)
                {
                    string strLength = new string(space, indent) + " @Length(min = @Min, max = @Max @ErrorMessage )";
                    strLength = strLength.Replace("@ErrorMessage", (string.IsNullOrEmpty(item.LengthMessage) ? string.Empty : ", ErrorMessage = \"@ErrorMessage\""));
                    code.AppendLine(strLength.Replace("@Min", item.MinLength.ToString())
                                             .Replace("@Max", item.MaxLength.ToString())
                                             .Replace("@ErrorMessage", item.LengthMessage));
                }
                //正则表达
                if (!string.IsNullOrEmpty(item.RegularExpress))
                {
                    string strRange = new string(space, indent) + "@Pattern(regex = @express @ErrorMessage )";
                    strRange = strRange.Replace("@ErrorMessage", (string.IsNullOrEmpty(item.RegularMessage) ? string.Empty : ", ErrorMessage = \"@ErrorMessage\""));
                    code.AppendLine(strRange.Replace("@express", item.RegularExpress)
                                            .Replace("@ErrorMessage", item.RegularMessage));
                }
                string strMetaType = (!string.IsNullOrEmpty(item.EnumOrMasterType) ? item.EnumOrMasterType : Common.Java.MetaData[item.MetaType]);
                //Define
                code.AppendLine(new string(space, indent) + "private @type @name ;"
                                .Replace("@type", strMetaType)
                                .Replace("@name", item.VarName)
                );
                //Set
                code.AppendLine(new string(space, indent) + "public void set@name(@type @name){"
                                .Replace("@type", strMetaType)
                                .Replace("@name", item.VarName)
                );
                indent += 4;
                code.AppendLine(new string(space, indent) + "this.@name = @name;"
                               .Replace("@type", strMetaType)
                               .Replace("@name", item.VarName)
                );
                indent -= 4;
                code.AppendLine(new string(space, indent) + "}");
                //Get
                code.AppendLine(new string(space, indent) + "public @type get@name(){"
                              .Replace("@type", strMetaType)
                              .Replace("@name", item.VarName)
                );
                indent += 4;
                code.AppendLine(new string(space, indent) + "return this.@name;"
                               .Replace("@name", item.VarName)
                );
                indent -= 4;
                code.AppendLine(new string(space, indent) + "}");

                code.AppendLine(string.Empty);
            }
            indent -= 4;
            code.AppendLine("}");
            codeWriter.Write(code);
            codeWriter.Close();
        }
    }
}
