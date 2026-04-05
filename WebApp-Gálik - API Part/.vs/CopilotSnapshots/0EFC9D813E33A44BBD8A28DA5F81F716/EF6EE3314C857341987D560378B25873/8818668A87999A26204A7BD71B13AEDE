using BusinessLayer.Interfaces.Repository;
using BusinessLayer.Interfaces.Services;
using Common.DTO;
using DataLayer.entities;
using Lukas_Liscak_IVD.Models;

namespace BusinessLayer.Services
{
  public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

public UserService(IUserRepository userRepository)
        {
       _userRepository = userRepository;
      }

   public async Task<bool> CreateAsync(UserDTO model)
{
         var entity = new UserEntity
    {
       PublicId = Guid.NewGuid(),
      Name = model.Name,
         Email = model.Email,
    Password = model.Password
            };

    await _userRepository.CreateAsync(entity);
          await _userRepository.SaveChangesAsync();
     return true;
     }

        public async Task<bool> DeleteAsync(Guid id)
   {
      var user = await _userRepository.GetByPublicIdAsync(id);
        if (user == null)
     return false;

  _userRepository.Delete(user);
       await _userRepository.SaveChangesAsync();
  return true;
   }

    public async Task<List<UserDTO>> GetAllUsersAsync()
     {
         var userList = await _userRepository.GetAllUsersAsync();
        var userModelList = new List<UserDTO>();

  foreach (var user in userList)
         {
      var userModel = new UserDTO
            {
 PublicId = user.PublicId,
      Name = user.Name,
       Email = user.Email
      };
           userModelList.Add(userModel);
  }

    return userModelList;
     }

   public async Task<UpdateUserDTO?> GetByIdAsync(Guid id)
     {
     var user = await _userRepository.GetByPublicIdAsync(id);
if (user == null) return null;
  
      var updateModel = new UpdateUserDTO
            {
              UserPublicId = id,
   Email = user.Email
 };
       return updateModel;
  }

      public async Task<bool> UpdateAsync(UserDTO model)
        {
         var user = await _userRepository.GetByPublicIdAsync(model.PublicId);
       if (user == null) return false;

  user.Email = model.Email;
       user.Name = model.Name;

 _userRepository.Update(user);
         await _userRepository.SaveChangesAsync();
  return true;
   }

        public Task<bool> UpdateAsync(UpdateUserDTO updateModel)
        {
    throw new NotImplementedException();
        }

       public async Task<UserDTO?> LoginAsync(LoginDTO dto)
        {
           var user = await _userRepository.GetByEmailAsync(dto.Email);
   if (user == null || user.Password != dto.Password)
   return null;

     return new UserDTO
    {
         PublicId = user.PublicId,
           Name = user.Name,
   Email = user.Email
    };
  }
    }
}
