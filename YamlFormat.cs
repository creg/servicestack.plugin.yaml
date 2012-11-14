using System;
using System.IO;
using ServiceStack.Common.Web;
using ServiceStack.WebHost.Endpoints;
using YamlDotNet.RepresentationModel.Serialization;

namespace ServiceStack.Plugin.Yaml
{
	public class YamlFormat : IPlugin
	{
		public void Register(IAppHost appHost)
		{
			appHost.ContentTypeFilters.Register(ContentType.Yaml,
			                                    (reqCtx, res, stream) => Serialize(stream, res),
			                                    Deserialize);
		}

		private void Serialize(Stream stream, object res)
		{
			var yamlSerializer = new YamlSerializer(res.GetType());
			var writer = new StreamWriter(stream);
			yamlSerializer.Serialize(writer, res);
		}

		private object Deserialize(Type type, Stream fromStream)
		{
			var yamlSerializer = new YamlSerializer(type);
			var reader = new StreamReader(fromStream);
			return yamlSerializer.Deserialize(reader);
		}
	}
}
