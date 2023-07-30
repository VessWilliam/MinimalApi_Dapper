using DataAccess.Models;
using System.Data;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task DeleteUsers(int Id);
        Task<UserModels?> GetUser(int Id);
        Task<UserModels?> GetUserByMac(string mac);
        Task<UserModels?> CheckValidUserByMac(string mac);
        Task<IEnumerable<UserModels>> GetUsers();
        Task InsertUser(UserModels user);
        Task UpdateUser(UserModels user);
        
    }
}