namespace Mu.Client.Infrastructure.Actions
{
    public class SelectItemAction : ActionBase
    {
        public SelectItemAction(object pSource, object pSelectedItem)
            :base(pSource)
        {
            SelectedItem = pSelectedItem;
        }

        public object SelectedItem
        {
            get { return GetParameter<object>("SelectedItem"); }
            set { SetParameter("SelectedItem", value); }
        }
    }
}