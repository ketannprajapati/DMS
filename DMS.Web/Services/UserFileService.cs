using DMS.Web.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;
using DMS.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace DMS.Web.API
{
    public class UserFileService : IUserFileService
    {
        private readonly IHttpRestClient _httpRestClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;

        public UserFileService(IHttpRestClient httpRestClient, IConfiguration configuration) 
        {
            _httpRestClient = httpRestClient;
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<List<UserFile>> GetUserFiles()
        {
            var result = await _httpRestClient
                .ClearHeaders()
                .GetAsync<List<UserFile>>($"{_apiUrl}/api/UserFile");
            return result.Result;
        }

        public async Task<UserFile> GetUserFile(string id)
        {
            var result = await _httpRestClient
                .ClearHeaders()
                .GetAsync<UserFile>($"{_apiUrl}/api/UserFile/{id}" );
            return result.Result;
        }

        public async Task<UserFile> SaveUserFile(UserFile userFile)
        {
            var result = await _httpRestClient
                .ClearHeaders()
                .PostAsync<UserFile, UserFile>($"{_apiUrl}/api/UserFile", userFile);

            return result.Result;
        }

        public async Task<bool> DeleteUserFile(string id)
        {
            var result = await _httpRestClient
                .ClearHeaders()
                .DeleteAsync($"{_apiUrl}/api/UserFile", id);

            return result.Result;
        }
    }
}
