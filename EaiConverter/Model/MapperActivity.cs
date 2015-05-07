﻿using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace EaiConverter.Model
{
    public class MapperActivity : Activity
    {
        public MapperActivity (string name, ActivityType type) : base (name, type)
        {
        }

        public MapperActivity () 
        {
        }

        public string XsdReference {get; set;}

        public IEnumerable<XNode> InputBindings {get; set;}
    }
}

