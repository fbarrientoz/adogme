namespace adogme.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADOPTION
    {
        public int ID { get; set; }
        public string FULL_NAME { get; set; }
        public string EMAIL { get; set; }
        public string DESCRIPTION { get; set; }
        public int DOG_ID { get; set; }
        public System.DateTime REGISTER { get; set; }
        public bool ESTATUS { get; set; }
    
        public virtual DOG DOG { get; set; }
    }
}
