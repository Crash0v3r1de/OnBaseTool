using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        public static bool AllDone { get; set; }

        private static void UpdateDone(WorkType status)
        {
            Debug.WriteLine($"Updating {status}");
            switch (status)
            {
                case WorkType.Completed:
                    UnityDone = true;
                    RepairDone = true;
                    AddinDone = true;
                    UnityDone = true;
                    AllDone = true;
                    break;
                case WorkType.Installing:
                    UnityDone = false;
                    RepairDone = true;
                    AddinDone = false;
                    UnityDone = false;
                    AllDone = false;
                    break;
                case WorkType.Repair:
                    UnityDone = true;
                    RepairDone = false;
                    AddinDone = false;
                    UnityDone = true;
                    AllDone = false;
                    break;
                case WorkType.RemovingFolders:
                    UnityDone = true;
                    RepairDone = false;
                    AddinDone = false;
                    UnityDone = true;
                    AllDone = false;
                    break;
                case WorkType.idle:
                    UnityDone = true;
                    RepairDone = true;
                    AddinDone = true;
                    UnityDone = true;
                    AllDone = true;
                    AllDone = true;
                    break;
                default:
                    UnityDone = true;
                    RepairDone = true;
                    AddinDone = true;
                    UnityDone = true;
                    AllDone = true;
                    // Use this incase everything is done and i forget to use one of the cases in the switch statement
                    break;
            }
        }

        public static void UnityStarted()
        {
            UpdateDone(WorkType.Installing);
        }

        public static void UnityInstalled()
        {
            UpdateDone(WorkType.Completed);
        }

        public static void UnityUninstall()
        {
            UpdateDone(WorkType.Installing);
        }

        public static void UnityUninstallDone()
        {
            UpdateDone(WorkType.Completed);
        }

        public static void RepairStarted()
        {
            UpdateDone(WorkType.Repair);
        }

        public static void RepairCompleted()
        {
            UpdateDone(WorkType.Completed);
        }

        public static void RemovingFolders()
        {
            UpdateDone(WorkType.RemovingFolders);
        }

        public static void AddinInstalling()
        {
            UpdateDone(WorkType.Installing);
        }

        public static void AddinCompleted()
        {
            UpdateDone(WorkType.Completed);
        }

        public static void AddinUninstaling()
        {
            UpdateDone(WorkType.Uninstalling);
        }
    }
}
