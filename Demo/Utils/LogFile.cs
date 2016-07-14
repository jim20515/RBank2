using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace InternalSystem.Utils
{
    class LogFile
    {
        //public static string START_RECOGNIZE = "Start Recognize";
        //public static string END_RECOGNIZE = "End Recognize";
        //public static string START_WEBSERVICE = "Start Webservice";
        //public static string END_WEBSERVICE = "End Webservice";

        //public static string NO_PLATES_PRESENT = "No Plates Present";
        //public static string WEBVICE_NODATA = "Webservice No Data";
        //public static string WEBVICE_TIMEOUT = "Webservice Timeout";
        //public static string WEBVICE_RESULT = "Webservice Result";
        //public static string FILTER_RESULT = "Filter Result";
        //public static string MOTION_DETECTION = "Motion detection";

        //public static string DISPLAY_PLATE = "Display Plate";

        public static void SaveTxtFile(string tag, string message)
        {
            //string MultiMessage = "";
            //if (cameraNumber >= 0 && message != null)
            //    MultiMessage += cameraNumber + ", " + message;
            //else
            //{
            //    if (message != null)
            //        MultiMessage += message;

            //    if (cameraNumber >= 0)
            //        MultiMessage += cameraNumber;
            
            //}

            //if (DISPLAY_PLATE.Equals(tag))
            //    MultiMessage += "\r\n";

            log4net.LogManager.GetLogger(tag).DebugFormat(message);

        }

        public static void SaveTxtFile(Exception e)
        {
            StackTrace trace = new StackTrace(e, true);
            StackFrame frame = trace.GetFrames().LastOrDefault();

            int lineNumber = frame.GetFileLineNumber();
            string fileName = frame.GetFileName();

            string msg = string.Format("檔案 : {0} 第 {1} 行發生問題 : {2}", fileName, lineNumber, e.Message);

            SaveTxtFile("Exception", msg);
        }
    }
}
