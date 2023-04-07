using System.Numerics;
using NativeExample.Example;

namespace VectorTests
{
	[TestClass]
	public class ParameterTests
	{
		[TestMethod]
		public void Vec2Value()
		{
			using var m = new GlmMapping();
			Assert.AreEqual(3f, m.Sum2(new Vector2(1, 2)));
		}

		[TestMethod]
		public void Vec2Pointer()
		{
			using var m = new GlmMapping();
			var vec = new Vector2(1, 2);
			m.Double(ref vec);
			Assert.AreEqual(new Vector2(2, 4), vec);
		}

		[TestMethod]
		public void Vec3Value()
		{
			using var m = new GlmMapping();
			Assert.AreEqual(6f, m.Sum3(new Vector3(1, 2, 3)));
		}

		[TestMethod]
		public void Vec3Pointer()
		{
			using var m = new GlmMapping();
			var vec = new Vector3(1, 2, 3);
			m.Double(ref vec);
			Assert.AreEqual(new Vector3(2, 4, 6), vec);
		}

		[TestMethod]
		public void Vec4Value()
		{
			using var m = new GlmMapping();
			Assert.AreEqual(10f, m.Sum4(new Vector4(1, 2, 3, 4)));
		}

		[TestMethod]
		public void Vec4Pointer()
		{
			using var m = new GlmMapping();
			var vec = new Vector4(1, 2, 3, 4);
			m.Double(ref vec);
			Assert.AreEqual(new Vector4(2, 4, 6, 8), vec);
		}
	}
}
