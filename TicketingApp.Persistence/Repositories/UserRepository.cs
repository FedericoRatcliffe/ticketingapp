using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Application.Interfaces.Users;
using TicketingApp.Domain.Entities;
using TicketingApp.Persistence.DbContexts;

namespace TicketingApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketingDbContext _context;

        public UserRepository(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<bool> ExistsByEmailAsync(string email)
            => await _context.Users.AnyAsync(u => u.Email == email);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
