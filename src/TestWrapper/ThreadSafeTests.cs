using TestNative.TestNative;

namespace TestWrapper
{
	[TestClass]
	public class ThreadSafeTests
	{
		[TestMethod]
		public async Task DisposeImidiatly()
		{
			await using var callbackContainer = new SafeObject();

			var safeObject = new SafeObject();

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};
			safeObject.ConnectToCallback(callbackContainer);

			await safeObject.DisposeAsync();

			Assert.AreEqual(1, callbacks.Count);
			Assert.AreEqual(-1, callbacks[0]);
		}

		[TestMethod]
		public async Task DisposeAfter()
		{
			await using var callbackContainer = new SafeObject();

			var safeObject = new SafeObject();

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};
			safeObject.ConnectToCallback(callbackContainer);
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
			Assert.AreEqual(-1, callbacks[2]);
			callbacks.Sort();
			Assert.AreEqual(1, callbacks[1]);
			Assert.AreEqual(2, callbacks[2]);
		}

		[TestMethod]
		public async Task DisposeDuring()
		{
			await using var callbackContainer = new SafeObject();

			var safeObject = new SafeObject();

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};
			safeObject.ConnectToCallback(callbackContainer);
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
			Assert.AreEqual(-1, callbacks[2]);
			callbacks.Sort();
			Assert.AreEqual(1, callbacks[1]);
			Assert.AreEqual(2, callbacks[2]);
		}

		[TestMethod]
		public async Task DisposeSpan()
		{
			await using var callbackContainer = new SafeObject();

			var safeObjects = new SafeObject?[16];

			safeObjects[0] = new SafeObject();
			safeObjects[1] = new SafeObject();
			safeObjects[2] = new SafeObject();
			safeObjects[3] = new SafeObject();

			safeObjects[6] = new SafeObject();
			safeObjects[7] = new SafeObject();
			safeObjects[8] = new SafeObject();
			safeObjects[9] = new SafeObject();

			safeObjects[11] = safeObjects[1];
			safeObjects[12] = safeObjects[2];
			safeObjects[13] = safeObjects[7];
			safeObjects[14] = safeObjects[8];

			var callbacks = new List<int>();
			callbackContainer.Callback += i =>
			{
				lock (callbacks)
					callbacks.Add(i);
			};

			var threadStarted = new TaskCompletionSource();
			var reset = new ManualResetEvent(false);
			foreach (var safeObject in safeObjects)
				if (safeObject != null)
					safeObject.Await += () =>
					{
						threadStarted.TrySetResult();
						reset.WaitOne();
					};

			new Thread(() => callbackContainer.ConnectAndWaitMultithread(safeObjects)).Start();

			await threadStarted.Task;

			var dispose = Task.WhenAll(safeObjects.OfType<SafeObject>().Select(safeObject => safeObject.DisposeAsync().AsTask()));

			reset.Set();

			await dispose;

			Assert.AreEqual(20, callbacks.Count);

			var freeable = 0;
			foreach (var callback in callbacks)
			{
				if (callback < 0)
					Assert.IsTrue(freeable-- > 0);
				else
					freeable++;
			}
			Assert.AreEqual(4, freeable);

			callbacks.Sort();
			for (int i = 0; i < 4; i++)
			{
				Assert.AreEqual(i, callbacks[i + 8]);
				Assert.AreEqual(i + 6, callbacks[i + 12]);
				Assert.AreEqual(i + 11, callbacks[i + 16]);
			}

		}
	}
}
