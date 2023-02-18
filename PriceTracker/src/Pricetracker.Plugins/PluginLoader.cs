using System.Reflection;

namespace PriceTracker.Plugins
{
    public interface IPluginLoader<T> where T : class
    {
        IEnumerable<Type> LoadPluginTypes(string location);
    }

    public class PluginLoader<T> : IPluginLoader<T> where T : class
    {
        public IEnumerable<Type> LoadPluginTypes(string location)
        {
            location = Environment.ExpandEnvironmentVariables(location);
            if (!Directory.Exists(location))
                return Enumerable.Empty<Type>();

            var types = new List<Type>();
            var dllFiles = Directory.GetFiles(location, "*.dll");
            foreach (var dllFile in dllFiles)
            {
                var dll = Assembly.LoadFile(dllFile);
                foreach (var type in dll.GetExportedTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(T)))
                    {
                        types.Add(type);
                    }
                }
            }
            return types;
        }
    }
}
