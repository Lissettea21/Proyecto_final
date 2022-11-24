using System;
using System.Collections.Generic;
using System.Text;

namespace ProyecTitulacion
{
    public interface IGoogleAuthService
    {
        void Autheticate(IGoogleAuthenticationDelegate googleAuthenticationDelegate);
    }
}
