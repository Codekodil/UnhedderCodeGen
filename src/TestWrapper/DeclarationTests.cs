namespace TestWrapper
{
	[TestClass]
	public class DeclarationTests
	{
		[TestMethod]
		public void EmptyNamespace()
		{
			var section = new StringSection("namespace Test { Empty }");
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Namespaces.Count);
			Assert.AreEqual("Test", declarations.Namespaces[0].Name);
			Assert.AreEqual("Empty ", declarations.Namespaces[0].Section.ToString());
		}

		[TestMethod]
		public void TwoNamespaces()
		{
			var section = new StringSection("namespace ns1 { hi im ns1!} namespace ns2 {and im here too :) }");
			var declarations = new ParserDeclaration(section, "test.h");
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
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Namespaces.Count);
			Assert.AreEqual("Outer", declarations.Namespaces[0].Name);
			Assert.AreEqual("Before namespace Inner { Between } After ", declarations.Namespaces[0].Section.ToString());
			Assert.AreEqual(1, declarations.Namespaces[0].Declarations.Namespaces.Count);
			Assert.AreEqual("Inner", declarations.Namespaces[0].Declarations.Namespaces[0].Name);
			Assert.AreEqual("Between ", declarations.Namespaces[0].Declarations.Namespaces[0].Section.ToString());
		}

		[TestMethod]
		public void EmptyClass()
		{
			var section = new StringSection("class Wrapper_Generate name { Empty }");
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual("name", declarations.Classes[0].Name);
			Assert.AreEqual(true, declarations.Classes[0].Pointer);
			Assert.AreEqual(false, declarations.Classes[0].Shared);
			Assert.AreEqual("Empty ", declarations.Classes[0].Section.ToString());
		}

		[TestMethod]
		public void ClassInsideNamespace()
		{
			var section = new StringSection("namespace Outer { Before class Wrapper_Shared Inner1 { Between } class Wrapper_Generate Inner2 { Between } After }");
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Namespaces.Count);
			Assert.AreEqual(2, declarations.Namespaces[0].Declarations.Classes.Count);
			Assert.AreEqual("Inner1", declarations.Namespaces[0].Declarations.Classes[0].Name);
			Assert.AreEqual(false, declarations.Namespaces[0].Declarations.Classes[0].Pointer);
			Assert.AreEqual(true, declarations.Namespaces[0].Declarations.Classes[0].Shared);
			Assert.AreEqual("Between ", declarations.Namespaces[0].Declarations.Classes[0].Section.ToString());
			Assert.AreEqual("Inner2", declarations.Namespaces[0].Declarations.Classes[1].Name);
			Assert.AreEqual(true, declarations.Namespaces[0].Declarations.Classes[1].Pointer);
			Assert.AreEqual(false, declarations.Namespaces[0].Declarations.Classes[1].Shared);
			Assert.AreEqual("Between ", declarations.Namespaces[0].Declarations.Classes[1].Section.ToString());
		}

		[TestMethod]
		public void ClassWithSimpleMethods()
		{
			var section = new StringSection("class name { void FLAGS M1();public: void Wrapper_Ignore M2();void M3 ( ) ; }");
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual("name", declarations.Classes[0].Name);
			Assert.AreEqual(1, declarations.Classes[0].Methods.Count);
			Assert.AreEqual("M3", declarations.Classes[0].Methods[0].Name);
		}



		[TestMethod]
		public void ClassWithMethodParameters()
		{
			var section = new StringSection("class name { public: void M(void p1, My::Custom : : Type p2);}");
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual(1, declarations.Classes[0].Methods.Count);
			Assert.AreEqual("M", declarations.Classes[0].Methods[0].Name);
			Assert.AreEqual(2, declarations.Classes[0].Methods[0].Parameters.Count);
			Assert.AreEqual("void", declarations.Classes[0].Methods[0].Parameters[0].Type.Name);
			Assert.AreEqual("p1", declarations.Classes[0].Methods[0].Parameters[0].Name);
			Assert.AreEqual("My::Custom::Type", declarations.Classes[0].Methods[0].Parameters[1].Type.Name);
			Assert.AreEqual("p2", declarations.Classes[0].Methods[0].Parameters[1].Name);
		}

		[TestMethod]
		public void ClassWithEvents()
		{
			var section = new StringSection("class name { public:void(__stdcall*e1)();byte *(__stdcall*e2)(std::span<int>i)=nullptr;private:void(stdcall*e3)();}");
			var declarations = new ParserDeclaration(section, "test.h");
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual(2, declarations.Classes[0].Events.Count);
			Assert.AreEqual("e1", declarations.Classes[0].Events[0].Name);
			Assert.AreEqual("void", declarations.Classes[0].Events[0].Result.Name);
			Assert.AreEqual(0, declarations.Classes[0].Events[0].Parameters.Count);
			Assert.AreEqual("e2", declarations.Classes[0].Events[1].Name);
			Assert.AreEqual("byte", declarations.Classes[0].Events[1].Result.Name);
			Assert.IsTrue(declarations.Classes[0].Events[1].Result.Pointer);
			Assert.AreEqual(1, declarations.Classes[0].Events[1].Parameters.Count);
			Assert.AreEqual("int", declarations.Classes[0].Events[1].Parameters[0].Type.Name);
			Assert.IsTrue(declarations.Classes[0].Events[1].Parameters[0].Type.Span);
			Assert.AreEqual("i", declarations.Classes[0].Events[1].Parameters[0].Name);
		}
	}
}
