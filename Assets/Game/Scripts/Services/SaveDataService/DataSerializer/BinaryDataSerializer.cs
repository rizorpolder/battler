using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Game.Scripts.Services.SaveDataService.DataSerializer
{
	public class BinaryDataSerializer : IDataSerializer
	{
		public string Serialize<T>(T data)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using MemoryStream ms = new MemoryStream();

			bf.Serialize(ms, data);
			var bytes = ms.ToArray();
			return Encoding.UTF8.GetString(bytes);
		}

		public T Deserialize<T>(string str)
		{
			var bytes = Encoding.UTF8.GetBytes(str);
			using MemoryStream ms = new MemoryStream(bytes);
			BinaryFormatter formatter = new BinaryFormatter();
			return (T) formatter.Deserialize(ms);
		}
	}
}