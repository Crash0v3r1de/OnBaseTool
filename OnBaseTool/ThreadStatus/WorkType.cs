using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBaseTool.ThreadStatus
{
    public enum WorkType
    {
        idle=0,
        Uninstalling=1,
        RemovingFolders=2,
        Installing=3,
        Completed=4
    }
}
