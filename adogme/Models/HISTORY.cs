//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace adogme.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORY
    {
        public int ID { get; set; }
        public int DOG_ID { get; set; }
        public string ADOPTER_NAME { get; set; }
        public string HISTORY1 { get; set; }
        public string PICTURE { get; set; }
    
        public virtual DOG DOG { get; set; }
    }
}
