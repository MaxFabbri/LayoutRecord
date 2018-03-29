using LayoutRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLayoutRecord
{
    class Program
    {
        static void Main()
        {
            var lp = new LayoutPers();
            var file = new FileLayout(@"C:\TestFile\ProvaFile.txt", "track", lp);

            var zuck = new LayoutPers();
            file.AddLayout("zuck", zuck);

            lp.ResetFields(true); 
            zuck.ResetFields(true); 

            zuck.Field("numericoField").NumberDecimalSeparator = ".";

            lp.Field("TRACREC").StringValue = "00";
            zuck.Field("TRACREC").StringValue = "01";

            lp.Field("Field1").StringValue = "lp";
            zuck.Field("Field1").StringValue = "zuck";

            zuck.Field("Field2").StringValue = "xxx";

            lp.Field("numericoField").NumericValue = 0.1M;
            zuck.Field("numericoField").NumericValue = 100;

            if (file.WriteLine())
                Console.WriteLine("something goes wrong...");

            if (file.WriteLine("zuck"))
                Console.WriteLine("qualcosa è andato storto");

            Console.WriteLine("hit any key to continue...");
            Console.ReadLine();

        }
    }
}
