using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Drawing;

namespace Demo.Utils
{
    public static class GlobalFuns
    {
        [DbFunction("DemoRolesModel.Store", "BooleanButtonLabelValue")]
        public static string BooleanButtonLabelValue(bool param)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }

        [DbFunction("DemoRolesModel.Store", "SexButtonLabelValue")]
        public static string SexButtonLabelValue(int param)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}