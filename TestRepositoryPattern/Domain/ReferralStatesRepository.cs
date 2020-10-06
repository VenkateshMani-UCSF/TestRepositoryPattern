using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Domain
{
     public class ReferralStatesRepository : BaseRepository<ReferralState, PatientDataContext>, IReferralStatesRepository
     {
          public ReferralStatesRepository(PatientDataContext context) : base(context)
          {
          }
     }
}
