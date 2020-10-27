using Microsoft.AspNetCore.Http;

using ParkStroiteleyMVC.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class NewDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public NewsType Type { get; set; }
        public DateTime DatePublish { get; set; }
        public DateTime? DateDelete { get; set; }
        public List<BlockDTO> Blocks { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public int CountLikes { get; set; }
        public int CountDislikes { get; set; }
    }
}
