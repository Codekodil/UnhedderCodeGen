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


/*------------------------- TestNative::PointerChild -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::PointerChild>*
	__stdcall Wrapper_New_TestNative_PointerChild_0
	(){
	auto pointer_result = new TestNative::PointerChild();
	return new std::shared_ptr<TestNative::PointerChild>(pointer_result);}


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
}