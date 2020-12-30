using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallSaveFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Count() == 0)
            {
                Console.WriteLine("parameters are : URL, File, FilePath, fileID");
                Console.ReadLine();
            }
            else
            {

            //    var url = "http://172.16.1.210:8081/Primary/restapi/Flow/7139f950-49e2-11eb-a335-0800277026be?Action=webhook&sessionid=64d6b08c-2014-4940-aacb-b16d1c1eb20c";
            //    var file = "file2";
            //    var path = @"c:\a";
            //var fileID = "f4d279fe-7929-4093-b3ea-741ea6cb9c78";

                var url = args.ElementAt(0);
                var file = args.ElementAt(1);
                var path = args.ElementAt(2);
                var fileID = args.ElementAt(3);
                var tryme = await new RestCallSaveFileClass.RestCallSaveFileLocally().RunRestCallSaveFileFlocallyAsync(url, file, path, fileID);
           }
           
        }
    }
}
