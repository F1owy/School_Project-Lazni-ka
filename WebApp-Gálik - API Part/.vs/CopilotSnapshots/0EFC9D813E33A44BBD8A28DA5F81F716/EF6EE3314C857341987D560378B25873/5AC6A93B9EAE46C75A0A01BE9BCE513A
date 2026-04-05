using Common.DTO;
using Lukas_Liscak_IVD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UpdateUserDTO?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(UserDTO model);
        Task<bool> UpdateAsync(UserDTO model);
        Task<bool> DeleteAsync(Guid id);
        Task<UserDTO?> LoginAsync(LoginDTO dto);
        Task<bool> UpdateAsync(UpdateUserDTO updateModel);
    }
}
