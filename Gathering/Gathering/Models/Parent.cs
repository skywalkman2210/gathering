//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gathering.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parent
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<int> StudentId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Student Student { get; set; }
    }
}
