using ParkStroiteleyMVC.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string About { get; set; }
        public string Name { get; set; }
        public ImageSizeType ImageSize { get; set; }
        public DateTime DateAdd { get; set; }
        public List<ImageDTO> Minis { get; set; }
    }
}
