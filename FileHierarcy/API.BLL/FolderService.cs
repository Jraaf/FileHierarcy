using API.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BLL
{
    public class FolderService:IFolderService
    {
        private readonly IFolderRepository folderRepository;
    }
}
