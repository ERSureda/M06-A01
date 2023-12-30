using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.DataAccess.Repositories
{
    public class FirebaseException : Exception
    {
        public FirebaseException()
        {
        }

        public FirebaseException(string? message) : base(message)
        {
        }

        public FirebaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected FirebaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
