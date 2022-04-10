# Mutable Vs Immutable


## Introduction

Mutable and immutable are concepts regarding not only an unchangable value (like constant or readonly) but also about memory allocation.
The following examples with documented screenshots will try to explain the concept that is behind.


## Use case: concatenation algorithm

A simple code example will help to understand practically when mutable or immutable types can be used. As a simple example let's consider a string concatenation algorithm starting from a list of words. Why choosing concatenation? First of all because concatenation is a very common topic in programming and then it helps to understand what happens in terms of memory allocation.
As example the file contains a list of 500 words that start with the following sequence:

```
abbey
absent
absolute
abstract
accessible
activate
active
...
```

and now let's implement a concatenation algorithm by using mutable and immutable types separately.
But, before that we need to set something in Visual Studio...

## Use the Memory windows in the Visual Studio debugger

Let's see what happens in terms of memory allocation. In order to do that we need to run the code in Debug Mode and put a breakpoint.
You need also to enable the Memory windows, enable address-level debugging must be selected in Tools > Options (or Debug > Options) > Debugging > General.

Start debugging by selecting the green arrow, pressing F5, or selecting Debug > Start Debugging.
Under Debug > Windows > Memory, select Memory 1, Memory 2, Memory 3, or Memory 4. (Some editions of Visual Studio offer only one Memory window.)
More info [here](https://docs.microsoft.com/en-us/visualstudio/debugger/memory-windows?view=vs-2022)


## Concatenation through immutable types

Let's consider a basic algorithm of concatenation by using immutable types. As a string ```resultImmutable``` is a immutable type. On each iteration it results that ```resultImmutable``` has a longer string by concatenating each element of the array.

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
---
### Iteration 1:
The memory window shows the memory address and allocation for the variables used at that time of running code.
Let's put our variable ```resultImmutable``` in the address box in top left corner and it will show the memory allocation at that moment.
The left side is the address memory, then a rappresentation of the hexadecimal code and finally the value that corresponds to ```abbey,``` as expected.

On the first iteration we will have this situation: 
Iteration 1: 
value ```"abbey,"```, memory address: ```0x0000019780019788```

![Immutable_2a](https://user-images.githubusercontent.com/13406481/162569090-94b00d3f-642f-4cfb-8a60-dafc9849ef76.png)

---
### Iteration 2:
the following screenshot shows the memory allocation in the next iteration.

![Immutable_2b](https://user-images.githubusercontent.com/13406481/162569383-788e9ee7-b870-4b58-8045-e98adb6cbd07.png)

On the second iteration we will have this situation: 
Iteration 2: value ```"abbey, absent,"``` memory address: ```0x00000197800197B0```

---
### Iteration 500:

![Immutable_2c](https://user-images.githubusercontent.com/13406481/162572385-ccfc7e5c-02c1-405d-912b-f1a8efb33d3c.png)

Iteration 500: value ```"abbey, absent, absolute, ..."``` memory address: ```0x0000019780201DB0```


#### Recap after all iterations (immutable):
As we can see at each iteration  ```resultImmutable``` value changes (obviously) in line with the memory allocation.

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
With the same logic, the following screenshots show the same as below for mutable iteration.

### Iteration 1: 

![Mutable_2a](https://user-images.githubusercontent.com/13406481/162573629-3a36ae69-f455-4cbd-aff9-fa169cf70a9c.png)
---

### Iteration 2: 

![Mutable_2b](https://user-images.githubusercontent.com/13406481/162573658-043237fa-801c-4ab8-a51d-e41ca897a6f7.png)

---
### Iteration 500: 

![Mutable_2c](https://user-images.githubusercontent.com/13406481/162573685-ae9cd5bc-136a-4a2b-9f93-ed639ed48e5e.png)


#### Recap after all iterations (mutable):
As we can see at each iteration  ```resultImmutable``` value changes (obviously) <ins>**but**</ins> the the memory address remains the same.
On each iteration the memory address ```0x0000019780203C18``` does not change, but obviously the content changes (we are concatenating a string each time) and more memory will be allocated but always starting from the same initial memory address.


## Recap after all iterations:
This summaries the result of both simulations:

| Iteration |        Value		| Address Memory `Mutable`| Address Memory `Immutable` |
|---------- |----------------------	|-------------------------|--------------------------- |
|     1     | abbey			|   0x0000019780203C18 	  |  0x0000019780019788	       |
|     2     | abbey, absent		|   0x0000019780203C18 	  |  0x00000197800197B0	       |
|     500   | abbey, absent, ...	|   0x0000019780203C18	  |  0x0000019780201DB0	       |














Test file is a text file with one word for each line.

Test 1:
--------------
FileSmall: 
Totale lines: 500
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
