using System.ComponentModel.DataAnnotations;

namespace Users.ModelsMapper
{
    public class CreateUserMapper
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Adress { get; set; }

    }
}
