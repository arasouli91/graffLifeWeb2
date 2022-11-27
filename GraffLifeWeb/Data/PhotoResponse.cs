using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class PhotoResponse
    {
        public byte[] photo { get; set; }

        [Key]
        public int photoId { get; set; }

        public string UserName { get; set; }

        public int fame { get; set; }

    }
    public class PhotoResponse2
    {
        public byte[] photo { get; set; }

        [Key]
        public int photoId { get; set; }

        public Int64 fame { get; set; }

        public DateTime date { get; set; }

    }
}
