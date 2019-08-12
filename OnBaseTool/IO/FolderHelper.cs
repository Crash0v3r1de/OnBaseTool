using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBaseTool.IO
{
    public class FolderHelper
    {
        private List<string> locations = new List<string>();
        private string apps2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Apps\\2.0";
        public bool Remove2_0Folder()
        {
            if (FolderPresent())
            {
                DelFolder();
                return true;
            }
            return true;
        }

        private void DelFolder()
        {
            for (int x = 0; x < locations.Count; x++)
            {
                Directory.Delete(locations[x],true);
            }
        }

        private bool FolderPresent()
        {
            DirectoryInfo dirs = new DirectoryInfo(apps2);
            var allDirs = dirs.GetDirectories("*", SearchOption.AllDirectories);
            int foundFolders = 0;
            for (int x = 0; x < allDirs.Length; x++)
            {
                if (allDirs[x].Name.Contains("hyla"))
                {
                    foundFolders++;
                    locations.Add(allDirs[x].FullName);
                }
            }
            if (foundFolders !=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
