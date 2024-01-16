using Evoting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.DataLayer
{
    public interface IPartyDataLayerProvider
    {
        bool AddNewParty(PartyModel party);
        bool UpdateParty(PartyModel party);
        PartyModel GetSingleParty(int id);
        bool DeleteParty(int id);
        List<PartyModel> GetAllParty();
    }
}
