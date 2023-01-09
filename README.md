# Mutable vs. Immutable


## Introduction

Mutable and immutable types are concepts regarding not only an unchangable value (like constant or readonly) but also about memory allocation.
This work will show an example with documented screenshots the concept that is under the hood.


## Use case: concatenation algorithm

A simple code example will help to understand practically when mutable or immutable types can be used. As a simple example let's consider a string concatenation algorithm starting from a list of words. Why choosing concatenation? First of all because concatenation is a very common topic in programming and then it helps to understand what happens in terms of memory allocation.
It is useful to know that as example the list of words that start with the following sequence:

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

Visual Studio offers some tools to check memory allocation in Debug Mode. One of these is Memory windows, for example, that enables address-level debugging by selecting Tools > Options (or Debug > Options) > Debugging > General.

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

![Immutable_2a](https://user-images.githubusercontent.com/13406481/163172098-b1e9c15d-3e2c-40d8-be02-8f3c2971a844.png)
<!--
![Immutable_2a](https://user-images.githubusercontent.com/13406481/162569090-94b00d3f-642f-4cfb-8a60-dafc9849ef76.png)
-->


---
### Iteration 2:
the following screenshot shows the memory allocation in the next iteration.

<!--
![Immutable_2b](https://user-images.githubusercontent.com/13406481/162569383-788e9ee7-b870-4b58-8045-e98adb6cbd07.png)
-->
![Immutable_2b](https://user-images.githubusercontent.com/13406481/163172160-0eb0c68f-7fa5-4ffd-85c4-b507050585a3.png)


On the second iteration we will have this situation: 
Iteration 2: value ```"abbey, absent,"``` memory address: ```0x00000197800197B0```

---
### Iteration 500:

![Immutable_2c](https://user-images.githubusercontent.com/13406481/163172198-a30ecc6b-6f74-4306-967d-c3c2c1157d13.png)
<!--
![Immutable_2c](https://user-images.githubusercontent.com/13406481/162572385-ccfc7e5c-02c1-405d-912b-f1a8efb33d3c.png)
-->

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

![Mutable_2a](https://user-images.githubusercontent.com/13406481/163172272-ebcd9923-d5db-4262-8552-b05f87dee06c.png)

<!--
![Mutable_2a](https://user-images.githubusercontent.com/13406481/162573629-3a36ae69-f455-4cbd-aff9-fa169cf70a9c.png)
-->
---

### Iteration 2: 

![Mutable_2b](https://user-images.githubusercontent.com/13406481/163172342-a249a68f-8497-4a44-887e-1ada219a0bd7.png)

<!--
![Mutable_2b](https://user-images.githubusercontent.com/13406481/162573658-043237fa-801c-4ab8-a51d-e41ca897a6f7.png)
-->

---
### Iteration 500: 

![Mutable_2c](https://user-images.githubusercontent.com/13406481/163172414-85eb7483-4ee8-4cf0-80c5-de4ba01b8c47.png)

<!--
![Mutable_2c](https://user-images.githubusercontent.com/13406481/162573685-ae9cd5bc-136a-4a2b-9f93-ed639ed48e5e.png)
-->

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




## A look at the performance
What about if we need to concatenate a long list of strings?
The following figures show the elaboration time by using immutable (String) and mutable (StringBuilder) type against a number of words.

![ImmutableGraph](https://user-images.githubusercontent.com/13406481/163165439-4684640b-4cea-4fb8-a5b1-e89f7d2d3b25.png)

![MutableGraph](https://user-images.githubusercontent.com/13406481/163165560-b96de71d-9f16-4922-b09d-594a535327d8.png)

As we can see mutable type has more performance, for mutable type the elaboration time when the list is very long tends to be exponential (look at the trend line). At the moment when I am writing this work the iteration for 5M words for mutable is still going ... 
On the other side by using mutable types the elaboration time is very fast. Just to give you an idea by reading the graph, in a quarter of sec it works 5M iterations of concatenations when by using mutable type it's not yet finished!!!!
Obviously the performance could be better by using async calls for example. The purpose of this work is not about perfomance but to give an idea of what happens when you use mutable or immutable types. 

##BenchamarkDotNet
This the benchmark by using [BenchamarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

|        Method |       Mean |     Error |    StdDev |     Gen0 |    Gen1 |  Allocated |
| ------------- |-----------:|----------:|----------:|---------:|--------:|-----------:|
|   MutableType |   5.888 us | 0.1170 us | 0.1889 us |   2.6245 |  0.1526 |   16.09 KB |
| ImmutableType | 135.286 us | 3.2935 us | 9.7109 us | 316.1621 | 15.0146 | 1937.41 KB |


## Final considerations
This work shows what happens when you work with ```mutable``` or ```immutables``` types.

The purpose of this work is not about perfomance but to give an idea of what happens when you use mutable or immutable types by using the same algorithm. 
This work shows under the hood how CLR handles memory allocation for mutable and immutable types.

As an example the same concatenation algorithm (very basic) has been used by using ```String``` as immutable type and ```StringBuilder``` as mutable type.
The figures show that by increasing the number of strings to concatenate the elaboration time has a linear trend line for ```mutable``` and exponenetial for ```immutable```. 

So, when you need to work with string concatenation, very common task in programming, this work suggests to use mutable type like StringBuilder and not immutable type.

Hope it helps!


