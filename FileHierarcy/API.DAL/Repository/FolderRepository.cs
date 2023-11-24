using API.DAL.EF;
using API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Repository
{
    public class FolderRepository : IFolderRepository
    {
        private readonly HierarcyContext context;
        public FolderRepository(HierarcyContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddAsync(Folder folder)
        {
            try
            {
                await context.AddAsync(folder);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var data = await context.Folders.FindAsync(id);
            if (data != null)
            {
                context.Folders.Remove(data);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Folder> GetAsync(int id)
        {
            return await context.Folders.FindAsync(id);            
        }

        public async Task<bool> UpdateAsync(int Id, Folder folder)
        {
            var data=await context.Folders.FindAsync(Id);
            if(data != null)
            {
                data.Name = folder.Name;
                data.ParentId = folder.ParentId;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
