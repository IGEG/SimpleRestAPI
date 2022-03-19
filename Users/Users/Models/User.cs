using System.ComponentModel.DataAnnotations;

namespace Users.MOdels
{
public class User
{
public long Id {get;set;}
[Required]
public string FName {get;set;}
[Required]
public string LName { get; set; }  
[Required]
public string Adress { get; set; }
}
}
