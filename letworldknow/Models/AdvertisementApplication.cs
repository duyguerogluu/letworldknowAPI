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
    
    public partial class AdvertisementApplication
    {
        public int id { get; set; }
        public Nullable<int> advertisement_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string description { get; set; }
        public Nullable<bool> advertisement_status { get; set; }
    
        public virtual Advertisement Advertisement { get; set; }
        public virtual User User { get; set; }
    }
}
