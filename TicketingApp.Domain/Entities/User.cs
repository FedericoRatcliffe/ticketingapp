using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string IdentificationType { get; set; } = null!; // Puede ser "DNI", "Pasaporte", etc.

        public string IdentificationValue { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string Gender { get; set; } = null!; // Puede ser "Masculino", "Femenino", "No binario", etc.

        public string Country { get; set; } = null!;

        public string Role { get; set; } = "User"; // Puede ser "Admin", "Organizer", etc.
    }

}
