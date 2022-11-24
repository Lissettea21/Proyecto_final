using System;
using System.Collections.Generic;
using System.Text;

namespace ProyecTitulacion.Model
{
    public class Retorno
    {
        public bool procesoCorrecto { get; set; }
        public object retorno { get; set; }
        public int error { get; set; }
        public string mensaje { get; set; }

        //public Retorno()
        //{
        //    procesoCorrecto = false;
        //    error = 0;
        //    mensaje = null;
        //}

    }

    public class PS_Error
    {
        public int ERROR { get; set; }
        public string Mensaje { get; set; }
        public int NEW_ID { get; set; }
        public PS_Error()
        {
            NEW_ID = 0;
        }
    }

}
