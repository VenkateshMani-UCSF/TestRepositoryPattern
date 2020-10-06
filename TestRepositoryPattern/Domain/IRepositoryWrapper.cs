namespace TestRepositoryPattern.Domain
{
     public interface IRepositoryWrapper
     {
          ICodeVerifierRepository codeVerifierRepository { get; }
          IReferralStatesRepository referralStatesRepository { get; }
     }
}
