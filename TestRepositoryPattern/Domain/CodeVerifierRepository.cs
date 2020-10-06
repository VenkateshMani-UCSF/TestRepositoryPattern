using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Domain
{
     public class CodeVerifierRepository : BaseRepository<CodeVerifier, PatientDataContext>, ICodeVerifierRepository
     {
          public CodeVerifierRepository(PatientDataContext context) : base(context)
          {
          }
     }
}
