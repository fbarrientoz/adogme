
namespace adogme.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PLACE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLACE()
        {
            this.DOGs = new HashSet<DOG>();
        }
    
        public int ID { get; set; }
        public string PLACE1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOG> DOGs { get; set; }
    }
}
