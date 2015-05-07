using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EaiConverter.Model;
using EaiConverter.Parser.Utils;

namespace EaiConverter.Parser
{

    public class XmlParseActivityParser
	{
        public XmlParseActivity Parse (XElement inputElement)
		{
            var xmlParseActivity = new XmlParseActivity ();

			xmlParseActivity.Name = inputElement.Attribute ("name").Value;
            xmlParseActivity.Type = (ActivityType) inputElement.Element (TibcoBWProcessLinqParser.tibcoPrefix + "type").Value;
			var configElement = inputElement.Element ("config");

            xmlParseActivity.XsdReference = configElement.Element("term").Attribute("ref").Value;
			
			// TODO : retrieve the inputbinding


			return xmlParseActivity;
		}
	}

}
