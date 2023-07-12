//Generated with https://github.com/Codekodil/UnhedderCodeGen


/*------------------------- NotTestNative.PointerParent -------------------------*/

namespace TestNative.NotTestNative{
internal class PointerParent:IDisposable{public IntPtr?Native;public PointerParent(IntPtr?native)=>Native=native;

//Constructors:

public unsafe PointerParent
	(){
	Native=Wrapper_New_NotTestNative_PointerParent_0();
	}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_NotTestNative_PointerParent_0
	();

//Methods:

public unsafe void 
	SetChild
	(
	TestNative.PointerChild child
	){
	var local0=child.Native??throw new System.ObjectDisposedException(nameof(child));
	Wrapper_Call_NotTestNative_PointerParent_SetChild_0(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	local0);
	return ;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_NotTestNative_PointerParent_SetChild_0
	(IntPtr self,
	IntPtr child_
	);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~PointerParent()=>Wrapper_Delete();
	private void Wrapper_Delete(){
	if(!Native.HasValue)return;
	Wrapper_Delete_NotTestNative_PointerParent(Native.Value);
	Native=default;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_NotTestNative_PointerParent(IntPtr native);
}}


/*------------------------- TestNative.PointerChild -------------------------*/

namespace TestNative.TestNative{
internal class PointerChild:IDisposable{public IntPtr?Native;public PointerChild(IntPtr?native)=>Native=native;

//Constructors:

public unsafe PointerChild
	(){
	Native=Wrapper_New_TestNative_PointerChild_0();
	}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerChild_0
	();

//Methods:

public unsafe void 
	Invoke
	(){
	Wrapper_Call_TestNative_PointerChild_Invoke_0(Native??throw new System.ObjectDisposedException(nameof(PointerChild)));
	return ;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerChild_Invoke_0
	(IntPtr self);

public unsafe int 
	SumCharacters
	(
	string text
	){
	var value_result=Wrapper_Call_TestNative_PointerChild_SumCharacters_1(Native??throw new System.ObjectDisposedException(nameof(PointerChild)),
	text);
	return value_result;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern int Wrapper_Call_TestNative_PointerChild_SumCharacters_1
	(IntPtr self,
	[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string text_
	);

public unsafe void 
	ScaleSpan
	(
	int[] numbers,
	int scale
	){
	fixed(int*local1=numbers){
	Wrapper_Call_TestNative_PointerChild_ScaleSpan_2(Native??throw new System.ObjectDisposedException(nameof(PointerChild)),
	(IntPtr)local1,numbers.Length,
	scale);
	}
	return ;}
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
	public event EventDelegate Event{add{
	EventDelegate_Object+=value;
	if(Event_Delegate_Native_Object==null){
	Event_Delegate_Native_Object=(
	)=>
	EventDelegate_Object?.Invoke(
	);
	Wrapper_Event_TestNative_PointerChild_Event(Native??throw new System.ObjectDisposedException(nameof(PointerChild)),Event_Delegate_Native_Object);}}
	remove{EventDelegate_Object-=value;}}

//Delete:

public void Dispose()=>Wrapper_Delete();
	~PointerChild()=>Wrapper_Delete();
	private void Wrapper_Delete(){
	if(!Native.HasValue)return;
	if(Event_Delegate_Native_Object!=null){
	Wrapper_Event_TestNative_PointerChild_Event(Native.Value,null);
	Event_Delegate_Native_Object=null;}
	Wrapper_Delete_TestNative_PointerChild(Native.Value);
	Native=default;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_PointerChild(IntPtr native);
}}


/*------------------------- TestNative.PointerParent -------------------------*/

namespace TestNative.TestNative{
internal class PointerParent:IDisposable{public IntPtr?Native;public PointerParent(IntPtr?native)=>Native=native;

//Constructors:

public unsafe PointerParent
	(
	short a
	){
	Native=Wrapper_New_TestNative_PointerParent_0(
	a);
	}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerParent_0
	(
	short a_
	);

public unsafe PointerParent
	(
	TestNative.PointerChild child
	){
	var local2=child.Native??throw new System.ObjectDisposedException(nameof(child));
	Native=Wrapper_New_TestNative_PointerParent_1(
	local2);
	}
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
	){
	var value_result=Wrapper_Call_TestNative_PointerParent_Double_0(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	a);
	return value_result;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern int Wrapper_Call_TestNative_PointerParent_Double_0
	(IntPtr self,
	int a_
	);

public unsafe void 
	SetChild
	(
	TestNative.PointerChild child
	){
	var local3=child.Native??throw new System.ObjectDisposedException(nameof(child));
	Wrapper_Call_TestNative_PointerParent_SetChild_1(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	local3);
	return ;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerParent_SetChild_1
	(IntPtr self,
	IntPtr child_
	);

public unsafe bool 
	ChildEquals
	(
	TestNative.PointerChild child
	){
	var local4=child.Native??throw new System.ObjectDisposedException(nameof(child));
	var value_result=Wrapper_Call_TestNative_PointerParent_ChildEquals_2(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	local4);
	return value_result;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern bool Wrapper_Call_TestNative_PointerParent_ChildEquals_2
	(IntPtr self,
	IntPtr child_
	);

//Events:

//Delete:

public void Dispose()=>Wrapper_Delete();
	~PointerParent()=>Wrapper_Delete();
	private void Wrapper_Delete(){
	if(!Native.HasValue)return;
	Wrapper_Delete_TestNative_PointerParent(Native.Value);
	Native=default;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_PointerParent(IntPtr native);
}}
