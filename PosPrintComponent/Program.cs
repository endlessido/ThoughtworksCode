using PosPrintComponent.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrintComponent
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IPosPrint iPosPrint = new PosPrintImplement();
            string jsonRequest = "[\"ITEM000001\",\"ITEM000001\",\"ITEM000001\",\"ITEM000003-2\",\"ITEM000002\",\"ITEM000002\",\"ITEM000002\"]";
            iPosPrint.PrintResult(jsonRequest);
            Console.Read();
        }
    }

}
