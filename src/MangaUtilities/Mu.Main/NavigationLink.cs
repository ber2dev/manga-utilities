using System;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using Mu.Client.Infrastructure;

namespace Mu.Main
{
    public abstract class Link
    {
        private readonly string _label;
        private readonly string _description;
        private readonly BitmapImage _bitmapImage;

        protected Link(string label, string description, BitmapImage bitmapImage = null)
        {
            _label = label;
            _description = description;
            _bitmapImage = bitmapImage;
        }

        public string Label
        {
            get { return _label; }
        }

        public string Description
        {
            get { return _description; }
        }

        public BitmapImage Image
        {
            get { return _bitmapImage; }
        }

        public abstract IAction ToAction();
    }

    public class NavigationLink : Link
    {
        private readonly Type _viewType;

        public NavigationLink(string label, string description, Type viewType, BitmapImage bitmapImage = null)
            : base(label, description, bitmapImage)
        {
            _viewType = viewType;
        }

        public override IAction ToAction()
        {
            return new NavigationAction(_viewType);
        }
    }

    public class CategoryLink : Link
    {
        public CategoryLink(string label, string description, BitmapImage bitmapImage = null)
            : base(label, description, bitmapImage)
        {
        }

        public override IAction ToAction()
        {
            return new NoAction();
        }
    }
}
