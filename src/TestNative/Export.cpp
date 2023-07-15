//Generated with https://github.com/Codekodil/UnhedderCodeGen
#include"pch.h"
#include"DifferentNamespaceParent.h"
#include"PointerChild.h"
#include"PointerParent.h"
#include"SafeObject.h"
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
	(self?self->get():nullptr)->SetChild(
	(child_?child_->get():nullptr));
	return ;}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_NotTestNative_PointerParent
	(std::shared_ptr<NotTestNative::PointerParent>* self){
	delete self;}


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
	(self?self->get():nullptr)->Invoke();
	return ;}

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_PointerChild_SumCharacters_1
	(std::shared_ptr<TestNative::PointerChild>* self,
	const char* text_
	){
	auto value_result=(self?self->get():nullptr)->SumCharacters(
	text_);
	return value_result;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerChild_ScaleSpan_2
	(std::shared_ptr<TestNative::PointerChild>* self,
	int* numbers_,int numbers_Size,
	int scale_
	){
	(self?self->get():nullptr)->ScaleSpan(
	std::span<int>(numbers_,numbers_Size),
	scale_);
	return ;}

//Events:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_PointerChild_Event
	(std::shared_ptr<TestNative::PointerChild>* self,
	void
	(__stdcall*event)()){
	(self?self->get():nullptr)->Event=event;}

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_PointerChild
	(std::shared_ptr<TestNative::PointerChild>* self){
	delete self;}


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
	(child_?child_->get():nullptr));
	return pointer_result;}

//Methods:

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_PointerParent_Double_0
	(TestNative::PointerParent* self,
	int a_
	){
	auto value_result=self->Double(
	a_);
	return value_result;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_SetChild_1
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	self->SetChild(
	(child_?child_->get():nullptr));
	return ;}

__declspec(dllexport)
	bool 
	__stdcall Wrapper_Call_TestNative_PointerParent_ChildEquals_2
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	auto value_result=self->ChildEquals(
	(child_?*child_:nullptr));
	return value_result;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_FillNewChildsShared_3
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>** children_,int children_Size
	){
	auto local_7875=std::vector<std::shared_ptr<TestNative::PointerChild>>(children_Size);for(int i_7875=0;i_7875<children_Size;i_7875++)local_7875[i_7875]=(children_[i_7875]?*children_[i_7875]:nullptr);
	self->FillNewChildsShared(
	std::span<std::shared_ptr<TestNative::PointerChild>>(&local_7875[0],children_Size));
	for(int i_7875=0;i_7875<children_Size;i_7875++)if(local_7875[i_7875]!=(children_[i_7875]?*children_[i_7875]:nullptr))children_[i_7875]=(local_7875[i_7875]?new std::shared_ptr<TestNative::PointerChild>(local_7875[i_7875]):nullptr);
	return ;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_FillNewChildsPointer_4
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>** children_,int children_Size
	){
	auto local_7759=std::vector<TestNative::PointerChild*>(children_Size);for(int i_7759=0;i_7759<children_Size;i_7759++)local_7759[i_7759]=(children_[i_7759]?children_[i_7759]->get():nullptr);
	self->FillNewChildsPointer(
	std::span<TestNative::PointerChild*>(&local_7759[0],children_Size));
	for(int i_7759=0;i_7759<children_Size;i_7759++)if(local_7759[i_7759]!=(children_[i_7759]?children_[i_7759]->get():nullptr))children_[i_7759]=(local_7759[i_7759]?new std::shared_ptr<TestNative::PointerChild>(local_7759[i_7759]):nullptr);
	return ;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_FillNewParents_5
	(TestNative::PointerParent* self,
	TestNative::PointerParent** parents_,int parents_Size
	){
	self->FillNewParents(
	std::span<TestNative::PointerParent*>(parents_,parents_Size));
	return ;}

__declspec(dllexport)
	std::shared_ptr<TestNative::PointerChild>* 
	__stdcall Wrapper_Call_TestNative_PointerParent_MaybeMakePointer_6
	(TestNative::PointerParent* self,
	bool isNull_
	){
	auto value_result=self->MaybeMakePointer(
	isNull_);
	return (value_result?new std::shared_ptr<TestNative::PointerChild>(value_result):nullptr);}

__declspec(dllexport)
	std::shared_ptr<TestNative::PointerChild>* 
	__stdcall Wrapper_Call_TestNative_PointerParent_MaybeMakeShared_7
	(TestNative::PointerParent* self,
	bool isNull_
	){
	auto value_result=self->MaybeMakeShared(
	isNull_);
	return (value_result?new std::shared_ptr<TestNative::PointerChild>(value_result):nullptr);}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_PointerParent
	(TestNative::PointerParent* self){
	delete self;}


/*------------------------- TestNative::SafeObject -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::SafeObject>*
	__stdcall Wrapper_New_TestNative_SafeObject_0
	(){
	auto pointer_result = new TestNative::SafeObject();
	return new std::shared_ptr<TestNative::SafeObject>(pointer_result);}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_SafeObject_ConnectToCallback_0
	(std::shared_ptr<TestNative::SafeObject>* self,
	std::shared_ptr<TestNative::SafeObject>* target_
	){
	(self?self->get():nullptr)->ConnectToCallback(
	(target_?target_->get():nullptr));
	return ;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_SafeObject_ConnectAndWaitMultithread_1
	(std::shared_ptr<TestNative::SafeObject>* self,
	std::shared_ptr<TestNative::SafeObject>** waiters_,int waiters_Size
	){
	auto local_1080=std::vector<TestNative::SafeObject*>(waiters_Size);for(int i_1080=0;i_1080<waiters_Size;i_1080++)local_1080[i_1080]=(waiters_[i_1080]?waiters_[i_1080]->get():nullptr);
	(self?self->get():nullptr)->ConnectAndWaitMultithread(
	std::span<TestNative::SafeObject*>(&local_1080[0],waiters_Size));
	for(int i_1080=0;i_1080<waiters_Size;i_1080++)if(local_1080[i_1080]!=(waiters_[i_1080]?waiters_[i_1080]->get():nullptr))waiters_[i_1080]=(local_1080[i_1080]?new std::shared_ptr<TestNative::SafeObject>(local_1080[i_1080]):nullptr);
	return ;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_SafeObject_WaitThenSend_2
	(std::shared_ptr<TestNative::SafeObject>* self,
	int callback_
	){
	(self?self->get():nullptr)->WaitThenSend(
	callback_);
	return ;}

//Events:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_SafeObject_Callback
	(std::shared_ptr<TestNative::SafeObject>* self,
	void
	(__stdcall*event)(
	int index_
	)){
	(self?self->get():nullptr)->Callback=event;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_SafeObject_Await
	(std::shared_ptr<TestNative::SafeObject>* self,
	void
	(__stdcall*event)()){
	(self?self->get():nullptr)->Await=event;}

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_SafeObject
	(std::shared_ptr<TestNative::SafeObject>* self){
	delete self;}
}