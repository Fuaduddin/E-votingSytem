using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.Models;

namespace Evoting.GlobalSetting
{
    public class GlobalCommonData
    {
        public List<Options> genders { get; set; }
        public List<Options> AppointmentSubject { get; set; }
        public List<Options> ElectionStatus { get; set; }
        public GlobalCommonData()
        {
            genders = GetGenders();
            AppointmentSubject = GetAllSubject();
            ElectionStatus = GetElectionStatus();


        }


        private List<Options> GetGenders()
        {
            var genders = new List<Options>();
            genders.Add(new Options
            {
                label = "Please Select Gender",
                value = " "
            });
            genders.Add(new Options
            {
                label = "Male",
                value = "Male"
            });
            genders.Add(new Options
            {
                label = "Female",
                value = "Female"
            });
            return genders;
        }
        private List<Options> GetElectionStatus()
        {
            var ElectionStatus = new List<Options>();
            ElectionStatus.Add(new Options
            {
                label = "Pending",
                value = "Pending"
            });
            ElectionStatus.Add(new Options
            {
                label = "Complete",
                value = "Complete"
            });
            ElectionStatus.Add(new Options
            {
                label = "Cancle",
                value = "Cancle"
            });
            return ElectionStatus;
        }
        private List<Options> GetAllSubject()
        {
            var AppointmentSubject = new List<Options>();
            AppointmentSubject.Add(new Options
            {
                label = "Please Select a Subject",
                value = ""
            });
            AppointmentSubject.Add(new Options
            {
                label = "Want to become a voter",
                value = "Want to become a voter"
            });
            AppointmentSubject.Add(new Options
            {
                label = "Want to become a candidate",
                value = "Want to become a candidate"
            });
            AppointmentSubject.Add(new Options
            {
                label = "Want to correct my voter profile",
                value = "Want to correct my voter profile"
            });
            AppointmentSubject.Add(new Options
            {
                label = "Want to correct my candidate profile",
                value = "Want to correct my candidate profile"
            });
            return AppointmentSubject;
        }
    }

}
