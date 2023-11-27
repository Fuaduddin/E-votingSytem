using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evoting.GlobalSetting
{
    public static class Enums
    {
        public enum Role
        {
          Candidate,
          Voter,
          Admin
        }
        public enum Status
        {
            Active,
            Inactive
        }
    }
}
