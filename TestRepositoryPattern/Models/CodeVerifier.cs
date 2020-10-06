using System.ComponentModel.DataAnnotations;

namespace TestRepositoryPattern.Models
{
     public class CodeVerifier
     {
          [Key, MaxLength(200)]
          public string RequestId { get; set; }
          public string Code { get; set; }
     }
}
