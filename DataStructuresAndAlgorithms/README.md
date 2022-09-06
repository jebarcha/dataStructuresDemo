# Data Structures

##Big-O Notation
We use **Big-O** notation to describe the performance of an algorithm
Measure the runtime complexity of an operation

### Linear Structures
* Arrays
* Linked List
* Stacks (LIFO, Pilas)
* Queues (FIFO, colas)
* Hash Tables

#### Arrays
Arrays in C# are static, it means has a fixed size
index starts with 0

####Linked List
We use Linked List to store a list of objects in sequence
but unlinke arrays, linked list can shrink and grow authomatically.

# Arrays vs Linked Lists
## SPACE
* Static arrays have a fixed size
* Dynamic arrays grow by 50-100%
* Linked list don't waste memory
* Use arrays is you know the number of items to store
* new ArrayList(100)

## Performance
Understand what problem you want to solve
				Arrays	Linked Lists
Lookup			O(1)	O(n)
				O(n)	O(n)
Insert	
  Beginning/End	O(n)	O(1)
  Middle		O(n)	O(n)
Delete  
  Beggining		O(n)	O(1)
  Middle		O(n)	O(n)
  End			O(n)	O(n)

# Types of Linked List
* SINGLY  [] -> [] -> []    Delete from the End O(n)
* DOUBLY  [] <-> [] <-> []  Delete from the End O(1)

Can be Circular, means that last node reference first node


####Stacks
We use Stacks to:
* Implement undo features in our applications
* Build compilers (eg syntax checking, parsing)
* Evaluate expresions (eg 1 + 2 * 3)
* Build navigations (eg forward/back)

The best way to understand **stacks** is to think of a stack of books
**LIFO** – Last In First Out principle

##### Operations 
* Push(item) Add an item at the top of the stack - O(1)
* Pop()      Removes an item from the top - O(1)
* Peek()     Returns the item of the top without removing it from the stack - O(1)
* IsEmpty()  Tell us if the stack is empty of not - O(1)

In stacks we don't have lookups because stack are not really mean for that.
We don't use stack to store a list of clients, products, etc. 

Stack can be used to resolve:
* The reverse string algorithm
* To verify if an expression is balanced (it contains all its open and closed parentesis, brackets, etc.)

#### Queues
Queues are similar to stacks except that the first item inserted is the first one to be removed (FIFO)
FIFO = First-In First-Out
It like a line in the real world, people join the line from the back and leave from the front 

##### Circular Arrays analysis
        // [60, 70, 30, 40, 50]
        // -> means "is map to"
        // 5  -> 0  Left % Length
        // 6  -> 1
        // 7  -> 2
        // 8  -> 3
        // 9  -> 4
        // 10 -> 0
        // 11 -> 1
        // rear + 1 (will give us the number of the left side and then should map it to the number of the right side)
        // (rear + 1) % length

