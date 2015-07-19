using System.Linq;
using System.Xml.Linq;
using Mu.Core.Common;

namespace Mu.Core.Watch
{
    public class AlertCollection : CollectionBase<Alert>
    {
        public override void Save(IContext pContext)
        {
            var xml = XDocument.Load(pContext.DataFile);
            XElement altersContainer;
            var alters = xml.Descendants(XName.Get("Alerts"));
            if (!alters.Any())
            {
                altersContainer = alters.First();
            }
            else
            {
                altersContainer = new XElement(XName.Get("Alters"));
            }

            foreach (var item in Items)
            {
                var alert = item;
                
            }
        }

        public override void Load(IContext context)
        {
            var xml = XDocument.Load(context.DataFile);
        }
    }
}
