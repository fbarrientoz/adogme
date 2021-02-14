
namespace adogme.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOG()
        {
            this.ADOPTIONs = new HashSet<ADOPTION>();
            this.HISTORies = new HashSet<HISTORY>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string CITY { get; set; }
        public int BREED_ID { get; set; }
        public int GENDER_ID { get; set; }
        public int SIZE_ID { get; set; }
        public int PLACE_ID { get; set; }
        public bool IS_ADOPTED { get; set; }
        public System.DateTime REGISTER { get; set; }
        public string PICTURE { get; set; }
        public string AGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADOPTION> ADOPTIONs { get; set; }
        public virtual BREED BREED { get; set; }
        public virtual GENDER GENDER { get; set; }
        public virtual PLACE PLACE { get; set; }
        public virtual SIZE SIZE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORY> HISTORies { get; set; }
    }
}
