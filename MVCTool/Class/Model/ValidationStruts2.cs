using System.Xml;

namespace DevKit.MVCTool
{
    public class ValidationStruts2
    {

        //Struts2.0 注册的验证器类型

        //< validators > 
        //    < validator name = "required" class ="com.opensymphony.xwork2.validator.validators.RequiredFieldValidator" /> 
        //    < validator name = "requiredstring" class ="com.opensymphony.xwork2.validator.validators.RequiredStringValidator" /> 
        //    < validator name = "int" class ="com.opensymphony.xwork2.validator.validators.IntRangeFieldValidator" /> 
        //    < validator name = "double" class ="com.opensymphony.xwork2.validator.validators.DoubleRangeFieldValidator" /> 
        //    < validator name = "date" class ="com.opensymphony.xwork2.validator.validators.DateRangeFieldValidator" /> 
        //    < validator name = "expression" class ="com.opensymphony.xwork2.validator.validators.ExpressionValidator" /> 
        //    < validator name = "fieldexpression" class ="com.opensymphony.xwork2.validator.validators.FieldExpressionValidator" /> 
        //    < validator name = "email" class ="com.opensymphony.xwork2.validator.validators.EmailValidator" /> 
        //    < validator name = "url" class ="com.opensymphony.xwork2.validator.validators.URLValidator" /> 
        //    < validator name = "visitor" class ="com.opensymphony.xwork2.validator.validators.VisitorFieldValidator" /> 
        //    < validator name = "conversion" class ="com.opensymphony.xwork2.validator.validators.ConversionErrorFieldValidator" /> 
        //    < validator name = "stringlength" class ="com.opensymphony.xwork2.validator.validators.StringLengthFieldValidator" /> 
        //    < validator name = "regex" class ="com.opensymphony.xwork2.validator.validators.RegexFieldValidator" /> 
        //</ validators >


        /// <summary>
        /// DTD Link
        /// </summary>
        private static string dtdLink = "http://struts.apache.org/dtds/xwork-validator-1.0.2.dtd";
        //private static string dtdLink = "http://www.opensymphony.com/xwork/xwork-validator-1.0.2.dtd";
        /// <summary>
        /// DTD Def
        /// </summary>
        private static string dtdDef = "-//OpenSymphony Group//XWork Validator 1.0.2//EN";
        /// <summary>
        /// 生成验证用XML文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        /// <param name="isConfigMessage"></param>
        public static void GenerateValidation(string filename, ModelInfo model, bool isConfigMessage = false)
        {
            //初始化一个xml实例 
            XmlDocument myXmlDoc = new XmlDocument();
            myXmlDoc.XmlResolver = null;
            // 添加文档定义        
            myXmlDoc.AppendChild(myXmlDoc.CreateXmlDeclaration("1.0", "utf-8", ""));
            myXmlDoc.AppendChild(myXmlDoc.CreateDocumentType("validators", dtdDef, dtdLink, null));
            //生成根节点
            XmlElement root = myXmlDoc.CreateElement("validators");
            foreach (var item in model.Items)
            {
                var field = myXmlDoc.CreateElement("field");
                field.SetAttribute("name", item.VarName);
                bool has_validator = false;
                //内置必须项目验证器
                if (item.Required)
                {
                    //必须项目
                    //<field-validator type="requiredstring">  
                    var field_validator = myXmlDoc.CreateElement("field-validator");
                    field_validator.SetAttribute("type", "requiredstring");
                    var message = myXmlDoc.CreateElement("message");
                    if (isConfigMessage)
                    {
                        message.SetAttribute("key", item.RequiredMessage);
                    }
                    else
                    {
                        message.InnerText = item.RequiredMessage;
                    }
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }

                //内置整型验证器
                if (item.RangeMin != 0 || item.RangeMax != 0)
                {
                    var field_validator = myXmlDoc.CreateElement("field-validator");
                    field_validator.SetAttribute("type", "int");

                    var min = myXmlDoc.CreateElement("param");
                    min.SetAttribute("name", "min");
                    min.InnerText = item.RangeMin.ToString();

                    var max = myXmlDoc.CreateElement("param");
                    max.SetAttribute("name", "max");
                    max.InnerText = item.RangeMax.ToString();

                    var message = myXmlDoc.CreateElement("message");
                    if (isConfigMessage)
                    {
                        message.SetAttribute("key", item.RangeMessage);
                    }
                    else
                    {
                        message.InnerText = item.RangeMessage;
                    }
                    field_validator.AppendChild(min);
                    field_validator.AppendChild(max);
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }

                //内置字符长度验证器
                if (item.MinLength != 0 || item.MaxLength != 0)
                {
                    var field_validator = myXmlDoc.CreateElement("field-validator");
                    field_validator.SetAttribute("type", "stringlength");

                    var min = myXmlDoc.CreateElement("param");
                    min.SetAttribute("name", "minLength");
                    min.InnerText = item.RangeMin.ToString();

                    var max = myXmlDoc.CreateElement("param");
                    max.SetAttribute("name", "maxLength");
                    max.InnerText = item.RangeMax.ToString();

                    var message = myXmlDoc.CreateElement("message");
                    if (isConfigMessage)
                    {
                        message.SetAttribute("key", item.LengthMessage);
                    }
                    else
                    {
                        message.InnerText = item.LengthMessage;
                    }
                    field_validator.AppendChild(min);
                    field_validator.AppendChild(max);
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }
                
                //内置正则表达式验证器
                if (!string.IsNullOrEmpty(item.RegularExpress))
                {
                    var field_validator = myXmlDoc.CreateElement("field-validator");
                    field_validator.SetAttribute("type", "regex");


                    var regex = myXmlDoc.CreateElement("param");
                    regex.SetAttribute("name", "expression");
                    regex.AppendChild(myXmlDoc.CreateCDataSection(item.RegularExpress.ToString()));

                    var message = myXmlDoc.CreateElement("message");
                    if (isConfigMessage)
                    {
                        message.SetAttribute("key", item.RegularMessage);
                    }
                    else
                    {
                        message.InnerText = item.RegularMessage;
                    }
                    field_validator.AppendChild(regex);
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }

                //内置电子邮件验证器
                if (item.DataType == "电子邮件")
                {
                    var field_validator = myXmlDoc.CreateElement("field-validator");
                    field_validator.SetAttribute("type", "email");
                    var message = myXmlDoc.CreateElement("message");
                    if (isConfigMessage)
                    {
                        message.SetAttribute("key", item.RegularMessage);
                    }
                    else
                    {
                        message.InnerText = item.RegularMessage;
                    }
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }

                //内置URL验证器
                if (item.DataType == "网络地址")
                {
                    var field_validator = myXmlDoc.CreateElement("field-validator");
                    field_validator.SetAttribute("type", "url");
                    var message = myXmlDoc.CreateElement("message");
                    if (isConfigMessage)
                    {
                        message.SetAttribute("key", item.RegularMessage);
                    }
                    else
                    {
                        message.InnerText = item.RegularMessage;
                    }
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }
                if (has_validator) root.AppendChild(field);
            }
            //把根节点添加到xml文档里
            myXmlDoc.AppendChild(root);
            myXmlDoc.Save(filename);
        }

    }
}
