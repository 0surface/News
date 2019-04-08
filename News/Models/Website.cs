﻿using System.Collections.Generic;

namespace News.Models
{
    public class Website
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CanonicalUrl { get; set; }
        public List<string> SubUrls { get; set; }
    }
}
