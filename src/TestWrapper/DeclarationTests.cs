namespace TestWrapper
{
	[TestClass]
	public class DeclarationTests
	{
		[TestMethod]
		public void EmptyNamespace()
		{
			var section = new StringSection("namespace Test { Empty }");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(1, declarations.Namespaces.Count);
			Assert.AreEqual("Test", declarations.Namespaces[0].Name);
			Assert.AreEqual("Empty ", declarations.Namespaces[0].Section.ToString());
		}

		[TestMethod]
		public void TwoNamespaces()
		{
			var section = new StringSection("namespace ns1 { hi im ns1!} namespace ns2 {and im here too :) }");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(2, declarations.Namespaces.Count);
			Assert.AreEqual("ns1", declarations.Namespaces[0].Name);
			Assert.AreEqual("hi im ns1!", declarations.Namespaces[0].Section.ToString());
			Assert.AreEqual("ns2", declarations.Namespaces[1].Name);
			Assert.AreEqual("and im here too :) ", declarations.Namespaces[1].Section.ToString());
		}

		[TestMethod]
		public void NestedNamespaces()
		{
			var section = new StringSection("namespace Outer { Before namespace Inner { Between } After }");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(1, declarations.Namespaces.Count);
			Assert.AreEqual("Outer", declarations.Namespaces[0].Name);
			Assert.AreEqual("Before namespace Inner { Between } After ", declarations.Namespaces[0].Section.ToString());
			Assert.AreEqual(1, declarations.Namespaces[0].Declarations.Namespaces.Count);
			Assert.AreEqual("Inner", declarations.Namespaces[0].Declarations.Namespaces[0].Name);
			Assert.AreEqual("Between ", declarations.Namespaces[0].Declarations.Namespaces[0].Section.ToString());
		}
	}
}
