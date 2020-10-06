using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepositoryPattern.Domain
{
     public interface IRepositoryWrapper
     {
          ICodeVerifierRepository codeVerifierRepository { get; }
          IReferralStatesRepository referralStatesRepository { get; }
     }
}
