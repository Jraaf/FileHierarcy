using API.Common.DTO;
using API.DAL.Entities;
using API.DAL.Repository;
using AutoMapper;

namespace API.BLL.Services
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository repository;
        private readonly IMapper mapper;
        public FolderService(IFolderRepository repo,IMapper mapper)
        {
            repository = repo;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateFolderDTO folder)
        {
            var data = mapper.Map<Folder>(folder);
            return await repository.AddAsync(data);
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            return await repository.DeleteAsync(Id);
        }

        public async Task<FolderDTO> GetFolderAsync(int id)
        {
            var data= await repository.GetAsync(id);
            return mapper.Map<FolderDTO>(data);
        }

        public async Task<List<FolderDTO>> GetChildren(int Id)
        {
            var data=await repository.GetChildrenAsync(Id);
            return mapper.Map<List<FolderDTO>>(data);
        }

        public async Task<bool> UpdateAsync(int Id, CreateFolderDTO folder)
        {
            var fol=mapper.Map<Folder>(folder);
            return await repository.UpdateAsync(Id, fol);
        }
    }
}
