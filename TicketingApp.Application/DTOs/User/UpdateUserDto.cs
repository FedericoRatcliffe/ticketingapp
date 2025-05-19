using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Application.DTOs.User
{
    public class UpdateUserDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string IdentificationType { get; set; } = null!;
        public string IdentificationValue { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string Country { get; set; } = null!;
    }

}
