using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo.ValidateAttritube
{
    /// <summary>
    /// 驗證開始時間是否小於結束時間
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class StartDateValidationAttribute : ValidationAttribute
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public StartDateValidationAttribute(string PropertName1, string PropertName2)
        {
            Prop1 = PropertName1;
            Prop2 = PropertName2;
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
            return string.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}