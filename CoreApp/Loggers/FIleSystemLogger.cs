using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CoreApp
{
    public class FIleSystemLogger : ILogger
    {
        string docPath = null;
        public FIleSystemLogger()
        {
          docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        public virtual void Log(string v)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Log.txt"),true))
            {
                outputFile.WriteLine(v);
            }
        }
    }
}
