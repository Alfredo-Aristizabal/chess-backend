using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessBackend.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; } = null!;

        [NotMapped]
        private string password
        {
            get { return PasswordStored; } // Devuelve el valor encriptado
            set { PasswordStored = Encrypt(value); } // Encripta el valor y lo guarda en PasswordStored }
        }

        [Required]
        [MaxLength(100)]
        protected string PasswordStored { get; set; }

        // Método para encriptar el password usando Microsoft.AspNetCore.Identity
        private string Encrypt(string password)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.HashPassword(this, password);
        }
        // Método para verificar si un password coincide con el hash almacenado usando Microsoft.AspNetCore.Identity
        public bool VerifyPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            return hasher.VerifyHashedPassword(this, PasswordStored, password) == PasswordVerificationResult.Success;
        }
    }
}
