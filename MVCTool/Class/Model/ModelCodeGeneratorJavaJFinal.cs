using System.IO;
using System.Text;

namespace DevKit.MVCTool
{
    public static partial class ModelGenerator
    {
        /// <summary>
        /// JFInal
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        /// <param name="SerialVersionNo"></param>
        public static void GenerateJavaJFinal(string filename, ModelInfo model)
        {
            StreamWriter codeWriter = new StreamWriter(filename, false);
            StringBuilder code = new StringBuilder();
            int indent = 0;
            code.AppendLine("package " + model.NameSpace + ";");
            code.AppendLine(string.Empty);
            //导入java类和JFinal类
            code.AppendLine("import java.util.List;");
            code.AppendLine("import java.util.ArrayList;");
            code.AppendLine("import java.util.Map.Entry;");
            code.AppendLine("import java.util.Map;");
            code.AppendLine("import java.util.HashMap;");
            code.AppendLine("import java.util.Date;");
            code.AppendLine("import java.math.BigDecimal;");
            code.AppendLine("import com.jfinal.plugin.activerecord.Model;");
            //code.AppendLine("import com.jfinal.plugin.activerecord.Page;");
            code.AppendLine(string.Empty);
            // extends Model<LinkType>
            code.AppendLine("public class " + model.ModelName + " extends Model<" + model.ModelName + "> {");
            code.AppendLine(string.Empty);
            indent += 4;
            code.AppendLine(new string(space, indent) + "public static " + model.ModelName + " dao = new " + model.ModelName + "();");
            code.AppendLine(string.Empty);
            //TODO: serialVersionUID
            int SerialVersionNo = 1;
            code.AppendLine(new string(space, indent) + "private static final long serialVersionUID = " + SerialVersionNo + "L;");
            foreach (var item in model.Items)
            {
                if (item.MetaType.Contains("枚举") || item.MetaType.EndsWith("表")) continue;
                if (!string.IsNullOrEmpty(item.DomainName))
                {
                    InsertJavaComment(code, item.DomainName, indent);
                }
                else
                {
                    InsertJavaComment(code, item.VarName, indent);
                }

                //由于要和Null做判断，以下是用类型名称 int =〉 Integer
                string strMetaDataWrapType = (!string.IsNullOrEmpty(item.EnumOrMasterType) ? item.EnumOrMasterType : Common.Java.MetaDataWrapType[item.MetaType]);
                //数据库列名称：这个字符串区分大小写，一定要匹配数据库里面的列名称
                //public static final String KEY_ID = "id";
                code.AppendLine(new string(space, indent) + "public static final String KEY_@uppername = \"@name\";"
                                .Replace("@uppername", item.VarName.ToUpper())
                                .Replace("@name", item.VarName)
                );
                
                //Set
                InsertJavaMethodComment(code, "设定" + item.VarName, indent, string.Empty, string.Empty);
                code.AppendLine(new string(space, indent) + "public void set@name(@type @name){"
                                .Replace("@type", strMetaDataWrapType)
                                .Replace("@name", item.VarName)
                );
                indent += 4;
                code.AppendLine(new string(space, indent) + "set(KEY_@uppername, @name);"
                                .Replace("@uppername", item.VarName.ToUpper())
                                .Replace("@name", item.VarName)
                );
                indent -= 4;
                code.AppendLine(new string(space, indent) + "}");

                //Get
                InsertJavaMethodComment(code, "获得" + item.VarName, indent, string.Empty, string.Empty);
                if (strMetaDataWrapType == "Boolean")
                {
                    //布尔型使用 isXXXX()
                    code.AppendLine(new string(space, indent) + "public @type is@name(){"
                          .Replace("@type", strMetaDataWrapType)
                          .Replace("@name", item.VarName)
                        );
                }
                else
                {
                    code.AppendLine(new string(space, indent) + "public @type get@name(){"
                      .Replace("@type", strMetaDataWrapType)
                      .Replace("@name", item.VarName)
                    );
                }

                indent += 4;

                switch (strMetaDataWrapType)
                {
                    case "Integer":
                        code.AppendLine(new string(space, indent) + "return getInt(KEY_@uppername);"
                                        .Replace("@uppername", item.VarName.ToUpper())
                        );
                        break;
                    case "String":
                        code.AppendLine(new string(space, indent) + "return getStr(KEY_@uppername);"
                                      .Replace("@uppername", item.VarName.ToUpper())
                        );
                        break;
                    default:
                        code.AppendLine(new string(space, indent) + "return get@type(KEY_@uppername);"
                                      .Replace("@type", strMetaDataWrapType)
                                      .Replace("@uppername", item.VarName.ToUpper())
                        );
                        break;
                }

                indent -= 4;
                code.AppendLine(new string(space, indent) + "}");

                code.AppendLine(string.Empty);
            }

            //Select * from
            InsertJavaComment(code, "数据表名称", indent);
            code.AppendLine(new string(space, indent) + "public static String TableName = \"" + proinfo.DataBaseSchema + "." + model.ModelName + "\";");
            code.AppendLine(string.Empty);

            InsertJavaMethodComment(code, "获得所有数据", indent, string.Empty, "List < " + model.ModelName + " >");
            code.AppendLine(new string(space, indent) + "public static List<" + model.ModelName + "> findAllList(){");
            indent += 4;
            code.AppendLine(new string(space, indent) + "return dao.find(\"select * from \" + TableName);");
            indent -= 4;
            code.AppendLine(new string(space, indent) + " }");

            code.AppendLine(string.Empty);
            //http://my.oschina.net/myaniu/blog/141475?fromerr=qG9d8I6E
            //http://my.oschina.net/myaniu/blog/137065?fromerr=IH6gpdFT
            InsertJavaMethodComment(code, "获得指定条件数据", indent, string.Empty, "List < " + model.ModelName + " >");
            code.AppendLine(new string(space, indent) + "public static List<" + model.ModelName + "> findByExample(" + model.ModelName + " " + model.ModelName.ToLower() + "){");
            indent += 4;
            code.AppendLine(new string(space, indent) + "Map <String, Object> conds= new HashMap <String, Object>();");
            foreach (var item in model.Items)
            {
                code.AppendLine(new string(space, indent) + "//如果设置了" + item.VarName);
                //if (linkType.getId() != null)
                //{
                //    conds.put(KEY_ID, linkType.getId());
                //}
                code.AppendLine(new string(space, indent) + "if (" + model.ModelName.ToLower() + ".get" + item.VarName + "() != null)");
                code.AppendLine(new string(space, indent) + "{");
                indent += 4;
                code.AppendLine(new string(space, indent) + "conds.put(KEY_@uppername, ".Replace("@uppername", item.VarName.ToUpper()) + model.ModelName.ToLower() + ".get" + item.VarName + "());");
                indent -= 4;
                code.AppendLine(new string(space, indent) + "}");
            }
            code.AppendLine(new string(space, indent) + "return search(conds);");
            indent -= 4;
            code.AppendLine(new string(space, indent) + "}");
            code.AppendLine(string.Empty);
            InsertJavaMethodComment(code, "获得指定条件数据", indent, string.Empty, "List < " + model.ModelName + " >");
            code.AppendLine(new string(space, indent) + "public static List<" + model.ModelName + "> search(Map<String, Object> maps)");
            code.AppendLine(new string(space, indent) + "{");
            code.AppendLine(new string(space, indent) + "    return search(maps, \"\");");
            code.AppendLine(new string(space, indent) + "}");
            code.AppendLine(string.Empty);
            InsertJavaMethodComment(code, "获得指定条件数据", indent, string.Empty, "List < " + model.ModelName + " >");
            code.AppendLine(new string(space, indent) + "public static List<" + model.ModelName + "> search(Map<String, Object> maps, String orderBy)");
            code.AppendLine(new string(space, indent) + "{");
            code.AppendLine(new string(space, indent) + "    StringBuilder sb = new StringBuilder();");
            code.AppendLine(new string(space, indent) + "    sb.append(\"select * from \").append(TableName).append(\" where 1=1 \");");
            code.AppendLine(new string(space, indent) + "    List<Object> values = new ArrayList<Object>();");
            code.AppendLine(new string(space, indent) + "    for (Entry<String, Object> entry:maps.entrySet())");
            code.AppendLine(new string(space, indent) + "    {");
            code.AppendLine(new string(space, indent) + "        if (entry.getValue() != null)");
            code.AppendLine(new string(space, indent) + "        {");
            code.AppendLine(new string(space, indent) + "            sb.append(\" and \").append(entry.getKey()).append(\"=?\");");
            code.AppendLine(new string(space, indent) + "            values.add(entry.getValue());");
            code.AppendLine(new string(space, indent) + "        }");
            code.AppendLine(new string(space, indent) + "    }");
            code.AppendLine(new string(space, indent) + "    sb.append(\" \").append(orderBy);");
            code.AppendLine(new string(space, indent) + "    return dao.find(sb.toString(), values.toArray());");
            code.AppendLine(new string(space, indent) + "}");

            indent -= 4;
            code.AppendLine("}");
            codeWriter.Write(code);
            codeWriter.Close();
        }
    }
}
