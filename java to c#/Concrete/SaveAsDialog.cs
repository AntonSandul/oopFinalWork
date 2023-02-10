using Oop.WorkerDocument.Abstract;
using Oop.WorkerDocument.Entities;
using Oop.WorkerDocument.Enums;
using Oop.WorkerDocument.Extensions;

namespace Oop.WorkerDocument.Concrete
{
	public class SaveAsDialog : IDialog
	{
		private static readonly string AllowedInputs = string.Join(", ", Enum.GetNames(typeof(DocumentType)));
		private readonly Worker _worker;
		private readonly IButton _button;
		private IDocument? _document;

		public SaveAsDialog(Worker whatToSave)
		{
			_worker = whatToSave ?? throw new NullReferenceException(nameof(whatToSave));
			_button = new PrettyButton();
			_button.Clicked += ButtonClickedEventHandler;
		}

		private void ButtonClickedEventHandler(object? sender, EventArgs e)
		{
			if (_document == null)
			{
				Console.WriteLine("Ошибка: тип документа не задан.");
				return;
			}

			Console.WriteLine("Результат сохранения:");
			_document.SaveAs();
		}

		/// <summary>
		/// Эмуляция нажатия кнопки в диалоге сохранения.
		/// </summary>
		public void ClickButton()
		{
			Console.WriteLine("Нажата кнопка сохранения.");
			_button.Click();
		}

		public void Start()
		{
			PrintTitle();
			AskFormat();
			PrintSeparator();
		}

		private void AskFormat()
		{
			PrintSeparator();
			Console.WriteLine("Сохраняемый Worker:");
			Console.WriteLine(_worker.ToString());
			PrintSeparator();

			string? rawInput;
			while (true)
			{
				Console.Write($"Задайте тип документа ({AllowedInputs}): ");
				rawInput = Console.ReadLine();
				if (rawInput != null && rawInput.IsEligibleDocumentTypeString())
				{
					break;
				}
				else
				{
					Console.WriteLine("Некорректный ввод!"
					+ $" Допустимые варианты ввода: {AllowedInputs}."
					+ " Пожалуйста попробуйте ещё раз.");
				}
			}
			DocumentType docType = Enum.Parse<DocumentType>(rawInput, ignoreCase: true);
			CreateDocument(docType);
		}

		private void CreateDocument(DocumentType docType)
		{
			switch (docType)
			{
				case DocumentType.Xml:
					_document = new XmlDocument(_worker);
					break;
				case DocumentType.Md:
					_document = new MdDocument(_worker);
					break;
				case DocumentType.Json:
					_document = new JsonDocument(_worker);
					break;
				default:
					throw new NotImplementedException("Unsupported document format found.");
			}
		}

		private static void PrintTitle()
		{
			Console.WriteLine("\nДиалог Сохранения\n");
		}

		private static void PrintSeparator()
		{
			Console.WriteLine(new string('=', 40));
		}
	}
}
