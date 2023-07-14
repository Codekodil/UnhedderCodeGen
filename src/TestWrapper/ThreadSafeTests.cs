using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class ThreadSafeTests
	{
		[TestMethod]
		public async Task DisposeImidiatly()
		{
			using var callbackContainer = new SafeObject();

			var safeObject = new SafeObject();

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};
			safeObject.ConnectCallback(callbackContainer);

			await safeObject.DisposeAsync();

			Assert.AreEqual(1, callbacks.Count);
			Assert.AreEqual(-1, callbacks[0]);
		}

		[TestMethod]
		public async Task DisposeAfter()
		{
			using var callbackContainer = new SafeObject();

			var safeObject = new SafeObject();

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};
			safeObject.ConnectCallback(callbackContainer);
			var reset = new ManualResetEvent(false);
			safeObject.Await += () => reset.WaitOne();

			var thread1Done = new ManualResetEvent(false);
			var thread2Done = new ManualResetEvent(false);

			new Thread(() =>
			{
				safeObject.WaitThenSend(1);
				thread1Done.Set();
			}).Start();

			new Thread(() =>
			{
				safeObject.WaitThenSend(2);
				thread2Done.Set();
			}).Start();

			reset.Set();

			thread1Done.WaitOne();
			thread2Done.WaitOne();

			await safeObject.DisposeAsync();

			Assert.AreEqual(3, callbacks.Count);
			if (callbacks[0] == 1)
			{
				Assert.AreEqual(2, callbacks[1]);
			}
			else
			{
				Assert.AreEqual(2, callbacks[0]);
				Assert.AreEqual(1, callbacks[1]);
			}
			Assert.AreEqual(-1, callbacks[2]);
		}

		[TestMethod]
		public async Task DisposeDuring()
		{
			using var callbackContainer = new SafeObject();

			var safeObject = new SafeObject();

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};
			safeObject.ConnectCallback(callbackContainer);
			var reset = new ManualResetEvent(false);
			safeObject.Await += () => reset.WaitOne();

			var thread1Started = new ManualResetEvent(false);
			var thread2Started = new ManualResetEvent(false);

			new Thread(() =>
			{
				thread1Started.Set();
				safeObject.WaitThenSend(1);
			}).Start();

			new Thread(() =>
			{
				thread2Started.Set();
				safeObject.WaitThenSend(2);
			}).Start();

			thread1Started.WaitOne();
			thread2Started.WaitOne();

			var dispose = safeObject.DisposeAsync();

			reset.Set();

			await dispose;

			Assert.AreEqual(3, callbacks.Count);
			if (callbacks[0] == 1)
			{
				Assert.AreEqual(2, callbacks[1]);
			}
			else
			{
				Assert.AreEqual(2, callbacks[0]);
				Assert.AreEqual(1, callbacks[1]);
			}
			Assert.AreEqual(-1, callbacks[2]);
		}
	}
}
