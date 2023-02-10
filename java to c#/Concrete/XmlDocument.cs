using System.Xml.Serialization;
using Oop.WorkerDocument.Entities;

namespace Oop.WorkerDocument.Concrete
{
	public class XmlDocument : WorkerDocumentBase
	{
		public XmlDocument(Worker worker) : base(worker) { }

		public override void SaveAs()
		{
			var writer = new StringWriter();
			var xmlSerializer = new XmlSerializer(worker.GetType());
			xmlSerializer.Serialize(writer, worker);
			Console.WriteLine(writer.ToString());
		}
	}
}