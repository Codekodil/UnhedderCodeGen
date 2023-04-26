using System.Text;

namespace TestWrapper
{
	[TestClass]
	public class HeaderTests
	{
		[TestMethod]
		public async Task RemoveWhitespace()
		{
			var file = new MemoryStream(Encoding.UTF8.GetBytes(@"
	A
		  bb				333
"));
			var header = await ParserHeader.NormalizeHeader(file);
			Assert.AreEqual("A bb 333", header.FilteredFile.ToString());
		}

		[TestMethod]
		public async Task SingleLineComments()
		{
			var file = new MemoryStream(Encoding.UTF8.GetBytes(@"
	A
		  bb		//		333
"));
			var header = await ParserHeader.NormalizeHeader(file);
			Assert.AreEqual("A bb", header.FilteredFile.ToString());
		}

		[TestMethod]
		public async Task IfPreprocessorComments()
		{
			var file = new MemoryStream(Encoding.UTF8.GetBytes(@"
#ifdef DEBUG
	A
#endif
		  bb				333
"));
			var header = await ParserHeader.NormalizeHeader(file);
			Assert.AreEqual("bb 333", header.FilteredFile.ToString());
		}
	}
}