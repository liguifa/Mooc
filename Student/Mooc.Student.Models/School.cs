//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentClient.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class School
    {
        public School()
        {
            this.Teachers = new HashSet<Teacher>();
        }
    
        public System.Guid School_Id { get; set; }
        public string School_Name { get; set; }
        public string School_Logo { get; set; }
        public string School_Introduction { get; set; }
        public bool School_IsRegister { get; set; }
        public bool School_IsOpen { get; set; }
        public System.Guid School_Admin { get; set; }
        public bool School_IsDel { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
