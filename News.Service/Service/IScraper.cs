using System;
using System.Collections.Generic;
using System.Text;

namespace News.Service.Service
{
    public interface IScraper
    {
        string GetHeadlines(string url);
    }
}
