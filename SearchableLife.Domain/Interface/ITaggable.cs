﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableLife.Domain.Interface
{
    public interface ITaggable
    {
        public List<string> TagNames { get; set; }
    }
}
