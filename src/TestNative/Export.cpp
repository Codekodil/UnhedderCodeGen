//Generated with https://github.com/Codekodil/UnhedderCodeGen
#include"pch.h"
#include"DifferentNamespaceParent.h"
#include"EventContainer.h"
#include"ExceptionObject.h"
#include"Lookups.h"
#include"PointerChild.h"
#include"PointerParent.h"
#include"SafeObject.h"
#include<memory>
#include<vector>
#include<string>
#include<exception>
thread_local std::string exceptionMessage="";
extern"C"{
__declspec(dllexport)void*__stdcall Wrapper_Shared_Ptr_Get(std::shared_ptr<void>*self){return self->get();}
__declspec(dllexport)int __stdcall Wrapper_Get_Exception(char*buffer,int maxSize){int length=std::min(maxSize,(int)exceptionMessage.size());memcpy(buffer,exceptionMessage.c_str(),length);return length;}
#pragma warning(push)
#pragma warning(disable:4297)


/*------------------------- NotTestNative::PointerParent -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<NotTestNative::PointerParent>*
	__stdcall Wrapper_New_NotTestNative_PointerParent_0
	(){try{
	auto pointer_result = new NotTestNative::PointerParent();
	return new std::shared_ptr<NotTestNative::PointerParent>(pointer_result);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_NotTestNative_PointerParent_SetChild_0
	(std::shared_ptr<NotTestNative::PointerParent>* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	(*self)->SetChild(
	(child_?child_->get():nullptr));
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_NotTestNative_PointerParent
	(std::shared_ptr<NotTestNative::PointerParent>* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::EventContainer -------------------------*/

//Constructors:

__declspec(dllexport)
	TestNative::EventContainer*
	__stdcall Wrapper_New_TestNative_EventContainer_0
	(){try{
	auto pointer_result = new TestNative::EventContainer();
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_EventContainer_Invoke_0
	(TestNative::EventContainer* self){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Invoke();
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_EventContainer_GetHash_1
	(TestNative::EventContainer* self,
	int n_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	int value_result;
	value_result=self->GetHash(
	n_);
	return value_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_EventContainer_PtrValue_2
	(TestNative::EventContainer* self){try{
	if(!self)throw std::exception("NullReferenceException");
	int value_result;
	value_result=self->PtrValue();
	return value_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_EventContainer_SendSelf_3
	(TestNative::EventContainer* self,
	int* index_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	self->SendSelf(
	index_);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_EventContainer_Event
	(TestNative::EventContainer* self,
	void
	(__stdcall*event)()){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Event=event;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_EventContainer_Hash
	(TestNative::EventContainer* self,
	int
	(__stdcall*event)(
	int n_
	)){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Hash=event;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_EventContainer_Ptr
	(TestNative::EventContainer* self,
	int*
	(__stdcall*event)()){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Ptr=event;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_EventContainer_Receive
	(TestNative::EventContainer* self,
	void
	(__stdcall*event)(
	void* ptr_,
	int* index_
	)){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Receive=event;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_EventContainer
	(TestNative::EventContainer* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::ExceptionObject -------------------------*/

//Constructors:

__declspec(dllexport)
	TestNative::ExceptionObject*
	__stdcall Wrapper_New_TestNative_ExceptionObject_0
	(){try{
	auto pointer_result = new TestNative::ExceptionObject();
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	TestNative::ExceptionObject*
	__stdcall Wrapper_New_TestNative_ExceptionObject_1
	(
	const char* message_
	){try{
	auto pointer_result = new TestNative::ExceptionObject(
	message_);
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_ExceptionObject_Throw_0
	(TestNative::ExceptionObject* self,
	const char* message_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Throw(
	message_);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_ExceptionObject_ThrowArgument_1
	(TestNative::ExceptionObject* self){try{
	if(!self)throw std::exception("NullReferenceException");
	self->ThrowArgument();
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_ExceptionObject
	(TestNative::ExceptionObject* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::LookupPointer -------------------------*/

//Constructors:

__declspec(dllexport)
	TestNative::LookupPointer*
	__stdcall Wrapper_New_TestNative_LookupPointer_0
	(){try{
	auto pointer_result = new TestNative::LookupPointer();
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	TestNative::LookupPointer*
	__stdcall Wrapper_New_TestNative_LookupPointer_1
	(
	std::shared_ptr<TestNative::LookupShared>* ptr_
	){try{
	auto pointer_result = new TestNative::LookupPointer(
	(ptr_?*ptr_:nullptr));
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	std::shared_ptr<TestNative::LookupShared>* 
	__stdcall Wrapper_Call_TestNative_LookupPointer_GetPtr_0
	(TestNative::LookupPointer* self){try{
	if(!self)throw std::exception("NullReferenceException");
	std::shared_ptr<TestNative::LookupShared> value_result;
	value_result=self->GetPtr();
	return (value_result?new std::shared_ptr<TestNative::LookupShared>(value_result):nullptr);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_LookupPointer
	(TestNative::LookupPointer* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::LookupShared -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::LookupShared>*
	__stdcall Wrapper_New_TestNative_LookupShared_0
	(){try{
	auto pointer_result = new TestNative::LookupShared();
	return new std::shared_ptr<TestNative::LookupShared>(pointer_result);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	std::shared_ptr<TestNative::LookupShared>*
	__stdcall Wrapper_New_TestNative_LookupShared_1
	(
	TestNative::LookupPointer* ptr_
	){try{
	auto pointer_result = new TestNative::LookupShared(
	ptr_);
	return new std::shared_ptr<TestNative::LookupShared>(pointer_result);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	TestNative::LookupPointer* 
	__stdcall Wrapper_Call_TestNative_LookupShared_GetPtr_0
	(std::shared_ptr<TestNative::LookupShared>* self){try{
	if(!self)throw std::exception("NullReferenceException");
	TestNative::LookupPointer* value_result;
	value_result=(*self)->GetPtr();
	return value_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_LookupShared
	(std::shared_ptr<TestNative::LookupShared>* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::PointerChild -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::PointerChild>*
	__stdcall Wrapper_New_TestNative_PointerChild_0
	(){try{
	auto pointer_result = new TestNative::PointerChild();
	return new std::shared_ptr<TestNative::PointerChild>(pointer_result);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_PointerChild_SumCharacters_0
	(std::shared_ptr<TestNative::PointerChild>* self,
	const char* text_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	int value_result;
	value_result=(*self)->SumCharacters(
	text_);
	return value_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerChild_ScaleSpan_1
	(std::shared_ptr<TestNative::PointerChild>* self,
	int* numbers_,int numbers_Size,
	int scale_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	(*self)->ScaleSpan(
	std::span<int>(numbers_,numbers_Size),
	scale_);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_PointerChild
	(std::shared_ptr<TestNative::PointerChild>* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::PointerParent -------------------------*/

//Constructors:

__declspec(dllexport)
	TestNative::PointerParent*
	__stdcall Wrapper_New_TestNative_PointerParent_0
	(
	short a_
	){try{
	auto pointer_result = new TestNative::PointerParent(
	a_);
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	TestNative::PointerParent*
	__stdcall Wrapper_New_TestNative_PointerParent_1
	(
	std::shared_ptr<TestNative::PointerChild>* child_
	){try{
	auto pointer_result = new TestNative::PointerParent(
	(child_?child_->get():nullptr));
	return pointer_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	int 
	__stdcall Wrapper_Call_TestNative_PointerParent_Double_0
	(TestNative::PointerParent* self,
	int a_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	int value_result;
	value_result=self->Double(
	a_);
	return value_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_Double_1
	(TestNative::PointerParent* self,
	int* a_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	self->Double(
	a_);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_SetChild_2
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	self->SetChild(
	(child_?child_->get():nullptr));
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	bool 
	__stdcall Wrapper_Call_TestNative_PointerParent_ChildEquals_3
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>* child_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	bool value_result;
	value_result=self->ChildEquals(
	(child_?*child_:nullptr));
	return value_result;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_FillNewChildren_4
	(TestNative::PointerParent* self,
	std::shared_ptr<TestNative::PointerChild>** children_,int children_Size
	){try{
	if(!self)throw std::exception("NullReferenceException");
	auto local_7875=std::vector<std::shared_ptr<TestNative::PointerChild>>(children_Size);for(int i_7875=0;i_7875<children_Size;i_7875++)local_7875[i_7875]=(children_[i_7875]?*children_[i_7875]:nullptr);
	self->FillNewChildren(
	std::span<std::shared_ptr<TestNative::PointerChild>>(&local_7875[0],children_Size));
	for(int i_7875=0;i_7875<children_Size;i_7875++)if(local_7875[i_7875]!=(children_[i_7875]?*children_[i_7875]:nullptr))children_[i_7875]=(local_7875[i_7875]?new std::shared_ptr<TestNative::PointerChild>(local_7875[i_7875]):nullptr);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_PointerParent_FillNewParents_5
	(TestNative::PointerParent* self,
	TestNative::PointerParent** parents_,int parents_Size
	){try{
	if(!self)throw std::exception("NullReferenceException");
	self->FillNewParents(
	std::span<TestNative::PointerParent*>(parents_,parents_Size));
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	std::shared_ptr<TestNative::PointerChild>* 
	__stdcall Wrapper_Call_TestNative_PointerParent_MaybeMake_6
	(TestNative::PointerParent* self,
	bool isNull_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	std::shared_ptr<TestNative::PointerChild> value_result;
	value_result=self->MaybeMake(
	isNull_);
	return (value_result?new std::shared_ptr<TestNative::PointerChild>(value_result):nullptr);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_PointerParent
	(TestNative::PointerParent* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}


/*------------------------- TestNative::SafeObject -------------------------*/

//Constructors:

__declspec(dllexport)
	std::shared_ptr<TestNative::SafeObject>*
	__stdcall Wrapper_New_TestNative_SafeObject_0
	(){try{
	auto pointer_result = new TestNative::SafeObject();
	return new std::shared_ptr<TestNative::SafeObject>(pointer_result);}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Methods:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_SafeObject_ConnectToCallback_0
	(std::shared_ptr<TestNative::SafeObject>* self,
	std::shared_ptr<TestNative::SafeObject>* target_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	(*self)->ConnectToCallback(
	(target_?target_->get():nullptr));
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_SafeObject_ConnectAndWaitMultithread_1
	(std::shared_ptr<TestNative::SafeObject>* self,
	std::shared_ptr<TestNative::SafeObject>** waiters_,int waiters_Size
	){try{
	if(!self)throw std::exception("NullReferenceException");
	auto local_1196=std::vector<std::shared_ptr<TestNative::SafeObject>>(waiters_Size);for(int i_1196=0;i_1196<waiters_Size;i_1196++)local_1196[i_1196]=(waiters_[i_1196]?*waiters_[i_1196]:nullptr);
	(*self)->ConnectAndWaitMultithread(
	std::span<std::shared_ptr<TestNative::SafeObject>>(&local_1196[0],waiters_Size));
	for(int i_1196=0;i_1196<waiters_Size;i_1196++)if(local_1196[i_1196]!=(waiters_[i_1196]?*waiters_[i_1196]:nullptr))waiters_[i_1196]=(local_1196[i_1196]?new std::shared_ptr<TestNative::SafeObject>(local_1196[i_1196]):nullptr);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Call_TestNative_SafeObject_WaitThenSend_2
	(std::shared_ptr<TestNative::SafeObject>* self,
	int callback_
	){try{
	if(!self)throw std::exception("NullReferenceException");
	(*self)->WaitThenSend(
	callback_);
	return ;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Events:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_SafeObject_Callback
	(std::shared_ptr<TestNative::SafeObject>* self,
	void
	(__stdcall*event)(
	int index_
	)){try{
	if(!self)throw std::exception("NullReferenceException");
	(*self)->Callback=event;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

__declspec(dllexport)
	void 
	__stdcall Wrapper_Event_TestNative_SafeObject_Await
	(std::shared_ptr<TestNative::SafeObject>* self,
	void
	(__stdcall*event)()){try{
	if(!self)throw std::exception("NullReferenceException");
	(*self)->Await=event;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}

//Delete:

__declspec(dllexport)
	void 
	__stdcall Wrapper_Delete_TestNative_SafeObject
	(std::shared_ptr<TestNative::SafeObject>* self){try{
	delete self;}
	catch(std::exception&e){exceptionMessage=e.what();throw;}catch(...){exceptionMessage="unknown";throw;}}
}
#pragma warning(pop)
