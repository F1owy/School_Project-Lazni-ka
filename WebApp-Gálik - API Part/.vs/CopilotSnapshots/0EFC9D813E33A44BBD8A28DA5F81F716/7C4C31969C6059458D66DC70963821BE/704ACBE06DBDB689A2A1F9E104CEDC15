using BusinessLayer.Interfaces.Repository;
using DataLayer;
using DataLayer.entities;
using Lukas_Liscak_IVD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<bool> LoginAsync(string email, string password)
        {
            var entity = await _context.Users.Where(u => u.Email == email && u.Password == password)
                                                  .FirstOrDefaultAsync();
            if (entity == null)
                return false;
            return true;
        }
    }
}
