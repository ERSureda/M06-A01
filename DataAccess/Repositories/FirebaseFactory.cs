using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.DataAccess.Repositories
{
    public class FirebaseFactory
    {
        public IFirebaseRepository GetFirebaseRepository()
        {
            return new FirebaseRepository();
        }
    }
}
