using DMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Contracts
{
    public interface IUserFileService
    {
        /// <summary>
        /// Add UserFile Details
        /// </summary>
        /// <param name="userFile"></param>
        /// <returns></returns>
        Task<UserFile> Add(UserFile userFile);

        /// <summary>
        /// Get UserFile details by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserFile Get(Guid id);

        /// <summary>
        /// Get all UserFiles
        /// </summary>
        /// <returns></returns>
        List<UserFile> Get();


        /// <summary>
        /// Delete UserFile By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id);
    }
}
