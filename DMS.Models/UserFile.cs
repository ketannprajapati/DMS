using System;

namespace DMS.Models
{
    public class UserFile
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }

    }
}
