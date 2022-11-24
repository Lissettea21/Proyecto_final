
using System;


namespace ProyecTitulacion.Model
{
    public class TblMembers
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool isDelete { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
       // public string bFoto { get; set; }

    }
}
