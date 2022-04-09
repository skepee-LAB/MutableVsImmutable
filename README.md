# MutableVsImmutable


Mutable VS Immutable

Mutable and immutable is not only a concept regarding an unchangable value (like constant or readonly) but it is intended also in terms of memory allocation (change/not change).
The following examples with documented screenshots will try to explain the concept for mutable and immutable types.

Let's take a simple example of string concatenation starting from a list of words and let's try to understand what it means to create an algorithm with mutable or immutable types.



Immutable Type
Definition:






Every time string value changes a new memory allocation will be allocated.
In the sequence of the following screenshots it is possible to see how on every iteration the address memory of resultImmutable changes. 
Take a look on the top left corner of the image: 


Mutable: 
As we can see on each iteration the memory allocation instantiated at the beginning does not change, but obviously the content changes (we are concatenating a word each time)



									|		Mutable    	   	|		Immutable    	|
				| Value				|	Address Memory 	   	|   Address Memory		|
Iteration 1 	| abbey				|	0x0000019780203C18 	|	0x0000019780019788	|
Iteration 2 	| abbey, absent		| 	0x0000019780203C18 	|	0x00000197800197B0	|
Iteration 510   | abbey, absent, ...|   0x0000019780203C18	|	0x0000019780201DB0	|














Test file is a text file with one word for each line.

Test 1:
--------------
FileSmall: 
Totale lines: 510
Disk space (Win10): 5 KB



Type		| Use Of			| Elpased Time  | Memory Allocation	|

Immutable	| String			|          (+)  | 		500 MB ca.

Mutable		| StringBuilder		|		   (-)  | 	



Test 2:
--------------
FileBig: 
Totale lines: 3740000
Disk space (Win10): 43829 KB


Type		| Use Of			| Elpased Time  | Memory Allocation	|

Immutable	| String			|    250ms (+)  | 		831 MB

Mutable		| StringBuilder		|		   (-)  | 	
