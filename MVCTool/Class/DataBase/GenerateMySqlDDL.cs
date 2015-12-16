using System.IO;
using System.Text;

namespace DevKit.MVCTool
{
    public static partial class DDLGenerator
    {
        /// <summary>
        /// MySql
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sqlFilename"></param>
        /// <param name="schema"></param>
        public static void MySql(ModelInfo model, string sqlFilename,string schema)
        {
            // 缩进
            int indent;
            StreamWriter codeWriter = new StreamWriter(sqlFilename, false, Encoding.Unicode);
            StringBuilder code = new StringBuilder();
            //缩进用空格
            char space = " ".ToCharArray()[0];
            //Init
            indent = 0;
            //删除旧表
            code.AppendLine("DROP TABLE IF EXISTS `" + schema + "`.`" + model.ModelName + "`;");
            //建表
            code.AppendLine("CREATE TABLE  `" + schema + "`.`" + model.ModelName + "` (");
            indent += 2;

            //单一主健
            string strkey = string.Empty;

            foreach (var item in model.Items)
            {
                string sql = new string(space, indent) + "`" + item.VarName.Trim() + "`";
                //定义
                switch (item.MetaType)
                {
                    case "整型":
                        sql += " int(" + item.Length + ") ";
                        break;
                    case "字符串":
                        sql += " varchar(" + item.Length + ") ";
                        break;
                    case "布尔值":
                        sql += " tinyint(1) ";
                        break;
                    case "日期":
                        sql += " datetime ";
                        break;
                    default:
                        //枚举类型
                        sql += " smallint(2) ";
                        break;
                }
                if (item.KeyField)
                {
                    //主健（自增主健）
                    sql += " NOT NULL AUTO_INCREMENT,";
                    strkey = item.VarName;
                }
                else
                {
                    if (item.Required)
                    {
                        //必须
                        sql += " NOT NULL,";
                    }
                    else
                    {
                        //默认值
                        if (!string.IsNullOrEmpty(item.DefaultValue))
                        {
                            if (item.MetaType == "字符串")
                            {
                                sql += " DEFAULT '" + item.DefaultValue + "',";
                            }
                            else
                            {
                                sql += " DEFAULT " + item.DefaultValue + ",";
                            }
                        }
                        else
                        {
                            sql += " DEFAULT NULL,";
                        }
                    }
                }
                code.AppendLine(sql);
            }

            //主健
            if (!strkey.Equals(string.Empty))
            {
                code.AppendLine("  PRIMARY KEY (`" + strkey + "`)");
            }
            else {
                code.AppendLine("$$$");
            }
            indent -= 2;
            code.AppendLine(") ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;");
            //无主键时候的最后项目末尾逗号的处理
            codeWriter.Write(code.Replace("," + System.Environment.NewLine + "$$$",""));
            codeWriter.Close();
        }
    }
}
