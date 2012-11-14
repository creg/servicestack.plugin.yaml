using ServiceStack.WebHost.Endpoints;

namespace ServiceStack.Plugin.Yaml
{
	public class AppStart
	{
		public static void Start()
		{
			EndpointHost.AddPlugin(new YamlFormat());
		}
	}
}
