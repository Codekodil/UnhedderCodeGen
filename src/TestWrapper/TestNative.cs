//Generated with https://github.com/Codekodil/UnhedderCodeGen


/*------------------------- NotTestNative.PointerParent -------------------------*/

namespace TestNative.NotTestNative{
internal class PointerParent{public IntPtr?Native;public PointerParent(IntPtr?native)=>Native=native;

//Constructors:

public PointerParent
	(){
	Native=Wrapper_New_NotTestNative_PointerParent_0();}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_NotTestNative_PointerParent_0
	();
}}


/*------------------------- TestNative.PointerChild -------------------------*/

namespace TestNative.TestNative{
internal class PointerChild{public IntPtr?Native;public PointerChild(IntPtr?native)=>Native=native;

//Constructors:

public PointerChild
	(){
	Native=Wrapper_New_TestNative_PointerChild_0();}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerChild_0
	();
}}


/*------------------------- TestNative.PointerParent -------------------------*/

namespace TestNative.TestNative{
internal class PointerParent{public IntPtr?Native;public PointerParent(IntPtr?native)=>Native=native;

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
	var local0=child_.Native??throw new System.ObjectDisposedException(nameof(child_));
	Native=Wrapper_New_TestNative_PointerParent_1(
	local0);}
	[System.Runtime.InteropServices.DllImport("TestNative")]
	private static extern IntPtr Wrapper_New_TestNative_PointerParent_1
	(
	IntPtr child_
	);
}}
