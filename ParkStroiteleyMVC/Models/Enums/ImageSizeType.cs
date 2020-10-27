using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Enums
{
    public enum ImageSizeType
    {
        [EnumMember(Value = "Отсутствует")]
        None,
        [EnumMember(Value = "Большая")]
        Large,
        [EnumMember(Value = "Средняя")]
        Medium,
        [EnumMember(Value = "Маленькая")]
        Small
    }
}
