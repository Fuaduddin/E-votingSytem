using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.Models;

namespace Evoting.Models
{
    public class SuperAdminAndAdminViewModel
    {
        // All Single Model
        public PartyModel Party { get; set; }
        public ElectionModel ElectionType { get; set; }
        public zoneModel Zone { get; set; }

        // All List
        public List<PartyModel> PartyList { get; set; }
        public List<ElectionModel> ElectionTypeList { get; set; }
        public List<zoneModel> ZoneList { get; set; }

        // Extra Feauture
        public int TotalPage { get; set; }
    }
}
