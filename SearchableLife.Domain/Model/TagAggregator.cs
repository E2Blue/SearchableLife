﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchableLife.Domain.Interface;

namespace SearchableLife.Domain.Model
{
    /// <summary>
    /// Used to combine contents with specific tags for display, ie Malta2011 + Travel
    /// </summary>
    [Serializable]
    public class TagAggregator: IRoutable, IMenuItem
    {
        public List<Tag> Tags { get; set; }
    }
}
