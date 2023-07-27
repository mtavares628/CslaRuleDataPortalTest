using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ITestDal
    {
        bool IsValid { get; set; }
    }


    public class TestDal : ITestDal
    {
        public bool IsValid { get; set; }
    }

}
