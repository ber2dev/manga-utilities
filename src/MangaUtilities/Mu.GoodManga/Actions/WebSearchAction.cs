using Mu.Client.Infrastructure;

namespace Mu.GoodManga.Actions
{
    public class WebSearchAction : NoAction
    {
        public WebSearchAction(string pText)
        {
            SetParameter("SearchText", pText);
        }
    }
}
