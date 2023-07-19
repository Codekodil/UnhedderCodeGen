using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class NativeParentTests
	{
		[TestMethod]
		public void ReturnValue()
		{
			using var parent = new PointerParent(2333);
			Assert.AreEqual(42, parent.Double(21));
		}

		[TestMethod]
		public void RefValue()
		{
			using var parent = new PointerParent(2333);
			var i = 21;
			parent.Double(ref i);
			Assert.AreEqual(42, i);
		}

		[TestMethod]
		public void PointersMatch()
		{
			using var parent = new PointerParent(2333);
			using var child = new PointerChild();
			using var notChild = new PointerChild();

			parent.SetChild(child);

			Assert.IsFalse(parent.ChildEquals(notChild));
			Assert.IsTrue(parent.ChildEquals(child));
		}

		[TestMethod]
		public void FillPointers()
		{
			var parent = new PointerParent(2333);

			var parents = new PointerParent?[5];
			parents[0] = new PointerParent(2333);
			parents[2] = parent;
			parents[3] = parent;

			var filled = parents.ToArray();

			parent.FillNewParents(filled);

			Assert.AreEqual(parents[0], filled[0]);

			Assert.IsNotNull(filled[1]);
			Assert.IsFalse(parents.Contains(filled[1]));

			Assert.AreEqual(parents[2], filled[2]);
			Assert.AreEqual(parents[3], filled[3]);

			Assert.IsNotNull(filled[4]);
			Assert.IsFalse(parents.Contains(filled[4]));
			Assert.AreNotEqual(filled[1], filled[4]);

			foreach (var dispose in filled)
				dispose!.Dispose();
		}

		[TestMethod]
		public void FillShared()
		{
			using var parent = new PointerParent(2333);

			var children = new PointerChild?[5];
			children[0] = new PointerChild();
			children[2] = new PointerChild();
			children[3] = children[2];

			var filled = children.ToArray();

			parent.FillNewChildren(filled);

			Assert.AreEqual(children[0], filled[0]);

			Assert.IsNotNull(filled[1]);
			Assert.IsFalse(children.Contains(filled[1]));

			Assert.AreEqual(children[2], filled[2]);
			Assert.AreEqual(children[3], filled[3]);

			Assert.IsNotNull(filled[4]);
			Assert.IsFalse(children.Contains(filled[4]));
			Assert.AreNotEqual(filled[1], filled[4]);

			foreach (var dispose in filled)
				dispose!.Dispose();
		}

		[TestMethod]
		public void SharedReturn()
		{
			using var parent = new PointerParent(2333);

			using var child = parent.MaybeMake(false);
			Assert.IsNotNull(child);

			var notChild = parent.MaybeMake(true);
			Assert.IsNull(notChild);
		}
	}
}
