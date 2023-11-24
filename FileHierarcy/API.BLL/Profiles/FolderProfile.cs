using API.Common.DTO;
using API.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BLL.Profiles
{
    public class FolderProfile:Profile
    {
        public FolderProfile() 
        {
            CreateMap<CreateFolderDTO,Folder>();
            CreateMap<Folder,FolderDTO>();
        }
    }
}
