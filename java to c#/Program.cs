using Oop.WorkerDocument.Abstract;
using Oop.WorkerDocument.Concrete;
using Oop.WorkerDocument.Entities;

namespace Oop.WorkerDocument
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			// Экземпляр сущности, что будем "сохранять":
			Worker worker = new Worker("William Gates", 123, 100500);

			// Создаём экземпляр нашей "сохранялки" в формате на выбор,
			// и передаём ему то, что надо сохранить:
			IDialog dialog = new SaveAsDialog(worker);

			// Запускаем "сохранялку", на этом этапе её цель -- выяснить у пользователя
			// в каком же формате сохранить переданное ей чудо:
			dialog.Start();

			// Имитируем нажатие кнопки "Сохранить" пользователем:
			dialog.ClickButton();
		}
	}
}
