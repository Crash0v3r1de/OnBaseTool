using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnBaseTool.Enums;

namespace OnBaseTool.StaticClasses
{
    public static class WorkStatus
    {
        public static bool UnityDone { get; set; }
        public static bool RepairDone { get; set; }
        public static bool AddinDone { get; set; }
        public static bool UninstallDone { get; set; }

        public static void UpdateDone(WorkType status)
        {
            switch (status)
            {
                case WorkType.Completed:
                    break;
                case WorkType.Installing:
                    break;
                case WorkType.Repair:
                    break;
                default:
                    UnityDone = true;
                    RepairDone = true;
                    AddinDone = true;
                    UnityDone = true;
                    // Use this incase everything is done and i forget to use one of the cases in the switch statement
                    break;
            }
        }
    }
}
