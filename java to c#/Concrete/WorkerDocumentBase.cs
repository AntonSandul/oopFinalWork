using Oop.WorkerDocument.Abstract;
using Oop.WorkerDocument.Entities;

namespace Oop.WorkerDocument.Concrete
{
	public abstract class WorkerDocumentBase : IDocument
	{
		protected Worker worker;

		public WorkerDocumentBase(Worker worker)
		{
			this.worker = worker ?? throw new NullReferenceException(nameof(worker));
		}

		public abstract void SaveAs();
	}
}
