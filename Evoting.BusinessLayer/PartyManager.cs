using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evoting.DataLayerSQL;
using Evoting.DataLayer;
namespace Evoting.BusinessLayer
{
    public class PartyManager
    {
        public static bool AddNewParty(PartyModel party)
        {
            PartySQLProvider provider = new PartySQLProvider();
            bool IsAdded = provider.AddNewParty(party);
            return IsAdded;
        }
        public static bool UpdateParty(PartyModel party)
        {
            PartySQLProvider provider = new PartySQLProvider();
            bool IsUpdated = provider.UpdateParty(party);
            return IsUpdated;
        }
        public static PartyModel GetSingleParty(int id)
        {
            PartySQLProvider provider = new PartySQLProvider();
            var party = provider.GetSingleParty(id);
            return party;
        }
        public static bool DeleteParty(int id)
        {
            PartySQLProvider provider = new PartySQLProvider();
            bool IsDeleted = provider.DeleteParty(id);
            return IsDeleted;
        }
        public static List<PartyModel> GetAllParty()
        {
            PartySQLProvider provider = new PartySQLProvider();
           var partylist= provider.GetAllParty();
            return partylist;
        }
    }
}
