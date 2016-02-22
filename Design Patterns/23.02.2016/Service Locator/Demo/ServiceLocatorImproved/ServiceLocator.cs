using System.Collections;

namespace ServiceLocatorImproved
{
	internal class ServiceLocator
	{
		private static readonly Hashtable services = new Hashtable();

		public static void AddService<T>(T t)
		{
			services.Add(typeof (T).Name, t);
		}

		public static void AddService<T>(string name, T t)
		{
			services.Add(name, t);
		}

		public static T GetService<T>()
		{
			return (T) services[typeof (T).Name];
		}

		public static object GetService<T>(string serviceName)
		{
			return (T) services[serviceName];
		}
	}
}