using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class Photo
    {
        public byte[] photo { get; set; }

        [Key]
        public int photoId { get; set; }

        public string userId { get; set; }

        public int fame { get; set; }
    }
}
