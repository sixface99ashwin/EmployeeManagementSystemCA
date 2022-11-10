using EmployeeManagementSystemCA.DTO;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.IRepository
{
    public interface IUser
    {
        Task<int> RegisterUser(UserRegisterDto registerDto);
        Task<string> Login(UserLoginDto loginDto);
        UserDetailsDto UserDetails(string email);
        bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt);
    }
}
