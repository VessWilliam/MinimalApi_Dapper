using DataAccess.DbAccess;
using DataAccess.Models;
using System.Data.SqlClient;
namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<UserModels>> GetUsers() =>
            _db.LoadData<UserModels, dynamic>(storedProcedure: "dbo.spAexDatabase_GetALL", new { });

        public async Task<UserModels?> GetUser(int Id)
        {
            var result = await _db.LoadData<UserModels, dynamic>(storedProcedure: "dbo.spAexDatabase_Get", new { Id = Id });
            return result.FirstOrDefault();
        }
        public Task InsertUser(UserModels user) => _db.SaveData(storedProcedure: "dbo.spAexDataBase_Insert", 
            new { user.UserName, user.UserLocation, user.Email, user.MacAddress, user.PhoneNumber,user.DateRegister,user.DateExpire});

        public Task UpdateUser(UserModels user) {
            var result = _db.SaveData(storedProcedure: "dbo.spAexDataBase_Update", new { user.UserLocation, user.MacAddress});
            return result;
        }

        public Task DeleteUsers(int Id) => _db.SaveData(storedProcedure: "dbo.spAexDataBase_Delete", new { Id = Id});

        public async Task<UserModels?> GetUserByMac(string mac) 
        {
            var result1 = await _db.LoadData<UserModels, dynamic>(storedProcedure: "dbo.spAexDatabase_GetMac", new { mac = mac });
            return result1.FirstOrDefault();
        }
        public async Task<UserModels?> CheckValidUserByMac(string mac)
        {
            var result1 = await _db.LoadData<UserModels, dynamic>(storedProcedure: "dbo.spAexDatabase_Expire", new { mac = mac });
            return result1.FirstOrDefault();
        }



    }
}
