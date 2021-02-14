
namespace adogme.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BLOG
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string BODY { get; set; }
        public string AUTHOR { get; set; }
        public System.DateTime DATE { get; set; }
    }
}
