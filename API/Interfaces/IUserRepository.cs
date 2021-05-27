using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
         void Update(AppUser user);
         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppUser>> GetUserAsync();
         Task<IEnumerable<MemberDto>> GetMemberAsync();
         Task<AppUser> GetUserByIdAsync(int id);
         Task<AppUser> GetUserByUsernameAsync(string username);
         Task<MemberDto> GetMemberByUsernameAsync(string username);
    }
}