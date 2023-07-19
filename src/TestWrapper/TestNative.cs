//Generated with https://github.com/Codekodil/UnhedderCodeGen


namespace TestNative{internal static class SharedPointer{[System.Runtime.InteropServices.DllImport("TestNative")]public static extern IntPtr Wrapper_Shared_Ptr_Get(IntPtr self);}}
namespace TestNative{internal class NativeException:Exception{private NativeException(string message):base(message){}[System.Runtime.InteropServices.DllImport("TestNative")]private static extern int Wrapper_Get_Exception(IntPtr buffer,int maxSize);public static unsafe Exception GetNative(){fixed(byte*buffer=stackalloc byte[128]){return System.Text.Encoding.ASCII.GetString(buffer,Wrapper_Get_Exception((IntPtr)buffer,128))switch{nameof(NullReferenceException)=>new NullReferenceException(),nameof(ArgumentException)=>new ArgumentException(),nameof(ArgumentNullException)=>new ArgumentNullException(),nameof(ArgumentOutOfRangeException)=>new ArgumentOutOfRangeException(),var message => new NativeException(message)};}}}}


/*------------------------- NotTestNative.PointerParent -------------------------*/

namespace TestNative.NotTestNative{
internal class PointerParent:IDisposable{public IntPtr?Native;public PointerParent(IntPtr?native){Native=native;}

//Constructors:

public unsafe PointerParent
	(){try{
	Native=Wrapper_New_NotTestNative_PointerParent_0();
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_NotTestNative_PointerParent_0
	();

//Methods:

public unsafe void 
	SetChild
	(
	TestNative.PointerChild? child
	){try{
	Wrapper_Call_NotTestNative_PointerParent_SetChild_0(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	(child==null?IntPtr.Zero:child!.Native??throw new System.ObjectDisposedException(nameof(child))));
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_NotTestNative_PointerParent_SetChild_0
	(IntPtr self,
	IntPtr child_
	);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~PointerParent()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	Wrapper_Delete_NotTestNative_PointerParent(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_NotTestNative_PointerParent(IntPtr native);
}}


/*------------------------- TestNative.ExceptionObject -------------------------*/

namespace TestNative.TestNative{
internal class ExceptionObject:IDisposable{public IntPtr?Native;public ExceptionObject(IntPtr?native){Native=native;}

//Constructors:

public unsafe ExceptionObject
	(){try{
	Native=Wrapper_New_TestNative_ExceptionObject_0();
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_ExceptionObject_0
	();

public unsafe ExceptionObject
	(
	string message
	){try{
	Native=Wrapper_New_TestNative_ExceptionObject_1(
	message);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_ExceptionObject_1
	(
	[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string message_
	);

//Methods:

public unsafe void 
	Throw
	(
	string message
	){try{
	Wrapper_Call_TestNative_ExceptionObject_Throw_0(Native??throw new System.ObjectDisposedException(nameof(ExceptionObject)),
	message);
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_ExceptionObject_Throw_0
	(IntPtr self,
	[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string message_
	);

public unsafe void 
	ThrowArgument
	(){try{
	Wrapper_Call_TestNative_ExceptionObject_ThrowArgument_1(Native??throw new System.ObjectDisposedException(nameof(ExceptionObject)));
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_ExceptionObject_ThrowArgument_1
	(IntPtr self);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~ExceptionObject()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	Wrapper_Delete_TestNative_ExceptionObject(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_ExceptionObject(IntPtr native);
}}


/*------------------------- TestNative.LookupPointer -------------------------*/

namespace TestNative.TestNative{
internal class LookupPointer:IDisposable{public IntPtr?Native;public LookupPointer(IntPtr?native){Native=native;}
internal class LookupPointerPointerLookup:PointerLookup<LookupPointer>{protected override LookupPointer New(IntPtr ptr)=>new LookupPointer((IntPtr?)ptr);protected override bool Shared()=>false;protected override void Delete(IntPtr ptr)=>Wrapper_Delete_TestNative_LookupPointer(ptr);}internal static readonly LookupPointerPointerLookup _lookup=new LookupPointerPointerLookup();

//Constructors:

public unsafe LookupPointer
	(){try{
	Native=Wrapper_New_TestNative_LookupPointer_0();
	_lookup.Add(this,Native.Value);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_LookupPointer_0
	();

public unsafe LookupPointer
	(
	TestNative.LookupShared? ptr
	){try{
	Native=Wrapper_New_TestNative_LookupPointer_1(
	(ptr==null?IntPtr.Zero:ptr!.Native??throw new System.ObjectDisposedException(nameof(ptr))));
	_lookup.Add(this,Native.Value);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_LookupPointer_1
	(
	IntPtr ptr_
	);

//Methods:

public unsafe TestNative.LookupShared? 
	GetPtr
	(){try{
	var value_result=Wrapper_Call_TestNative_LookupPointer_GetPtr_0(Native??throw new System.ObjectDisposedException(nameof(LookupPointer)));
	return TestNative.LookupShared._lookup.GetOrMake(value_result);}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_Call_TestNative_LookupPointer_GetPtr_0
	(IntPtr self);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~LookupPointer()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	Wrapper_Delete_TestNative_LookupPointer(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_LookupPointer(IntPtr native);
}}


/*------------------------- TestNative.LookupShared -------------------------*/

namespace TestNative.TestNative{
internal class LookupShared:IDisposable{public IntPtr?Native;public LookupShared(IntPtr?native){Native=native;}
internal class LookupSharedPointerLookup:PointerLookup<LookupShared>{protected override LookupShared New(IntPtr ptr)=>new LookupShared((IntPtr?)ptr);protected override bool Shared()=>true;protected override void Delete(IntPtr ptr)=>Wrapper_Delete_TestNative_LookupShared(ptr);}internal static readonly LookupSharedPointerLookup _lookup=new LookupSharedPointerLookup();

//Constructors:

public unsafe LookupShared
	(){try{
	Native=Wrapper_New_TestNative_LookupShared_0();
	_lookup.Add(this,Native.Value);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_LookupShared_0
	();

public unsafe LookupShared
	(
	TestNative.LookupPointer? ptr
	){try{
	Native=Wrapper_New_TestNative_LookupShared_1(
	(ptr==null?IntPtr.Zero:ptr!.Native??throw new System.ObjectDisposedException(nameof(ptr))));
	_lookup.Add(this,Native.Value);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_LookupShared_1
	(
	IntPtr ptr_
	);

//Methods:

public unsafe TestNative.LookupPointer? 
	GetPtr
	(){try{
	var value_result=Wrapper_Call_TestNative_LookupShared_GetPtr_0(Native??throw new System.ObjectDisposedException(nameof(LookupShared)));
	return TestNative.LookupPointer._lookup.GetOrMake(value_result);}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_Call_TestNative_LookupShared_GetPtr_0
	(IntPtr self);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~LookupShared()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	Wrapper_Delete_TestNative_LookupShared(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_LookupShared(IntPtr native);
}}


/*------------------------- TestNative.PointerChild -------------------------*/

namespace TestNative.TestNative{
internal class PointerChild:IDisposable{public IntPtr?Native;public PointerChild(IntPtr?native){Native=native;}

//Constructors:

public unsafe PointerChild
	(){try{
	Native=Wrapper_New_TestNative_PointerChild_0();
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerChild_0
	();

//Methods:

public unsafe void 
	Invoke
	(){try{
	Wrapper_Call_TestNative_PointerChild_Invoke_0(Native??throw new System.ObjectDisposedException(nameof(PointerChild)));
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerChild_Invoke_0
	(IntPtr self);

public unsafe int 
	SumCharacters
	(
	string text
	){try{
	var value_result=Wrapper_Call_TestNative_PointerChild_SumCharacters_1(Native??throw new System.ObjectDisposedException(nameof(PointerChild)),
	text);
	return value_result;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern int Wrapper_Call_TestNative_PointerChild_SumCharacters_1
	(IntPtr self,
	[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string text_
	);

public unsafe void 
	ScaleSpan
	(
	Span<int> numbers,
	int scale
	){try{
	fixed(int*local6423=numbers){
	Wrapper_Call_TestNative_PointerChild_ScaleSpan_2(Native??throw new System.ObjectDisposedException(nameof(PointerChild)),
	(IntPtr)local6423,numbers.Length,
	scale);
	}
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerChild_ScaleSpan_2
	(IntPtr self,
	IntPtr numbers_,int numbers_Size,
	int scale_
	);

//Events:

private delegate void Event_Delegate_Native(
	);
	private Event_Delegate_Native? Event_Delegate_Native_Object;
	[System.Runtime.InteropServices.DllImport("TestNative",CallingConvention=System.Runtime.InteropServices.CallingConvention.StdCall)]
	private static extern void Wrapper_Event_TestNative_PointerChild_Event
	(IntPtr self, Event_Delegate_Native? action);
	public delegate void EventDelegate(
	);
	private EventDelegate? EventDelegate_Object;
	public event EventDelegate Event{add{try{
	EventDelegate_Object+=value;
	if(Event_Delegate_Native_Object==null){
	Event_Delegate_Native_Object=(
	)=>
	EventDelegate_Object?.Invoke(
	);
	Wrapper_Event_TestNative_PointerChild_Event(Native??throw new System.ObjectDisposedException(nameof(PointerChild)),Event_Delegate_Native_Object);}}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	remove{EventDelegate_Object-=value;}}

//Delete:

public void Dispose()=>Wrapper_Delete();
	~PointerChild()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	if(Event_Delegate_Native_Object!=null){
	Wrapper_Event_TestNative_PointerChild_Event(Native.Value,null);
	Event_Delegate_Native_Object=null;}
	Wrapper_Delete_TestNative_PointerChild(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_PointerChild(IntPtr native);
}}


/*------------------------- TestNative.PointerParent -------------------------*/

namespace TestNative.TestNative{
internal class PointerParent:IDisposable{public IntPtr?Native;public PointerParent(IntPtr?native){Native=native;}

//Constructors:

public unsafe PointerParent
	(
	short a
	){try{
	Native=Wrapper_New_TestNative_PointerParent_0(
	a);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerParent_0
	(
	short a_
	);

public unsafe PointerParent
	(
	TestNative.PointerChild? child
	){try{
	Native=Wrapper_New_TestNative_PointerParent_1(
	(child==null?IntPtr.Zero:child!.Native??throw new System.ObjectDisposedException(nameof(child))));
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerParent_1
	(
	IntPtr child_
	);

//Methods:

public unsafe int 
	Double
	(
	int a
	){try{
	var value_result=Wrapper_Call_TestNative_PointerParent_Double_0(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	a);
	return value_result;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern int Wrapper_Call_TestNative_PointerParent_Double_0
	(IntPtr self,
	int a_
	);

public unsafe void 
	Double
	(
	ref int a
	){try{
	fixed(int*local6539=&a){
	Wrapper_Call_TestNative_PointerParent_Double_1(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	(IntPtr)local6539);
	}
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerParent_Double_1
	(IntPtr self,
	IntPtr a_
	);

public unsafe void 
	SetChild
	(
	TestNative.PointerChild? child
	){try{
	Wrapper_Call_TestNative_PointerParent_SetChild_2(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	(child==null?IntPtr.Zero:child!.Native??throw new System.ObjectDisposedException(nameof(child))));
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerParent_SetChild_2
	(IntPtr self,
	IntPtr child_
	);

public unsafe bool 
	ChildEquals
	(
	TestNative.PointerChild? child
	){try{
	var value_result=Wrapper_Call_TestNative_PointerParent_ChildEquals_3(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	(child==null?IntPtr.Zero:child!.Native??throw new System.ObjectDisposedException(nameof(child))));
	return value_result;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern bool Wrapper_Call_TestNative_PointerParent_ChildEquals_3
	(IntPtr self,
	IntPtr child_
	);

public unsafe void 
	FillNewChildren
	(
	Span<TestNative.PointerChild?> children
	){try{
	fixed(IntPtr*local7875=stackalloc IntPtr[children.Length]){for(int i7875=0;i7875<children.Length;i7875++)local7875[i7875]=((children[i7875])==null?IntPtr.Zero:(children[i7875])!.Native??throw new System.ObjectDisposedException(nameof(children)));
	Wrapper_Call_TestNative_PointerParent_FillNewChildren_4(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	(IntPtr)local7875,children.Length);
	for(int i7875=0;i7875<children.Length;i7875++)if(local7875[i7875]!=children[i7875]?.Native)children[i7875]=(local7875[i7875]==IntPtr.Zero?null:new TestNative.PointerChild((IntPtr?)local7875[i7875]));}
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerParent_FillNewChildren_4
	(IntPtr self,
	IntPtr children_,int children_Size
	);

public unsafe void 
	FillNewParents
	(
	Span<TestNative.PointerParent?> parents
	){try{
	fixed(IntPtr*local3372=stackalloc IntPtr[parents.Length]){for(int i3372=0;i3372<parents.Length;i3372++)local3372[i3372]=((parents[i3372])==null?IntPtr.Zero:(parents[i3372])!.Native??throw new System.ObjectDisposedException(nameof(parents)));
	Wrapper_Call_TestNative_PointerParent_FillNewParents_5(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	(IntPtr)local3372,parents.Length);
	for(int i3372=0;i3372<parents.Length;i3372++)if(local3372[i3372]!=parents[i3372]?.Native)parents[i3372]=(local3372[i3372]==IntPtr.Zero?null:new TestNative.PointerParent((IntPtr?)local3372[i3372]));}
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerParent_FillNewParents_5
	(IntPtr self,
	IntPtr parents_,int parents_Size
	);

public unsafe TestNative.PointerChild? 
	MaybeMake
	(
	bool isNull
	){try{
	var value_result=Wrapper_Call_TestNative_PointerParent_MaybeMake_6(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	isNull);
	return (value_result==IntPtr.Zero?null:new TestNative.PointerChild((IntPtr?)value_result));}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_Call_TestNative_PointerParent_MaybeMake_6
	(IntPtr self,
	bool isNull_
	);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~PointerParent()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	Wrapper_Delete_TestNative_PointerParent(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_PointerParent(IntPtr native);
}}


/*------------------------- TestNative.SafeObject -------------------------*/

namespace TestNative.TestNative{
internal class SafeObject:IAsyncDisposable{public IntPtr?Native;public SafeObject(IntPtr?native){Native=native;_safeGuard=new _SafeGuard(Wrapper_Delete);}

//Constructors:

public unsafe SafeObject
	(){try{
	Native=Wrapper_New_TestNative_SafeObject_0();
	_safeGuard=new _SafeGuard(Wrapper_Delete);
	}catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_SafeObject_0
	();

//Methods:

public unsafe void 
	ConnectToCallback
	(
	TestNative.SafeObject? target
	){try{
	using var selfLocker = _safeGuard.Lock(nameof(SafeObject));
	using var lock3223=target?._safeGuard.Lock(nameof(target));
	Wrapper_Call_TestNative_SafeObject_ConnectToCallback_0(Native!.Value,
	target!.Native!.Value);
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_SafeObject_ConnectToCallback_0
	(IntPtr self,
	IntPtr target_
	);

public unsafe void 
	ConnectAndWaitMultithread
	(
	Span<TestNative.SafeObject?> waiters
	){try{
	using var selfLocker = _safeGuard.Lock(nameof(SafeObject));
	fixed(IntPtr*local1196=stackalloc IntPtr[waiters.Length]){var locks1196=new _SafeGuard.DisposableLock?[waiters.Length];for(int i1196=0;i1196<waiters.Length;i1196++)locks1196[i1196]=waiters[i1196]==null?null:waiters[i1196]!._safeGuard.Lock(nameof(waiters));try{for(int i1196=0;i1196<waiters.Length;i1196++)local1196[i1196]=((waiters[i1196])==null?IntPtr.Zero:(waiters[i1196])!.Native??throw new System.ObjectDisposedException(nameof(waiters)));
	Wrapper_Call_TestNative_SafeObject_ConnectAndWaitMultithread_1(Native!.Value,
	(IntPtr)local1196,waiters.Length);
	for(int i1196=0;i1196<waiters.Length;i1196++)if(local1196[i1196]!=waiters[i1196]?.Native)waiters[i1196]=(local1196[i1196]==IntPtr.Zero?null:new TestNative.SafeObject((IntPtr?)local1196[i1196]));}finally{for(int i1196=0;i1196<waiters.Length;i1196++)locks1196[i1196]?.Dispose();}}
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_SafeObject_ConnectAndWaitMultithread_1
	(IntPtr self,
	IntPtr waiters_,int waiters_Size
	);

public unsafe void 
	WaitThenSend
	(
	int callback
	){try{
	using var selfLocker = _safeGuard.Lock(nameof(SafeObject));
	Wrapper_Call_TestNative_SafeObject_WaitThenSend_2(Native!.Value,
	callback);
	return ;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_SafeObject_WaitThenSend_2
	(IntPtr self,
	int callback_
	);

//Events:

private delegate void Callback_Delegate_Native(
	int index_);
	private Callback_Delegate_Native? Callback_Delegate_Native_Object;
	[System.Runtime.InteropServices.DllImport("TestNative",CallingConvention=System.Runtime.InteropServices.CallingConvention.StdCall)]
	private static extern void Wrapper_Event_TestNative_SafeObject_Callback
	(IntPtr self, Callback_Delegate_Native? action);
	public delegate void CallbackDelegate(
	int index);
	private CallbackDelegate? CallbackDelegate_Object;
	public event CallbackDelegate Callback{add{try{
	CallbackDelegate_Object+=value;
	if(Callback_Delegate_Native_Object==null){
	Callback_Delegate_Native_Object=(
	int index_)=>
	CallbackDelegate_Object?.Invoke(
	index_);
	using var selfLocker = _safeGuard.Lock(nameof(SafeObject));
	Wrapper_Event_TestNative_SafeObject_Callback(Native!.Value,Callback_Delegate_Native_Object);}}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	remove{CallbackDelegate_Object-=value;}}

private delegate void Await_Delegate_Native(
	);
	private Await_Delegate_Native? Await_Delegate_Native_Object;
	[System.Runtime.InteropServices.DllImport("TestNative",CallingConvention=System.Runtime.InteropServices.CallingConvention.StdCall)]
	private static extern void Wrapper_Event_TestNative_SafeObject_Await
	(IntPtr self, Await_Delegate_Native? action);
	public delegate void AwaitDelegate(
	);
	private AwaitDelegate? AwaitDelegate_Object;
	public event AwaitDelegate Await{add{try{
	AwaitDelegate_Object+=value;
	if(Await_Delegate_Native_Object==null){
	Await_Delegate_Native_Object=(
	)=>
	AwaitDelegate_Object?.Invoke(
	);
	using var selfLocker = _safeGuard.Lock(nameof(SafeObject));
	Wrapper_Event_TestNative_SafeObject_Await(Native!.Value,Await_Delegate_Native_Object);}}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	remove{AwaitDelegate_Object-=value;}}

//Delete:

internal _SafeGuard _safeGuard;
	public ValueTask DisposeAsync()=>new ValueTask(_safeGuard.DeleteAsync());
	~SafeObject()=>Wrapper_Delete();
	private void Wrapper_Delete(){try{
	if(!Native.HasValue)return;
	if(Callback_Delegate_Native_Object!=null){
	Wrapper_Event_TestNative_SafeObject_Callback(Native.Value,null);
	Callback_Delegate_Native_Object=null;}
	if(Await_Delegate_Native_Object!=null){
	Wrapper_Event_TestNative_SafeObject_Await(Native.Value,null);
	Await_Delegate_Native_Object=null;}
	Wrapper_Delete_TestNative_SafeObject(Native.Value);
	Native=default;}
	catch(System.Runtime.InteropServices.SEHException){throw NativeException.GetNative();}}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_SafeObject(IntPtr native);
}}


/*------------------------- SafeGuard -------------------------*/

namespace TestNative{
	internal class _SafeGuard{
	private readonly object _locker = new object();
	private int _callCount = 0;
	private TaskCompletionSource? _disposeTask;
	private Action _delete;
	public _SafeGuard(Action delete)=>_delete = delete;
	public DisposableLock Lock(string objectName)=>new DisposableLock(this, objectName);
	
	public Task DeleteAsync(){
	var doDelete=false;
	lock(_locker){if(_disposeTask==null){_disposeTask=new TaskCompletionSource();doDelete=_callCount==0;}}
	if(doDelete){try{_delete();_disposeTask.SetResult();}catch(Exception e){_disposeTask.SetException(e);}}
	return _disposeTask.Task;}
	public struct DisposableLock:IDisposable{
	private readonly _SafeGuard _guard;
	
	public DisposableLock(_SafeGuard guard,string objectName){
	_guard = guard;
	lock(guard._locker){if(guard._disposeTask!=null)throw new ObjectDisposedException(objectName);guard._callCount++;}}
	public void Dispose(){
	var doDelete=false;
	lock(_guard._locker){if(--_guard._callCount==0)doDelete=_guard._disposeTask!=null;}
	if(doDelete){try{_guard._delete();_guard._disposeTask!.SetResult();}catch(Exception e){_guard._disposeTask!.SetException(e);}}}}
	}}


/*------------------------- PointerLookup -------------------------*/

namespace TestNative{
	internal abstract class PointerLookup<T>where T:class{
	
	protected abstract T New(IntPtr ptr);
	protected abstract bool Shared();
	protected abstract void Delete(IntPtr ptr);
	
	private readonly Dictionary<IntPtr,WeakReference<T>>_references=new Dictionary<IntPtr,WeakReference<T>>();
	public PointerLookup(){PeriodicGC();
	async void PeriodicGC(){while(true){await Task.Delay(10000);lock(_references){
	var toRemove=new List<IntPtr>();
	foreach(var kv in _references)if(!kv.Value.TryGetTarget(out _))toRemove.Add(kv.Key);
	foreach(var remove in toRemove)_references.Remove(remove);}}}}
	
	public T GetOrMake(IntPtr ptr){lock(_references){var memory=Shared()?SharedPointer.Wrapper_Shared_Ptr_Get(ptr):ptr;
	if(!(_references.TryGetValue(memory,out var weak)&&weak.TryGetTarget(out var t)))_references[memory]=new WeakReference<T>(t=New(ptr));else if(Shared())Delete(ptr);return t;}}
	public void Add(T reference,IntPtr ptr){lock(_references)_references[Shared()?SharedPointer.Wrapper_Shared_Ptr_Get(ptr):ptr]=new WeakReference<T>(reference);}
	}}
