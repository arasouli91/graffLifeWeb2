using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class UserInfoResponse
    {
        [Key]
        public UInt64 fame { get; set; }

        public DateTime memberSince { get; set; }

        public byte[] avatar { get; set; }

        public short level { get; set; }

    }

    // Also contains name, id, mainCrewId and crew abbreviation
    public class UserInfoResponse2
    {
        [Key]
        public string userId { get; set; }

        public string UserName { get; set; }

        public UInt64 fame { get; set; }

        public DateTime memberSince { get; set; }

        public byte[] avatar { get; set; }

        public short level { get; set; }

        public int mainCrewId { get; set; }

        public string abbreviation { get; set; }

    }
}
