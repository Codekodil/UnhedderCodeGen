//Generated with https://github.com/Codekodil/UnhedderCodeGen
#include"pch.h"
#include"DifferentNamespaceParent.h"
#include"Lookups.h"
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


/*------------------------- TestNative::LookupPointer -------------------------*/

//Constructors:

__declspec(dllexport)
	TestNative::LookupPointer*
	__stdcall Wrapper_New_TestNative_LookupPointer_0
	(){
	auto pointer_result = new TestNative::LookupPointer();
	return pointer_result;}

__declspec(dllexport)
	TestNative::LookupPointer*
	__stdcall Wrapper_New_TestNative_LookupPointer_1
	(
	std::shared_ptr<TestNative::LookupShared>* ptr_
	){
	auto pointer_result = new TestNative::LookupPointer(
	(ptr_?*ptr_:nullptr));
	return pointer_result;}

//Methods:

__declspec(dllexport)
	std::shared_ptr<TestNative::LookupShared>* 
	__stdcall Wrapper_Call_TestNative_LookupPointer_GetPtr_0
	(TestNative::LookupPointer* self){
	std::shared_ptr<TestNative::LookupShared> value_result;
	value_result=self->GetPtr();
	return (value_result?new std::shared_ptr<TestNative::LookupShared>(value_result):nullptr);}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_LookupPointer
	(TestNative::LookupPointer* self){
	delete self;}


/*------------------------- TestNative::LookupShared -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::LookupShared>*
	__stdcall Wrapper_New_TestNative_LookupShared_0
	(){
	auto pointer_result = new TestNative::LookupShared();
	return new std::shared_ptr<TestNative::LookupShared>(pointer_result);}

__declspec(dllexport)
	std::shared_ptr<TestNative::LookupShared>*
	__stdcall Wrapper_New_TestNative_LookupShared_1
	(
	TestNative::LookupPointer* ptr_
	){
	auto pointer_result = new TestNative::LookupShared(
	ptr_);
	return new std::shared_ptr<TestNative::LookupShared>(pointer_result);}

//Methods:

__declspec(dllexport)
	TestNative::LookupPointer* 
	__stdcall Wrapper_Call_TestNative_LookupShared_GetPtr_0
	(std::shared_ptr<TestNative::LookupShared>* self){
	TestNative::LookupPointer* value_result;
	value_result=(self?self->get():nullptr)->GetPtr();
	return value_result;}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_LookupShared
	(std::shared_ptr<TestNative::LookupShared>* self){
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
	int value_result;
	value_result=(self?self->get():nullptr)->SumCharacters(
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
	int value_result;
	value_result=self->Double(
	a_);
	return value_result;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_Double_1
	(TestNative::PointerParent* self,
	int* a_
	){
	self->Double(
	a_);
	return ;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_SetChild_2
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	self->SetChild(
	(child_?child_->get():nullptr));
	return ;}

__declspec(dllexport)
	bool 
	__stdcall Wrapper_Call_TestNative_PointerParent_ChildEquals_3
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){
	bool value_result;
	value_result=self->ChildEquals(
	(child_?*child_:nullptr));
	return value_result;}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_FillNewChildren_4
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>** children_,int children_Size
	){
	auto local_7875=std::vector<std::shared_ptr<TestNative::PointerChild>>(children_Size);for(int i_7875=0;i_7875<children_Size;i_7875++)local_7875[i_7875]=(children_[i_7875]?*children_[i_7875]:nullptr);
	self->FillNewChildren(
	std::span<std::shared_ptr<TestNative::PointerChild>>(&local_7875[0],children_Size));
	for(int i_7875=0;i_7875<children_Size;i_7875++)if(local_7875[i_7875]!=(children_[i_7875]?*children_[i_7875]:nullptr))children_[i_7875]=(local_7875[i_7875]?new std::shared_ptr<TestNative::PointerChild>(local_7875[i_7875]):nullptr);
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
	__stdcall Wrapper_Call_TestNative_PointerParent_MaybeMake_6
	(TestNative::PointerParent* self,
	bool isNull_
	){
	std::shared_ptr<TestNative::PointerChild> value_result;
	value_result=self->MaybeMake(
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
	auto local_1196=std::vector<std::shared_ptr<TestNative::SafeObject>>(waiters_Size);for(int i_1196=0;i_1196<waiters_Size;i_1196++)local_1196[i_1196]=(waiters_[i_1196]?*waiters_[i_1196]:nullptr);
	(self?self->get():nullptr)->ConnectAndWaitMultithread(
	std::span<std::shared_ptr<TestNative::SafeObject>>(&local_1196[0],waiters_Size));
	for(int i_1196=0;i_1196<waiters_Size;i_1196++)if(local_1196[i_1196]!=(waiters_[i_1196]?*waiters_[i_1196]:nullptr))waiters_[i_1196]=(local_1196[i_1196]?new std::shared_ptr<TestNative::SafeObject>(local_1196[i_1196]):nullptr);
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