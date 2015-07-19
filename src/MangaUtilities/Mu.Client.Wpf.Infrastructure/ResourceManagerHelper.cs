using System;
using System.Resources;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Mu.Client.Wpf.Infrastructure
{
    public sealed class ResourceManagerHelper
    {
        private readonly ResourceManager _manager;

        public ResourceManagerHelper(ResourceManager pManager)
        {
            _manager = pManager;
        }

        public string GetString(string pResourceName)
        {
            var resource = _manager.GetString(pResourceName);
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new InvalidOperationException(
                    string.Format("No resource found or an empty value was defined for {0}", pResourceName)
                );
            }

            return resource;
        }

        public BitmapSource GetIcon(string pResourceName, string pModule)
        {
            var resourceDictionaryUri = new Uri(
                string.Format("/{0};component/{1}/Images.xaml", GetType().Assembly.GetName().Name, pModule),
                UriKind.RelativeOrAbsolute);

            var resourceDictionary = new ResourceDictionary { Source = resourceDictionaryUri };
            if (!resourceDictionary.Contains(pResourceName))
            {
                throw new ArgumentException(string.Format("the resource {0} could not be found on resource dictionary {1}", pResourceName, resourceDictionaryUri));
            }

            var resource = resourceDictionary[pResourceName];
            return resource as BitmapSource;
        }
    }
}
