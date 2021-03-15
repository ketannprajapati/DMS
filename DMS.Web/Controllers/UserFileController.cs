using DMS.Models;
using DMS.Web.Contract;
using DMS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Web.Controllers
{
    public class UserFileController : Controller
    {
        private readonly IUserFileService _userFileService;

        public UserFileController(IUserFileService userFileService)
        {
            this._userFileService = userFileService;
        }

        public async Task<IActionResult> List()
        {
            var userFiles = await _userFileService.GetUserFiles();
            return View(userFiles);
        }

        public IActionResult AddFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string userName, IFormFile fileData)
        {
            try
            {
                UserFile userFile = new UserFile();

                var memoryStream = new MemoryStream();
                await fileData.CopyToAsync(memoryStream).ConfigureAwait(false);

                userFile.FileName = fileData.FileName;
                userFile.FileData = memoryStream.ToArray();
                userFile.UserName = userName;

                userFile = await _userFileService.SaveUserFile(userFile);

               return RedirectToAction("List");
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<ActionResult> Delete(string id)
        {
            await _userFileService.DeleteUserFile(id);

            return RedirectToAction("List");
        }

        public async Task<ActionResult> Download(string id)
        {
            var userFile = await _userFileService.GetUserFile(id);

            byte[] byteArray = userFile.FileData;
            Stream stream = new MemoryStream(byteArray);
            return File(stream, "application/pdf", userFile.FileName);
        }
    }


}
