using Evoting.DataLayerSQL;
using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.BusinessLayer
{
   public static class ElectionSettingsManager
    {
        // Election Type
        public static bool AddNewElectionType(ElectionModel electiontype)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsAdded = provider.AddNewElectionType(electiontype);
            return IsAdded;
        }
        public static bool DeleteElectionType(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsDeleted = provider.DeleteElectionType(id);
            return IsDeleted;
        }
        public static List<ElectionModel> GetAllElectionType()
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var partylist = provider.GetAllElectionType();
            return partylist;
        }

        // Zone
        public static bool AddNewZone(zoneModel zone)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsAdded = provider.AddNewZone(zone);
            return IsAdded;
        }
        public static bool DeleteZone(int id)
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            bool IsDeleted = provider.DeleteZone(id);
            return IsDeleted;
        }
        public static List<zoneModel> GetAllZone()
        {
            ElectionSettingsSQLProvider provider = new ElectionSettingsSQLProvider();
            var zone = provider.GetAllZone();
            return zone;
        }
    }
}
