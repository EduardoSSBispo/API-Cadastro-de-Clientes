using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Account
{
    public  interface IAuthenticate
    {
        bool Authenticate(string email, string senha);

        bool UserExists(string email);

        public string GenerateToken(int id, string email);

        public Usuario GetUserByEmail(string email);
    }
}
