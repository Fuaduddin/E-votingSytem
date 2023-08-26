using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.GlobalSetting
{
    public class GlobalSettingsPatternsandConstant
    {
        public const  string DatePatter = "MM/dd/yyyy";
        public const  string NIDPatter = "";
        public string[] AppointmentSubject = { "Want to become a voter", "Want to become a candidate", 
                                               "Want to correct my voter profile", "Want to correct my candidate profile" };
        public List<string> GetAllSubject()
        {
            List<string> subject = new List<string>();
            foreach (var option in AppointmentSubject)
            {
                subject.Add(option);
            }
           return subject;
        }
    }
}
