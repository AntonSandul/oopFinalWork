using Oop.WorkerDocument.Enums;

namespace Oop.WorkerDocument.Extensions
{
	public static class StringExtensions
	{
		public static bool IsEligibleDocumentTypeString(this string str)
		{
			if (str == null)
				return false;

			return Enum.GetNames(typeof(DocumentType)).Any(s => s.Equals(str, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
