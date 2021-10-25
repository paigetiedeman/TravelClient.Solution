using System.Drawing;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Travel.Models
{
public class Review
    {
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    
    
    }

}