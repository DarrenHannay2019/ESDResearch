using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FutureAPIv1
{
    public class Polygons
    {
        [Key]
        public int objectID { get; set; }
        public string Name { get; set; }
        public string Post_Code { get; set; }
        public string Owner { get; set; }
        public decimal ShapeArea { get; set; }
        public decimal ShapeLen { get; set; }
        public string Address { get; set; }
    }
    public class PolygonPoints
    {
        [Key]
        public int PolyPointID { get; set; }
        public int objectID { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
