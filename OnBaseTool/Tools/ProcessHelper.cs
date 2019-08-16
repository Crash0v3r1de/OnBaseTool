using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBaseTool.Tools
{
    public class ProcessHelper
    {

        // dfsvc.exe is the ClickOnce install executable
        // obunity.exe is the OnBase unity client executable
        public bool OnBaseRunning()
        {
            if (UnityRunning())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void KillOnBase()
        {
            if (UnityRunning())
            {
                KillUnity();
            }
        }

        private bool UnityRunning()
        {
            var proc = Process.GetProcessesByName("obunity");
            if (proc.Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void KillUnity()
        {
            var proc = Process.GetProcessesByName("obunity");
            if (proc.Length != 0)
            {
                for (int x = 0; x < proc.Length; x++)
                {
                    try
                    {
                        proc[x].Kill();
                    }
                    catch
                    {
                        // This and the client is ran at user level so if this catches that's just weird
                    }
                }
            }
        }
    }
}
