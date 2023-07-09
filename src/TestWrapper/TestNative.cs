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

//Delete:

public void Dispose(){
	if(Native.HasValue)
	Wrapper_Delete_NotTestNative_PointerParent(Native.Value);}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_NotTestNative_PointerParent(IntPtr native);
	~PointerParent()=>Dispose();
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

//Delete:

public void Dispose(){
	if(Native.HasValue)
	Wrapper_Delete_TestNative_PointerChild(Native.Value);}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_PointerChild(IntPtr native);
	~PointerChild()=>Dispose();
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

//Delete:

public void Dispose(){
	if(Native.HasValue)
	Wrapper_Delete_TestNative_PointerParent(Native.Value);}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern void Wrapper_Delete_TestNative_PointerParent(IntPtr native);
	~PointerParent()=>Dispose();
}}
