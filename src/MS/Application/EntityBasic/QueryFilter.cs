﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.EntityBasic
{
    [Serializable]
    public abstract class QueryFilter
    {

        public int PageIndex { get; set; }


        public int PageSize { get; set; }


        public string SortFields { get; set; }


        public int draw { get; set; }

    }
}
