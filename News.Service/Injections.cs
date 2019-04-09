using News.Util.D3Tree;
using News.Util.WebScraper;

namespace News.Service
{
    public static class Injections
    {
        #region Util Dependencies

        public static int InjectScraperServiceDependecies()
        {
            WebScraper.InjectDependencies();
            D3TreeNodeMaker.InjectDependencies();
            return 0;
        }

        #endregion
    }
}
