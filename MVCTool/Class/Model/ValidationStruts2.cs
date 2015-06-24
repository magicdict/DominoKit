using System.Xml;

namespace DevKit.MVCTool
{
    public class ValidationStruts2
    {
        /// <summary>
        /// 
        /// </summary>
        private static string dtdLink = "http://www.opensymphony.com/xwork/xwork-validator-1.0.2.dtd";
        /// <summary>
        /// 
        /// </summary>
        private static string dtdDef = "-//OpenSymphony Group//XWork Validator 1.0.2//EN";
        /// <summary>
        /// 生成验证用XML文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="model"></param>
        /// <param name="ModelItems"></param>
        public static void GenerateValidation(string filename, ModelInfo model)
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
                    message.SetAttribute("key", item.RequiredMessage);
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
