using System;
using System.Collections.Generic;
using System.Text;

namespace ProyecTitulacion.Model
{
    public class TblCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
