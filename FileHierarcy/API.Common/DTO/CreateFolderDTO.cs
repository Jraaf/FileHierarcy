using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.DTO
{
    public class CreateFolderDTO
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
