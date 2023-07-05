//Generated with https://github.com/Codekodil/UnhedderCodeGen
#include"pch.h"
#include"DifferentNamespaceParent.h"
#include"PointerChild.h"
#include"PointerParent.h"
#include<memory>
#include<vector>
#include<string>
extern"C"{
__declspec(dllexport)void*__stdcall Wrapper_Shared_Ptr_Get(std::shared_ptr<void>*self){return self->get();}


/*------------------------- NotTestNative::PointerParent -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<NotTestNative::PointerParent>*
	__stdcall Wrapper_New_NotTestNative_PointerParent_0
	(){
	auto pointer_result = new NotTestNative::PointerParent();
	return new std::shared_ptr<NotTestNative::PointerParent>(pointer_result);}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_NotTestNative_PointerParent_SetChild_0
	(std::shared_ptr<NotTestNative::PointerParent>* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	self->get()->SetChild(
	child_->get());
	return ;}


/*------------------------- TestNative::PointerChild -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::PointerChild>*
	__stdcall Wrapper_New_TestNative_PointerChild_0
	(){
	auto pointer_result = new TestNative::PointerChild();
	return new std::shared_ptr<TestNative::PointerChild>(pointer_result);}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerChild_Invoke_0
	(std::shared_ptr<TestNative::PointerChild>* self){
	self->get()->Invoke();
	return ;}


/*------------------------- TestNative::PointerParent -------------------------*/

//Constructors:

__declspec(dllexport)
	TestNative::PointerParent*
	__stdcall Wrapper_New_TestNative_PointerParent_0
	(
	short a_
	){
	auto pointer_result = new TestNative::PointerParent(
	a_);
	return pointer_result;}

__declspec(dllexport)
	TestNative::PointerParent*
	__stdcall Wrapper_New_TestNative_PointerParent_1
	(
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	auto pointer_result = new TestNative::PointerParent(
	child_->get());
	return pointer_result;}

//Methods:

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_PointerParent_Double_0
	(TestNative::PointerParent* self,
	int a_
	){
	auto value_result = self->Double(
	a_);
	return value_result;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_SetChild_1
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	self->SetChild(
	child_->get());
	return ;}

__declspec(dllexport)
	bool 
	__stdcall Wrapper_Call_TestNative_PointerParent_ChildEquals_2
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	auto value_result = self->ChildEquals(
	*child_);
	return value_result;}
}