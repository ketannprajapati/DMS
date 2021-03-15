using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMS.DAL.Models
{
    public class UserFile
    {
        [Key]
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }
    }
}
