﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace News.Util.WebScraper
{
    public class WebScraper
    {
        public static Func<string, Task<HtmlDocument>> GetHtmlDocument;
        public static Func<HtmlDocument, string, List<string>> GetRawHeadlines;
        public static Func<List<string>, List<string>> CleanHeadlines;
        public static Func<List<string>, int, List<string>> GetLimitedHeadlines;

        public static int InjectDependencies()
        {
            GetHtmlDocument = _GetHtmlDocument();
            GetRawHeadlines = _GetRawHeadlines();
            CleanHeadlines = _CleanHeadlines();
            GetLimitedHeadlines = _GetLimitedHeadlines();

            return 0;
        }

        private static Func<string, Task<HtmlDocument>> _GetHtmlDocument()
            => async (url) =>
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                return await web.LoadFromWebAsync(url);
            }
            catch (Exception)
            {
                return null;
            }
        };

        private static Func<HtmlDocument, string, List<string>> _GetRawHeadlines()
            => (htmlDoc, headlineSelector) =>
        {
            try
            {
                return htmlDoc.DocumentNode
                                .SelectNodes(headlineSelector)
                                .Select(node => node.InnerHtml)
                                .ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        };

        private static Func<List<string>, List<string>> _CleanHeadlines()
            => (rawHeadlines) =>
        {
            try
            {
                if (rawHeadlines == null || rawHeadlines.Count < 1)
                    return rawHeadlines;

                for (int i = 0; i < rawHeadlines.Count; i++)
                {
                    rawHeadlines[i] = WebUtility.HtmlDecode(rawHeadlines[i]);
                }
                
                return rawHeadlines;
            }
            catch (Exception)
            {
                return rawHeadlines;
            }
        };

        private static Func<List<string>, int, List<string>> _GetLimitedHeadlines()
           => (rawHeadlines, limit) =>
          {
              try
              {
                  if (rawHeadlines == null || rawHeadlines.Count < 1)
                      return rawHeadlines;

                  return rawHeadlines.Take(limit).ToList();
              }
              catch (Exception)
              {
                  return rawHeadlines;
              }
          };        
    }
}
