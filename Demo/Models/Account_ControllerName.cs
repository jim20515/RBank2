//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account_ControllerName
    {
        public Account_ControllerName()
        {
            this.AspNetRoles = new HashSet<AspNetRoles>();
        }
    
        public string ControllerName { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public int Priority { get; set; }
    
        public virtual Account_SideBarType Account_SideBarType { get; set; }
        public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }
    }
}