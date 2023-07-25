using TestNative;
using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class EventTests
	{
		[TestMethod]
		public void InvokeNativeAction()
		{
			using var container1 = new EventContainer();
			using var container2 = new EventContainer();

			var i = 0;
			void AddOne() => i++;
			container2.Event += AddOne;
			void DoTwiceDo()
			{
				container2.Invoke();
				i *= 2;
				container2.Invoke();
			};
			container1.Event += DoTwiceDo;
			container1.Invoke();
			container1.Invoke();
			container1.Invoke();
			container2.Event -= AddOne;
			container1.Invoke();
			container1.Event -= DoTwiceDo;
			container1.Invoke();

			Assert.AreEqual(42, i);
		}

		[TestMethod]
		public void InvokeNativeFunc()
		{
			using var container = new EventContainer();

			Assert.ThrowsException<NativeException>(() => container.GetHash(2333), "no hash");
			container.Hash += Hash;
			Assert.AreEqual(23333, container.GetHash(2333));
			container.Hash -= Hash;
			Assert.AreEqual(default, container.GetHash(2333));

			int Hash(int n) =>
				n * 10 + 3;
		}

		[TestMethod]
		public unsafe void InvokeNativeFuncPointerResult()
		{
			using var container = new EventContainer();

			var buffer = new int[1];
			fixed (int* ptr = buffer)
			{
				Assert.ThrowsException<NativeException>(() => container.PtrValue(), "no ptr");

				buffer[0] = 2333;
				var intPtr = (IntPtr)ptr;
				container.Ptr += Ptr;
				Assert.AreEqual(buffer[0], container.PtrValue());
				container.Ptr -= Ptr;
				Assert.ThrowsException<NativeException>(() => container.PtrValue(), "null ptr");

				IntPtr Ptr() => intPtr;
			}
		}

		[TestMethod]
		public unsafe void InvokeNativeActionPointerParameter()
		{
			using var container = new EventContainer();
			var buffer = new int[1];
			fixed (int* ptr = buffer)
			{
				var ptrs = new List<IntPtr>();

				Assert.ThrowsException<NativeException>(() => container.SendSelf(ref buffer[0]), "no receive");
				container.Receive += GetSelf;
				container.SendSelf(ref buffer[0]);
				container.Receive -= GetSelf;
				container.SendSelf(ref buffer[0]);

				Assert.AreEqual(1, buffer[0]);
				Assert.AreEqual(1, ptrs.Count);
				Assert.AreEqual(container.Native, ptrs[0]);

				void GetSelf(IntPtr ptr, ref int index)
				{
					ptrs.Add(ptr);
					index++;
				}
			}
		}

	}
}
