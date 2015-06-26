using System.Xml;

namespace DevKit.MVCTool
{
    public static partial class ModelGenerator
    {
        public static void GenerateJavaStruct2(string filename, ModelInfo model)
        {
            XmlDocument validators = new XmlDocument();
            //validators.CreateDocumentType("validators", "PUBLIC", @"http://www.opensymphony.com/xwork/xwork-validator-1.0.2.dtd", "");
            XmlNode validatorsItem = validators.CreateElement("validators");
            foreach (var item in model.Items)
            {
                XmlNode itemNode = validators.CreateElement("field");
                ((XmlElement)itemNode).SetAttribute("name", item.VarName);

                //必须输入项目
                if (item.Required)
                {
                    XmlNode RequiredNode = validators.CreateElement("field-validator");
                    ((XmlElement)RequiredNode).SetAttribute("field-validator", "requiredstring");

                    XmlNode RequiredMessageNode = validators.CreateElement("message");
                    ((XmlElement)RequiredMessageNode).SetAttribute("key", item.RequiredMessage);
                    RequiredNode.AppendChild(RequiredMessageNode);

                    itemNode.AppendChild(RequiredNode);
                }

                //正则表达式
                if (!string.IsNullOrEmpty(item.RegularExpress))
                {
                    XmlNode regexNode = validators.CreateElement("field-validator");
                    ((XmlElement)regexNode).SetAttribute("field-validator", "regex");

                    XmlNode regexExpressParmMessageNode = validators.CreateElement("param");
                    ((XmlElement)regexExpressParmMessageNode).SetAttribute("expression", item.RegularExpress);
                    regexNode.AppendChild(regexExpressParmMessageNode);

                    XmlNode regexMessageNode = validators.CreateElement("message");
                    ((XmlElement)regexMessageNode).SetAttribute("key", item.RegularMessage);
                    regexNode.AppendChild(regexMessageNode);

                    itemNode.AppendChild(regexNode);

                }
                validatorsItem.AppendChild(itemNode);
            }
            validators.AppendChild(validatorsItem);
            validators.Save(filename);
        }
    }
}
