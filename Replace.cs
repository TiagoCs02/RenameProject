using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RenameProject
{
    public class Replace
    {
        public void RenameFolderContent(string path, string oldName, string newName)
        {
            DirectoryInfo d = new DirectoryInfo($"{path}");

            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                File.Move(f.FullName, $"{path}\\{f.Name.Replace(oldName, newName)}");
            }

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string textFile = File.ReadAllText(file);
                textFile = textFile.Replace(oldName, newName);
                File.WriteAllText(file, textFile);
            }

            DirectoryInfo[] dirs = d.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                RenameFolderContent(dir.FullName, oldName, newName);
                if(dir.Name.Contains(oldName))
                {
                    dir.MoveTo($"{path}\\{dir.Name.Replace(oldName, newName)}");
                }
            }

        }
    }
}
