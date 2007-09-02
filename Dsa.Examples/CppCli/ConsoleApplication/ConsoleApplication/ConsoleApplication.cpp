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

int main(array<System::String ^>^ args) {
	SinglyLinkedListCollectionExample();
    return 0;
}


