using DMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Web.Contract
{
    public interface IUserFileService
    {
        Task<List<UserFile>> GetUserFiles();

        Task<UserFile> GetUserFile(string id);

        Task<UserFile> SaveUserFile(UserFile userFile);

        Task<bool> DeleteUserFile(string id);
    }
}
