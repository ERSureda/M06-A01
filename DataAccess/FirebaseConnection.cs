using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.DataAccess
{
    public class FirebaseConnection
    {
        public static FirebaseClient GetFirebaseClient(string url, string secret = null)
        {
            FirebaseOptions options = new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(secret)
            };
            return new FirebaseClient(url, options);
        }
    }
}
