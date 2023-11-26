using API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Repository
{
    public interface IFolderRepository
    {
        Task<Folder> GetAsync(int id);
        Task<List<Folder>> GetChildrenAsync(int Id);
        Task<bool> AddAsync(Folder folder);
        Task<bool>UpdateAsync(int Id,Folder folder);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAll();
        Task<int> Start();
    }
}
