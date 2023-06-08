﻿using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox
{
    public class ObjectTypeOptions 
    {
        [Required]
        public List<NoxSimpleTypeDefinition>? Attributes { get; internal set; }
    }
}