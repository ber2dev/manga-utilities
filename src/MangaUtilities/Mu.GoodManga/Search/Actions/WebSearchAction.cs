using Mu.Client.Infrastructure.Actions;

namespace Mu.GoodManga.Search.Actions
{
    public class WebSearchAction : NoAction
    {
        public WebSearchAction(string pText)
        {
            SetParameter("SearchText", pText);
        }
    }
}
