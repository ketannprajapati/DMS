using DMS.DAL;
using DMS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class UserFileService
    {
        private UserFileRepository _repository;

        public UserFileService(UserFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserFile> Add(UserFile userFile)
        {
            var id = await _repository.Add(userFile.ConvertModel());
            return Get(id);
        }

        public UserFile Get(Guid id)
        {
            var model = _repository.Get(id);
            return model.ConvertModel();
        }

        public List<UserFile> Get()
        {
            var models = _repository.Get();

            var userFiles = new List<UserFile>();
            models.ForEach(model => userFiles.Add(model.ConvertModel()));

            return userFiles;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
