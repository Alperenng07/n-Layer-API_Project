﻿using NitelikliGenc.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitelikliGenc.WebAPI.Entities.DTOs
{
    public class TagForPostDto
    {
        
        public string Label { get; set; }
        public Guid ProductId { get; set; }
     

    }
}
