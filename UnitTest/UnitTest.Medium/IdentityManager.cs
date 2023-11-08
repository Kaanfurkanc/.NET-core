using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Medium
{
    public class IdentityManager
    {
        public List<string> identityNumbers = new List<string>();
        public void addIdentityNumberTr(string identityNumber)
        {
            if (identityNumber.Length == 11)
            {
                identityNumbers.Add(identityNumber);
            }
            else
            {
                throw new Exception("TR ID Number is Incorrect");
            }
        }
    }
}
