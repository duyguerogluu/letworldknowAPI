//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace letworldknow.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Like
    {
        public int id { get; set; }
        public int post_id { get; set; }
        public Nullable<int> giver_id { get; set; }
        public Nullable<int> recipient_id { get; set; }
    
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}