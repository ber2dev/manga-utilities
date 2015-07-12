using System;
using System.Resources;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Mu.Client.Base
{
    public sealed class ResourceManagerHelper
    {
        private readonly ResourceManager _manager;

        public ResourceManagerHelper(ResourceManager manager)
        {
            _manager = manager;
        }

        public string GetString(string resourceName)
        {
            var resource = _manager.GetString(resourceName);
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new InvalidOperationException(
                    string.Format("No resource found or an empty value was defined for {0}", resourceName)
                );
            }

            return resource;
        }

        public BitmapSource GetIcon(string resourceName, string module)
        {
            var resourceDictionaryUri = new Uri(
                string.Format("/{0};component/{1}/Images.xaml", GetType().Assembly.GetName().Name, module),
                UriKind.RelativeOrAbsolute);

            var resourceDictionary = new ResourceDictionary { Source = resourceDictionaryUri };
            if (!resourceDictionary.Contains(resourceName))
            {
                throw new ArgumentException(string.Format("the resource {0} could not be found on resource dictionary {1}", resourceName, resourceDictionaryUri));
            }

            var resource = resourceDictionary[resourceName];
            return resource as BitmapSource;
        }
    }
}
