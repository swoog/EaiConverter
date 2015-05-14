﻿using System;
using EaiConverter.Model;

namespace EaiConverter.Parser
{
    public class ActivityParserFactory : IActivityParserFactory
    {
        public IActivityParser GetParser(string activityType){

            if (activityType == ActivityType.jdbcQueryActivityType.ToString() || activityType == ActivityType.jdbcUpdateActivityType.ToString()  || activityType == ActivityType.jdbcCallActivityType.ToString()  ) {
                return new JdbcQueryActivityParser ();
            } else if (activityType == ActivityType.callProcessActivityType.ToString() ){
                return new CallProcessActivityParser ();
            } else if (activityType == ActivityType.xmlParseActivityType.ToString() ){
                return new XmlParseActivityParser ();
            } else if (activityType == ActivityType.assignActivityType.ToString() ){
                return new AssignActivityParser ();
            } else if (activityType == ActivityType.mapperActivityType.ToString() ){
                return new MapperActivityParser ();
            } else {
                return null;
            } 
        }
    }
}
