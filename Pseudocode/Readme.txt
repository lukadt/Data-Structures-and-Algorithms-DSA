Data Structures and Alogrithms (DSA) 
http://www.codeplex.com/dsa

Pseudocode information
21:49 28/10/2007

1. Pseudocode, why?

The pseudocode of all algorithms are provided as an educational tool.  This is to aid quick
understanding of the algorithms in the main DSA project, as well as providing an outlet to 
base other language implementations on. The abstraction is suffecient enough that you should
be able to implement everything in your preferred language.

2. Preconditions, Post conditions and returned data

All pseudocode algorithms have at most 3 main bits of data, these include:
	
- Pre (Preconditions): these are assumptions on the surrounding enviroment and state
 of objects which the algorithm interacts with. As an implementor you should enforce these
 preconditions in your own implementations.
- Post (Postconditions): this generally describes the outcome of running the algorithm, e.g.
 in a preorder traversal of a tree the postcondition would be that each node is visited in a 
 preorder fashion. You can extend this by adding more information, e.g. if your preorder traversal
 prints out the value of each node then this is a postcondition.
- Returns (optional): if for example you have an algorithm that returns some data to the caller, e.g.
 in the previous example I talked about preorder traversal - if your algorithm returns some collection
 with the visited nodes value then the collection should be stated here.

3. Conventions used

algorithm	This identifier should be followed by the name of the algorithm and any parameters in parentheses.
end			This identifier should be followed by the name of the algorithm or language construct that you want
			to indicate has terminated.
 
4. Operators used

<-			Assignment
=			Equality
!=			Inequality
!			Negation
null		Null (if you are doing this on paper then I would suggest using the empty set to be concise)