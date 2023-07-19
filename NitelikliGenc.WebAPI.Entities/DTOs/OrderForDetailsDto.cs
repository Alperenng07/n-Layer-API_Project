using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitelikliGenc.WebAPI.Entities.DTOs
{
    public class OrderForDetailsDto
    {
        public Guid Id { get; set; }
        public string OrderNumbers { get; set; } 
        public Guid ProductId { get; set; }  

    }
}
