using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class ElectionSettingModel
    {
    }
    public class ElectionModel
    {
        public int ElectionID { get; set; }
        [Required(ErrorMessage = "Please Enter Election Name")]
        public string ElectionName { get; set; }
    }
    public class zoneModel
    {
        public int ZoneId { get; set; }
        [Required(ErrorMessage = "Please Enter Zone Name")]
        public string ZoneName { get; set; }

        //public  List<Admin> Admins { get; set; }
        //public  Area Area { get; set; }
        //public List<Candidate> Candidates { get; set; }
        //public List<Election_Detail> Election_Details { get; set; }
        //public List<Voter> Voters { get; set; }
    }
}
