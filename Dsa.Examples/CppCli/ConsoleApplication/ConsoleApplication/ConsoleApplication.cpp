// ConsoleApplication.cpp : main project file.

#include "stdafx.h"

using namespace System;
using namespace Dsa::DataStructures;

/*Creates a SinglyLinkedListCollection(Of T) and then performs some common operations on the
collection.*/
void SinglyLinkedListCollectionExample() {
	SinglyLinkedListCollection<String ^>^ sll = gcnew SinglyLinkedListCollection<String ^>();
	sll->AddLast("Bing");
	sll->AddBefore(sll->Head, "Chandler");
	sll->AddFirst("Monica");
	sll->AddAfter(sll->Head, "Geller");
	for each (String^ s in sll) {
		Console::WriteLine(s);
	}
	array<String^>^ myArray = gcnew array<String^>(sll->Count);
	sll->CopyTo(myArray);
	Console::WriteLine();
	for each (String^ s in myArray) {
		Console::WriteLine(s);
	}
	Console::WriteLine();
	Console::WriteLine("Contains Joey? {0}", sll->Contains("Joey"));
	Console::WriteLine("Contains Monica? {0}", sll->Contains("Monica"));
	sll->Remove("Chandler");
	Console::WriteLine();
	for each (String^ s in sll) {
		Console::WriteLine(s);
	}
	sll->RemoveFirst();
	sll->RemoveLast();
	Console::WriteLine();
	Console::WriteLine("Head value: {0}, Tail value: {1}", sll->Head->Value, sll->Tail->Value);
}

/*Creates a QueueCollection(Of T) and then performs some common operations on the
collection.*/
void QueueCollectionExample() {
	QueueCollection<int>^ queue = gcnew QueueCollection<int>();
	queue->Enqueue(10);
	queue->Enqueue(20);
	queue->Enqueue(30);
	for each (int i in queue) {
		Console::WriteLine(i);
	}
	Console::WriteLine();
	Console::WriteLine("Dequeue: {0}", queue->Dequeue());
	Console::WriteLine();
	for each (int i in queue) {
		Console::WriteLine(i);
	}
	Console::WriteLine();
	Console::WriteLine("Peek: {0}", queue->Peek());
	Console::WriteLine("Count: {0}", queue->Count);
}

/*Creates a StackCollection(Of T) and then performs some common operations on the
collection.*/
void StackCollectionExample() {
	StackCollection<String^>^ stack = gcnew StackCollection<String^>();
	stack->Push("London");
	stack->Push("Paris");
	stack->Push("Berlin");
	for each (String^ s in stack) {
		Console::WriteLine(s);
	}
	Console::WriteLine();
	Console::WriteLine("Pop: {0}", stack->Pop());
	Console::WriteLine("Peek: {0}", stack->Peek());
	Console::WriteLine();
	Console::WriteLine("Contains New York? {0}", stack->Contains("New York"));
	Console::WriteLine("Contains London? {0}", stack->Contains("London"));
}

/*Creates a DoublyLinkedListCollection(Of T) and then performs some common operations on the
collection.*/
void DoublyLinkedListExample() {
	DoublyLinkedListCollection<int>^ dll = gcnew DoublyLinkedListCollection<int>();
	dll->AddLast(10);
	dll->AddLast(20);
	dll->AddLast(30);
	for each (int i in dll) {
		Console::WriteLine(i);
	}
	dll->Remove(20);
	for each (int i in dll) {
		Console::WriteLine(i);
	}
}

/*Creates a ArrayListCollection(Of T) and then performs some common operations on the
collection.*/
void ArrayListCollectionExample() {
	ArrayListCollection<String^>^ alc = gcnew ArrayListCollection<String^>();
	alc->Add("Paris");
	alc->Add("London");
	alc->Add("Berlin");
	for each (String^ s in alc) {
		Console::WriteLine(s);
	}
	alc[3] = "Dublin";
	for each (String^ s in alc) {
		Console::WriteLine(s);
	}
}

int main(array<System::String ^>^ args) {
	ArrayListCollectionExample();
    return 0;
}


