using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.Models
{
    public class ElectionSettingModel
    {
        //public int ElectionID { get; set; }
        //public string ElectionName { get; set; }
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

    public class areamodel
    {
        [Key]
        public int AreaID { get; set; }
        [Required(ErrorMessage = "Please Enter  Ward Name")]
        public string AreaTitle { get; set; }
        [Required(ErrorMessage = "Please Select Zone")]
        public int? ZoneID { get; set; }
        [Required(ErrorMessage = "Please Select Area")]
        public string AreaName { get; set; }
        public zoneModel ZoneDetailsitem { get; set; }
    }
    public class ElectionDetailsModel
    {
        public int ElectionID { get; set; }
        public string ElectionName { get; set; }
        public string ElectionDetails { get; set; }
        public int? ElectionType { get; set; }
        public ElectionModel ElectionTypeDetails { get; set; }
    }
}
