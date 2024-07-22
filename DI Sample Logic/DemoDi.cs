using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DI_Sample_Logic
{
    public class DemoDi :IDemoTransient, IDemoScoped, IDemoSingleton
    {
        public int InitialNumber;

        public DemoDi()
        {
            Random rnd = new Random();
            InitialNumber = rnd.Next();
        }
        public int ReturnNumber() => InitialNumber;

        /*The above statement is shorthand version of
         public int ReturnNumber()
        {
            return InitialNumber;
        }
         */
    }
}
