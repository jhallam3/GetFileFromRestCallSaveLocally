using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallSaveFileClass
{
    public class JsonToFileData
    {
        public Done Done { get; set; }
    }

    public class Done
    {
        public File File { get; set; }
        public string FileContents { get; set; }
    }

    public class File
    {
        public string FilePath { get; set; }
        public int ContentLength { get; set; }
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Contents { get; set; }
    }

}
