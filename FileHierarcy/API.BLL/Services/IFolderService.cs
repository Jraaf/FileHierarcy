using API.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BLL.Services
{
    public interface IFolderService
    {
        Task<FolderDTO> GetFolderAsync(int id);
        Task<List<FolderDTO>> GetChildren(int Id);
        Task<bool> AddAsync(CreateFolderDTO folder);
        Task<bool> UpdateAsync(int Id, CreateFolderDTO folder);
        Task<bool> DeleteAsync(int Id);
        Task<bool> DeleteAll();
        Task<int> Start();
    }
}
