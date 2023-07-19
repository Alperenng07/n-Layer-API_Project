using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitelikliGenc.WebAPI.Entities.DTOs
{
    public class LikedForUpdateDto
    {
        public bool? IsLiked { get; set; }
        public Guid Id { get; set; }

    }
}
