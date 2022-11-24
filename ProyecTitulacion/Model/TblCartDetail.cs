using System;
using System.Collections.Generic;
using System.Text;

namespace ProyecTitulacion.Model
{
    public class TblCartDetail
    {
        public int CartDetailId { get; set; }
        public string CartId { get; set; }
        public string ProductId { get; set; }
        public string CartStatusId { get; set; }
    }
}
