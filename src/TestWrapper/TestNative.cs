//Generated with https://github.com/Codekodil/UnhedderCodeGen


/*------------------------- NotTestNative.PointerParent -------------------------*/

namespace TestNative.NotTestNative{
internal class PointerParent:IDisposable{public IntPtr?Native;public PointerParent(IntPtr?native)=>Native=native;

//Constructors:

public PointerParent
	(){
	Native=Wrapper_New_NotTestNative_PointerParent_0();}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_NotTestNative_PointerParent_0
	();

//Methods:

public void 
	SetChild
	(
	TestNative.PointerChild child_
	){
	var local0=child_.Native??throw new System.ObjectDisposedException(nameof(child_));
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

public PointerChild
	(){
	Native=Wrapper_New_TestNative_PointerChild_0();}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerChild_0
	();

//Methods:

public void 
	Invoke
	(){
	Wrapper_Call_TestNative_PointerChild_Invoke_0(Native??throw new System.ObjectDisposedException(nameof(PointerChild)));
	return ;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerChild_Invoke_0
	(IntPtr self);

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

public PointerParent
	(
	short a_
	){
	Native=Wrapper_New_TestNative_PointerParent_0(
	a_);}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerParent_0
	(
	short a_
	);

public PointerParent
	(
	TestNative.PointerChild child_
	){
	var local1=child_.Native??throw new System.ObjectDisposedException(nameof(child_));
	Native=Wrapper_New_TestNative_PointerParent_1(
	local1);}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerParent_1
	(
	IntPtr child_
	);

//Methods:

public int 
	Double
	(
	int a_
	){
	var value_result=Wrapper_Call_TestNative_PointerParent_Double_0(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	a_);
	return value_result;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern int Wrapper_Call_TestNative_PointerParent_Double_0
	(IntPtr self,
	int a_
	);

public void 
	SetChild
	(
	TestNative.PointerChild child_
	){
	var local2=child_.Native??throw new System.ObjectDisposedException(nameof(child_));
	Wrapper_Call_TestNative_PointerParent_SetChild_1(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	local2);
	return ;}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Call_TestNative_PointerParent_SetChild_1
	(IntPtr self,
	IntPtr child_
	);

public bool 
	ChildEquals
	(
	TestNative.PointerChild child_
	){
	var local3=child_.Native??throw new System.ObjectDisposedException(nameof(child_));
	var value_result=Wrapper_Call_TestNative_PointerParent_ChildEquals_2(Native??throw new System.ObjectDisposedException(nameof(PointerParent)),
	local3);
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
