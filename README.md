# Mutable Vs Immutable


## Introduction

Mutable and immutable are not only concepts regarding an unchangable value (like constant or readonly) but it is intended also in terms of memory allocation.
The following examples with documented screenshots will try to explain the concept that is behind.


## Use case: concatenation algorithm

A simple code example will help to understand practically when mutable or immutable types can be used. As a simple example let's consider a string concatenation algorithm starting from a list of words. Why choosing concatenation? First of all because concatenation is very common in programming and then it helps to understand what happens in terms of memory allocation.
So, let's try to understand what it means to create an algorithm with mutable or immutable types.


## Concatenation through immutable types

Let's consider a basic algorithm of concatenation by using immutable types. As a string ```resultImmutable``` is a immutable type. On each iteration it results that ```resultImmutable``` has a longer string by concatenating each string in words array.

```
private static string ConcatenateWordsImmutable(string[] words)
{
    string resultImmutable = string.Empty;

    foreach (string item in words)
    {
	resultImmutable += item + ",";
    }

    return resultImmutable;
}
```

## Use the Memory windows in the Visual Studio debugger
Let's see what happens in terms of memory allocation. In order to do that we need to run the code in Debug Mode and put a breakpoint in the algorithm.
You need also to enable the Memory windows, Enable address-level debugging must be selected in Tools > Options (or Debug > Options) > Debugging > General.
To open a Memory window
Make sure Enable address-level debugging is selected in Tools > Options (or Debug > Options) > Debugging > General.

Start debugging by selecting the green arrow, pressing F5, or selecting Debug > Start Debugging.
Under Debug > Windows > Memory, select Memory 1, Memory 2, Memory 3, or Memory 4. (Some editions of Visual Studio offer only one Memory window.)
More info [here](https://docs.microsoft.com/en-us/visualstudio/debugger/memory-windows?view=vs-2022)


Iteration 1:
The memory window shows the memory allocation for the variables used at that time of running code.
Let's put our variable ```resultImmutable``` in the address box in top left corner and it will show the memory allocation at that moment for that variable.
On the right side there is also rappresentation of the hexadecimal code and then going further on the right side there is the value that corresponds to ```abbey,``` as expected.

On the first iteration we will have this situation: 
Iteration 1: value ```"abbey,"```, memory address: ```0x0000019780019788```

![Immutable_2a](https://user-images.githubusercontent.com/13406481/162569090-94b00d3f-642f-4cfb-8a60-dafc9849ef76.png)

---
Iteration 2:
the follwing screenshot shows the memory allocation in the next iteration.

![Immutable_2b](https://user-images.githubusercontent.com/13406481/162569383-788e9ee7-b870-4b58-8045-e98adb6cbd07.png)

On the second iteration we will have this situation: 
Iteration 2: value ```"abbey, absent,"``` memory address: ```0x00000197800197B0```

---
Iteration 510:

![Immutable_2c](https://user-images.githubusercontent.com/13406481/162572385-ccfc7e5c-02c1-405d-912b-f1a8efb33d3c.png)

Iteration 510: value ```"abbey, absent, absolute, ..."``` memory address: ```0x0000019780201DB0```







## Concatenation through mutable types

Now let us consider concatenation through mutable type. The concatenation algorithm is basically the same, apart that our variable ```resultMutable``` is StringBuilder, mutable type.

```
private static string ConcatenateWordsMutable(string[] words)
{
    var resultMutable = new StringBuilder();

    foreach (string item in words)
    {
	resultMutable.Append(item).Append(",");
    }

    return resultMutable.ToString();
}
```








Immutable Type
Definition:

![Mutable_2a](https://user-images.githubusercontent.com/13406481/162573629-3a36ae69-f455-4cbd-aff9-fa169cf70a9c.png)

![Mutable_2b](https://user-images.githubusercontent.com/13406481/162573658-043237fa-801c-4ab8-a51d-e41ca897a6f7.png)




Every time string value changes a new memory allocation will be allocated.
In the sequence of the following screenshots it is possible to see how on every iteration the address memory of resultImmutable changes. 
Take a look on the top left corner of the image: 


Mutable: 
As we can see on each iteration the memory allocation instantiated at the beginning does not change, but obviously the content changes (we are concatenating a word each time)



		|		Mutable    	   	|		Immutable    	|
		| Value					|	Address Memory 	   	|   Address Memory		|
Iteration 1 	| abbey					|	0x0000019780203C18 	|	0x0000019780019788	|
Iteration 2 	| abbey, absent				| 	0x0000019780203C18 	|	0x00000197800197B0	|
Iteration 510   | abbey, absent, ...			|   0x0000019780203C18		|	0x0000019780201DB0	|














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
