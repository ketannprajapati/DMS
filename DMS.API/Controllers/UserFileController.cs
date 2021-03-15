using DMS.Models;
using DMS.Services;
using DMS.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFileController : ControllerBase
    {
        private readonly IUserFileService _userFileService;

        public UserFileController(IUserFileService userFileServicwe)
        {
            this._userFileService = userFileServicwe;
        }

        [HttpGet]
        public List<UserFile> Get()
        {
            return _userFileService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserFile> Get(Guid id)
        {
            return _userFileService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<UserFile>> Post()
        {
            try
            {
                UserFile userFile = new UserFile();
                var file = Request.Form.Files[0];
                
                var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                var userName = Request.Form["UserName"].ToString();
                userFile.FileName = file.Name;
                userFile.FileData = memoryStream.ToArray();
                userFile.UserName = userName;

                userFile = await _userFileService.Add(userFile);

                return userFile;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _userFileService.Delete(id);
        }
    }
}
