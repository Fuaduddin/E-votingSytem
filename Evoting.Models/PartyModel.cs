using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Evoting.Models
{
    public class PartyModel
    {
        [Key]
        public int PartyID { get; set; }
        [Required(ErrorMessage = "Please Enter Party Name")]
        public string PartyName { get; set; }
        public string PartySymbol { get; set; }
    }
}
