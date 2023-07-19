using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitelikliGenc.WebAPI.Entities.DTOs
{
    public class RatingForPostDto
    {

        [Range(1, 5)]
        public int Value { get; set; }

        public Guid? productId { get; set; }

    }
}
