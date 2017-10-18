namespace AllycsPointRuler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    public static class RulersXmlUtil
    {
        public static void GetRulersDic(string fileName = "BaseRule.xml")
        {
            if (!File.Exists(fileName))
                return;
            PointConfigInfo.Rulers.Clear();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNode root = xmlDoc.SelectSingleNode("ROOT");

            XmlNodeList xnl = root.ChildNodes;
            foreach (XmlNode xnINOROUT in xnl)
            {
                var PointRulerDic = new Dictionary<string, PointRuler>();
                foreach (var xnRULES in xnINOROUT.ChildNodes)
                {
                    var element = xnRULES as XmlElement;
                    var ruler = new PointRuler();
                    if (element.GetElementsByTagName("ISONLY").Count != 0)
                        ruler.IsOnly = Convert.ToBoolean(element.GetElementsByTagName("ISONLY")[0].InnerText.Trim());
                    if (element.GetElementsByTagName("WEIGHT").Count != 0)
                        ruler.Weight = Math.Abs(Convert.ToInt32(element.GetElementsByTagName("WEIGHT")[0].InnerText.Trim()));
                    if (element.GetElementsByTagName("AMOUNT").Count != 0)
                        ruler.Amount = Math.Abs(Convert.ToInt32(element.GetElementsByTagName("AMOUNT")[0].InnerText.Trim()));
                    if (element.GetElementsByTagName("POINT").Count != 0)
                        ruler.Point = Math.Abs(Convert.ToInt32(element.GetElementsByTagName("POINT")[0].InnerText.Trim()));
                    if (element.GetElementsByTagName("MULTIPLE").Count != 0)
                        ruler.Multiple = Math.Abs(Convert.ToInt32(element.GetElementsByTagName("MULTIPLE")[0].InnerText.Trim()));
                    if (element.GetElementsByTagName("PLUSORMINUS").Count != 0)
                        ruler.PlusOrMinus = Convert.ToBoolean(element.GetElementsByTagName("PLUSORMINUS")[0].InnerText.Trim());
                    if (element.GetElementsByTagName("DESCRIPTION").Count != 0)
                        ruler.Description = element.GetElementsByTagName("DESCRIPTION")[0].InnerText.Trim();
                    if (element.GetElementsByTagName("DEDUCTION").Count != 0)
                        ruler.Deduction = Convert.ToBoolean(element.GetElementsByTagName("DEDUCTION")[0].InnerText.Trim());
                    PointRulerDic.Add(element.Name, ruler);
                }
                PointConfigInfo.Rulers.Add(xnINOROUT.Name, PointRulerDic);
            }
        }

        public static RuleXmlCode AddNewRuleXml(string fileName, Stream stream)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            if (!fs.CanWrite)
                return RuleXmlCode.CANNOTWRITE;
            StreamWriter sw = new StreamWriter(fs);
            stream.CopyTo(sw.BaseStream);
            sw.Flush();
            sw.Close();
            fs.Close();
            if (!TextGauge(fileName))
                return RuleXmlCode.OUTOFGAUGE;
            return RuleXmlCode.SUCCESS;
        }

        public static bool TextGauge(string fileName)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlNode root = xmlDoc.SelectSingleNode("ROOT");
                XmlNodeList xnl = root.ChildNodes;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public enum RuleXmlCode
    {
        SUCCESS = 0,
        CANNOTWRITE = 10,
        OUTOFGAUGE = 20
    }
}