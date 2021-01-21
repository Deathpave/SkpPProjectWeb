using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SkpDbLib.Files
{
    /// <summary>
    /// Class is NOT needed in prod
    /// Its Only for creating a secure file for the connection string
    /// </summary>
    internal class FileWriter
    {
        public void WriteStringToFile(string filePath, string data)
        {
            File.WriteAllText(filePath, data);
        }
    }
}
