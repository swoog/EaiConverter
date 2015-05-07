using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EaiConverter.Model;
using EaiConverter.Parser.Utils;

namespace EaiConverter.Parser
{

	public class JdbcQueryActivityParser
	{
        public JdbcQueryActivity Parse (XElement inputElement)
		{
            var jdbcQueryActivity = new JdbcQueryActivity ();

			jdbcQueryActivity.Name = inputElement.Attribute ("name").Value;
            jdbcQueryActivity.Type = (ActivityType) inputElement.Element (TibcoBWProcessLinqParser.tibcoPrefix + "type").Value;
			var configElement = inputElement.Element ("config");

			jdbcQueryActivity.TimeOut = XElementParserUtils.GetIntValue(configElement.Element("timeout"));
			jdbcQueryActivity.Commit = XElementParserUtils.GetBoolValue(configElement.Element("commit"));
			jdbcQueryActivity.MaxRows = XElementParserUtils.GetIntValue(configElement.Element("maxRows"));
			jdbcQueryActivity.EmptyStringAsNull = XElementParserUtils.GetBoolValue(configElement.Element("emptyStrAsNil"));
			jdbcQueryActivity.JdbcSharedConfig = XElementParserUtils.GetStringValue(configElement.Element("jdbcSharedConfig"));
            if (jdbcQueryActivity.Type == ActivityType.jdbcCallActivityType) {
				jdbcQueryActivity.QueryStatement = XElementParserUtils.GetStringValue (configElement.Element ("ProcedureName"));
				// TODO : faut il enlever le ;1 à la fin ? je dirai que oui, à moins que cela donne la position du return dans la liste en dessous..bizarre
				jdbcQueryActivity.QueryStatement = jdbcQueryActivity.QueryStatement.Remove (jdbcQueryActivity.QueryStatement.LastIndexOf (';'), 2);

				var preparedParamDataTypeElement = configElement.Element ("parameterTypes");
				jdbcQueryActivity.QueryStatementParameters = new Dictionary <string, string> ();

				var parameterElements = preparedParamDataTypeElement.Elements ("parameter");
				foreach (var parameterElement in parameterElements) {

					string parameterName = XElementParserUtils.GetStringValue(parameterElement.Element ("colName"));
					parameterName = parameterName.Substring (1, parameterName.Length-1);
					jdbcQueryActivity.QueryStatementParameters.Add(
							parameterName,
						XElementParserUtils.GetStringValue(parameterElement.Element ("typeName"))
					);
				}
			} else {
				jdbcQueryActivity.QueryStatement = XElementParserUtils.GetStringValue (configElement.Element ("statement"));

				var preparedParamDataTypeElement = configElement.Element ("Prepared_Param_DataType");
				jdbcQueryActivity.QueryStatementParameters = new Dictionary <string, string> ();

				var parameterElements = preparedParamDataTypeElement.Elements ("parameter");
				foreach (var parameterElement in parameterElements) {
					jdbcQueryActivity.QueryStatementParameters.Add(
						XElementParserUtils.GetStringValue(parameterElement.Element ("parameterName")),
						XElementParserUtils.GetStringValue(parameterElement.Element ("dataType"))
					);
				}
			}



			jdbcQueryActivity.QueryOutputCachedSchemaColumns = XElementParserUtils.GetStringValue(configElement.Element("QueryOutputCachedSchemaColumns"));
			jdbcQueryActivity.QueryOutputCachedSchemaDataTypes = XElementParserUtils.GetIntValue(configElement.Element("QueryOutputCachedSchemaDataTypes"));
			jdbcQueryActivity.QueryOutputCachedSchemaStatus = XElementParserUtils.GetStringValue(configElement.Element("QueryOutputCachedSchemaStatus"));
			//var elt1 = inputElement.Element ("config").Element("til;

			// TODO : retrieve the inputbinding


			return jdbcQueryActivity;
		}
	}

}

