using pto_restful_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pto_restful_service.Repository
{
    public class UserRepository : IDisposable
    {
        private entities db = new entities();

        public user ValidateUser(string gmail)
        {
            return db.users.FirstOrDefault(user =>
            user.gmail.Equals(gmail, StringComparison.OrdinalIgnoreCase));
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}