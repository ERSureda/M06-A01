using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_A01.Domain
{
    public class FirebaseDomainFacory
    {
        public IFirebaseDomain GetFirebaseDomain()
        {
            return new FirebaseDomain();
        }
    }
}
