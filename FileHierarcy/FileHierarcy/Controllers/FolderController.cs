using API.BLL.Services;
using API.Common.DTO;
using API.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FileHierarcy.Controllers
{
    public class FolderController : Controller
    {
        private readonly IFolderService service;

        public FolderController(IFolderService service)
        {
            this.service = service;
        }

        [HttpGet("GetFolder")]
        public async Task<IActionResult> GetFolder(int Id)
        {
            var data=service.GetFolderAsync(Id);
            if(data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
        [HttpGet("GetChildren")]
        public async Task<IActionResult> GetChildren(int Id)
        {
            var data = await service.GetChildren(Id);
            if(data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
        [HttpPost("AddFolder")]
        public async Task<IActionResult> AddFolder(CreateFolderDTO folder)
        {
            var data = await service.AddAsync(folder);

            return data ? Ok(data) : BadRequest();
        }
        [HttpPost("Start")]
        public async Task<IActionResult> Start()
        {
            var data = await service.Start();
            ViewData["rootID"]=data;
            return data>0 ? Ok(data) : BadRequest();
        }
        [HttpPut("UpdateFolder")]
        public async Task<IActionResult> UpdateFolder(int Id,CreateFolderDTO folder)
        {
            var data = await service.UpdateAsync(Id,folder);

            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("RemoveFolder")]
        public async Task<IActionResult> DeleteFolder(int Id)
        {
            var data = await service.DeleteAsync(Id);

            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            var data = await service.DeleteAll();

            return data ? Ok(data) : BadRequest();
        }
    }
}
