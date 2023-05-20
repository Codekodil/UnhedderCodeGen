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

		[TestMethod]
		public void EmptyClass()
		{
			var section = new StringSection("class FLAGS name { Empty }");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual("name", declarations.Classes[0].Name);
			Assert.AreEqual(1, declarations.Classes[0].Flags.Count);
			Assert.AreEqual("FLAGS", declarations.Classes[0].Flags[0]);
			Assert.AreEqual("Empty ", declarations.Classes[0].Section.ToString());
		}

		[TestMethod]
		public void ClassInsideNamespace()
		{
			var section = new StringSection("namespace Outer { Before class FL A GS Inner { Between } After }");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(1, declarations.Namespaces.Count);
			Assert.AreEqual(1, declarations.Namespaces[0].Declarations.Classes.Count);
			Assert.AreEqual("Inner", declarations.Namespaces[0].Declarations.Classes[0].Name);
			Assert.AreEqual(3, declarations.Namespaces[0].Declarations.Classes[0].Flags.Count);
			Assert.AreEqual("FL", declarations.Namespaces[0].Declarations.Classes[0].Flags[0]);
			Assert.AreEqual("A", declarations.Namespaces[0].Declarations.Classes[0].Flags[1]);
			Assert.AreEqual("GS", declarations.Namespaces[0].Declarations.Classes[0].Flags[2]);
			Assert.AreEqual("Between ", declarations.Namespaces[0].Declarations.Classes[0].Section.ToString());
		}

		[TestMethod]
		public void ClassWithSimpleMethods()
		{
			var section = new StringSection("class name { void F LAGS M1();public: void FLAG S M2();void M3 ( ) ; }");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual("name", declarations.Classes[0].Name);
			Assert.AreEqual(2, declarations.Classes[0].Methods.Count);
			Assert.AreEqual("M2", declarations.Classes[0].Methods[0].Name);
			Assert.AreEqual(2, declarations.Classes[0].Methods[0].Flags.Count);
			Assert.AreEqual("FLAG", declarations.Classes[0].Methods[0].Flags[0]);
			Assert.AreEqual("S", declarations.Classes[0].Methods[0].Flags[1]);
			Assert.AreEqual(0, declarations.Classes[0].Methods[1].Flags.Count);
			Assert.AreEqual("M3", declarations.Classes[0].Methods[1].Name);
		}



		[TestMethod]
		public void ClassWithMethodParameters()
		{
			var section = new StringSection("class name { public: void M(void p1, void p2);}");
			var declarations = new ParserDeclaration(section);
			Assert.AreEqual(1, declarations.Classes.Count);
			Assert.AreEqual(1, declarations.Classes[0].Methods.Count);
			Assert.AreEqual("M", declarations.Classes[0].Methods[0].Name);
			Assert.AreEqual(2, declarations.Classes[0].Methods[0].Parameters.Count);
			Assert.AreEqual("void", declarations.Classes[0].Methods[0].Parameters[0].Type.Name);
			Assert.AreEqual("p1", declarations.Classes[0].Methods[0].Parameters[0].Name);
			Assert.AreEqual("void", declarations.Classes[0].Methods[0].Parameters[1].Type.Name);
			Assert.AreEqual("p2", declarations.Classes[0].Methods[0].Parameters[1].Name);
		}
	}
}
