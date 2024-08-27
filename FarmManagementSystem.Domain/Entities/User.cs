using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FarmManagementSystem.Domain.Entities
{
    public class User
    {
        private const int maxLength = 6;

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Position { get; set; }
        public List<Farm>? Farms { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(UserName))
                throw new ValidationException("O nome de usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
                throw new ValidationException("O e-mail deve estar em um formato válido.");

            if (string.IsNullOrWhiteSpace(PassWord) || PassWord.Length < maxLength)
                throw new ValidationException("A senha deve ter no mínimo 6 caracteres.");
        }
    }
}