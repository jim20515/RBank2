using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo.Areas.Admin
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class StartDateAttribute : ValidationAttribute
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public StartDateAttribute(string p1, string p2)
        {
            this.Prop1 = p1;
            this.Prop2 = p2;
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection propertiess = TypeDescriptor.GetProperties(value);
            
            object val1 = propertiess.Find(Prop1, true).GetValue(value);
            object val2 = propertiess.Find(Prop2, true).GetValue(value);

            if (val1 == null || val2 == null)
                return true;

            DateTime StartDate = DateTime.Parse(val1.ToString());
            DateTime EndDate = DateTime.Parse(val2.ToString());
            bool CheckResult = true;
            if (EndDate < StartDate)
            {
                CheckResult = false;
            }

            return CheckResult;
        }


        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }


    
}