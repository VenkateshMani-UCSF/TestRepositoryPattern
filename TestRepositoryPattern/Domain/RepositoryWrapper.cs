using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepositoryPattern.Domain
{
     public class RepositoryWrapper : IRepositoryWrapper
     {
          private readonly PatientDataContext context;

          public RepositoryWrapper(PatientDataContext context)
          {
               this.context = context;
          }

          public ICodeVerifierRepository codeVerifierRepository
          {
               get
               {
                    return new CodeVerifierRepository(this.context);
               }
          }

          public IReferralStatesRepository referralStatesRepository
          {
               get
               {
                    return new ReferralStatesRepository(this.context);
               }
          }
     }
}
