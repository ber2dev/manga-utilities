using Mu.Client.Infrastructure;
using Mu.Client.Infrastructure.Actions;

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
