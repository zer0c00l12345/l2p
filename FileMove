using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace FileMove
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"\\SOURCEPATH";
            string targetPath = @"\\TARGETPATH";
            
 
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
 
            string[] sourcefiles = Directory.GetFiles(sourcePath);
 
            foreach (string sourcefile in sourcefiles)
            {
                string fileName = Path.GetFileName(sourcefile);
 
                var list = fileName.Split('_');
 
                string destFile = Path.Combine(targetPath + "\\" + list[3] + "-" + Convert.ToInt32(list[1]).ToString("00"), fileName);
 
           
                
                File.Move(sourcefile, destFile);
            }
 
        }
    }
}
