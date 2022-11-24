using System;
using System.Collections.Generic;
using System.Text;

namespace ProyecTitulacion.Model
{
    public class TblProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public bool IsFeatured { get; set; }
        public string Quantity { get; set; }
        public string Cost { get; set; }

        internal static IEnumerable<TblProduct> Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
