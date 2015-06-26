using System.Xml;

namespace DevKit.MVCTool
{
    public class ValidationStruts2
    {
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
        public static void GenerateValidation(string filename, ModelInfo model,bool isConfigMessage = false)
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
                    else {
                        message.InnerText = item.RequiredMessage;
                    }
                    field_validator.AppendChild(message);
                    field.AppendChild(field_validator);
                    has_validator = true;
                }
                if (item.RangeMin != 0 || item.RangeMax != 0) {
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
                if (has_validator) root.AppendChild(field);
            }
            //把根节点添加到xml文档里
            myXmlDoc.AppendChild(root);
            myXmlDoc.Save(filename);
        }

    }
}
