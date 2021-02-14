
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
