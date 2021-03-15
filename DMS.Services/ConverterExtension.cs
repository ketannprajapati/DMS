using DMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services
{
    public static class ConverterExtension
    {
        public static UserFile ConvertModel(this DAL.Models.UserFile model)
        {
            if (model != null)
            {
                return new UserFile()
                {
                    Id = model.Id,
                    UserName = model.UserName,
                    FileData = model.FileData,
                    FileName = model.FileName
                };
            }

            return null;
        }

        public static DAL.Models.UserFile ConvertModel(this UserFile model)
        {
            if (model != null)
            {
                return new DAL.Models.UserFile()
                {
                    Id = model.Id,
                    UserName = model.UserName,
                    FileData = model.FileData,
                    FileName = model.FileName
                };
            }

            return null;
        }
    }
}
