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

int main(array<System::String ^>^ args) {
	QueueCollectionExample();
    return 0;
}


