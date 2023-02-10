using System.Text;
using Oop.WorkerDocument.Entities;

namespace Oop.WorkerDocument.Concrete
{
	public class MdDocument : WorkerDocumentBase
	{
		public MdDocument(Worker worker) : base(worker) { }

		public override void SaveAs()
		{
			var type = worker.GetType();
			var props = type.GetProperties();

			StringBuilder sb = new StringBuilder(type.Name)
						.Append(":").AppendLine();
			foreach (var prop in props)
			{
				var value = prop.GetValue(worker);
				sb.Append("* _").Append(prop.Name).Append("_: ")
				.Append(value ?? "Null").AppendLine();
			}
			Console.WriteLine(sb);
		}
	}
}
