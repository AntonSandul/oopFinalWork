using System.Text.Json;
using Oop.WorkerDocument.Entities;

namespace Oop.WorkerDocument.Concrete
{
	public class JsonDocument : WorkerDocumentBase
	{
		public JsonDocument(Worker worker) : base(worker) { }

		public override void SaveAs()
		{
			var root = new { Worker = worker };
			var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
			{
				WriteIndented = true
			};
			string str = JsonSerializer.Serialize(root, root.GetType(), options);
			Console.WriteLine(str);
		}
	}
}
