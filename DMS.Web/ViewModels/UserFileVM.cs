using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Web.ViewModels
{
    public class UserFileVM
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public IFormFile FileData { get; set; }
    }
}
