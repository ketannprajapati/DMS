using DMS.DAL.Context;
using DMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DMS.DAL
{
    /// <summary>
    /// User File Repository
    /// </summary>
    public class UserFileRepository
    {
        private readonly DMSContext _context;

        public UserFileRepository(DMSContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(UserFile userFile)
        {
            userFile.Id = Guid.NewGuid();
            _context.UserFiles.Add(userFile);
            await _context.SaveChangesAsync();
            return userFile.Id;
        }

        public UserFile Get(Guid id) => _context.UserFiles.FirstOrDefault(x => x.Id == id);

        public List<UserFile> Get()
        {
            return (from uf in _context.UserFiles
                    select new UserFile()
                    {
                        Id = uf.Id,
                        FileName = uf.FileName,
                        UserName = uf.UserName
                    }).ToList();
        }

        public async Task<bool> Delete(Guid id)
        {
            var userFile = _context.UserFiles.FirstOrDefault(x => x.Id == id);
            if (userFile != null)
            {
                _context.UserFiles.Remove(userFile);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
