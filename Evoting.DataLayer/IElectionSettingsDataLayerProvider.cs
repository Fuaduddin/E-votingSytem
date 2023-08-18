using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayer
{
   public interface IElectionSettingsDataLayerProvider
    {
        // Election Type
        bool AddNewElectionType(ElectionModel electiontype);
        bool DeleteElectionType(int id);
        List<ElectionModel> GetAllElectionType();

        //Zone
        bool AddNewZone(zoneModel zone);
        bool DeleteZone(int id);
        List<zoneModel> GetAllZone();

    }
}
