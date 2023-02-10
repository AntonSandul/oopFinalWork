#nullable disable

using Oop.WorkerDocument.Abstract;

namespace Oop.WorkerDocument.Concrete
{
	public class PrettyButton : IButton
	{
		public void Click()
		{
			OnClicked();
		}

		public event EventHandler Clicked;

		protected void OnClicked()
		{
			var handler = Volatile.Read(ref Clicked);
			handler?.Invoke(this, EventArgs.Empty);
		}
	}
}
