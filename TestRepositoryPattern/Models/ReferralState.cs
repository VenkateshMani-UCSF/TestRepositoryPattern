using System.ComponentModel.DataAnnotations;

namespace TestRepositoryPattern.Models
{
     public class ReferralState
     {
          [Key, MaxLength(200)]
          public string ReferralId { get; set; }
          public bool FinishedOnboarding { get; set; }
     }
}
