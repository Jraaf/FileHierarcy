using API.DAL.EF;
using API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteAll()
        {
            try
            {
                var data = await context.Folders.ToListAsync();
                context.Folders.RemoveRange(data);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
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

        public async Task<List<Folder>> GetChildrenAsync(int Id)
        {
            var folders = await context.Folders.ToListAsync();
            var res = (from f in folders
                       where f.ParentId == Id
                       select f).ToList();
            //var parent=(from f in folders
            //            where f.Id==Id
            //            select f).ToList().First();
            //res.Add(parent);
            return res;
        }

        public async Task<int> Start()
        {
            

            try
            { 
                var rootInd=(await context.Folders.AddAsync(
                    new Folder { Name = "Creating Digital Images" })).Entity.Id;
                await context.SaveChangesAsync();
                var all = await context.Folders.ToListAsync();
                var rootId = (from f in all
                                where f.Name == "Creating Digital Images"
                          select f).ToList().FirstOrDefault().Id;

                var leftbranchId = (await context.Folders.AddAsync(
                    new Folder { Name = "Resourses", ParentId = rootId })).Entity.Id;

                await context.Folders.AddAsync(new Folder { Name = "Evidence", ParentId = rootId });
                
                var rightbranchId = (await context.Folders.AddAsync(
                    new Folder { Name = "Graphic Products", ParentId = rootId })).Entity.Id;

                await context.SaveChangesAsync();
                all = await context.Folders.ToListAsync();
                leftbranchId = (from f in all
                              where f.Name == "Resourses"
                                select f).ToList().FirstOrDefault().Id;
                rightbranchId = (from f in all
                                where f.Name == "Graphic Products"
                                 select f).ToList().FirstOrDefault().Id;
                List < Folder > folders = new List<Folder>();
                folders.Add(new Folder {  Name = "Primary Sources", ParentId = leftbranchId });
                folders.Add(new Folder { Name = "Secondary Sources", ParentId = leftbranchId });
                folders.Add(new Folder {  Name = "Process", ParentId = rightbranchId });
                folders.Add(new Folder {  Name = "Final Product", ParentId = rightbranchId });

                await context.AddRangeAsync(folders);
                await context.SaveChangesAsync();
                return rootId;
            }
            catch (Exception)
            {

                throw;
            }
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
