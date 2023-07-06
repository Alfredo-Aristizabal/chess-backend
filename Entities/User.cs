using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChessBackend.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; } = null!;

        public string password { get; set; } = null!;


        public void SetPassword(string password) {
            
            this.password = Encrypt(password); ;
        }
      


        // Método para encriptar el password usando Microsoft.AspNetCore.Identity
        private string Encrypt(string password)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.HashPassword(this, password);
        }
        // Método para verificar si un password coincide con el hash almacenado usando Microsoft.AspNetCore.Identity
        public bool VerifyPassword(string providedPassword)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.VerifyHashedPassword(this, password, providedPassword) == PasswordVerificationResult.Success;
        }
    }
}
