using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraffLifeWeb.Data
{
    public class CrewInfoResponse
    {
        [Key]
        public int crewId { get; set; }

        public string name { get; set; }

        public string headId { get; set; }

        public string UserName { get; set; }    // crew head's username

        public string abbreviation { get; set; }

        public string description { get; set; }

        public UInt64 fame { get; set; }
    }

    public class CrewRankingResponse
    {
        [Key]
        public int crewId { get; set; }

        public string name { get; set; }

        public string abbreviation { get; set; }

        public UInt64 fame { get; set; }
    }

    public class CrewMembershipResponse
    {
        [Key]
        public int crewId { get; set; }

        public string abbreviation { get; set; }

        public UInt64 fame { get; set; }

    }
    public class CrewMemberResponse
    {
        [Key]
        public string userId { get; set; }

        public string UserName { get; set; }   

        public UInt64 fame { get; set; }

        public int level { get; set; }

    }
}
