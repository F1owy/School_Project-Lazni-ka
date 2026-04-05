using DataLayer.entities;
using Lukas_Liscak_IVD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity?> GetByEmailAsync(string email);
        Task<bool> LoginAsync(string email, string password);
    }
}
