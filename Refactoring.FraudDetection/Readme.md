# Solution proposed for the Refactoring fraud detection challenge

## Introduction

To solve this challenge, I'd study the actual code and try to understand What it's the purpose of it. 
I ran it a few times too to check the tests and determine the correct behavior

**My Goals after refactorize it should be**
- Create an Order Builder to allow create Orders easier
- Create Normalizers that allow formatting his properties
- Change or extend new rules to detect new frauds
- Improve the algorithm to find frauds!

and

*The code will be*
- Easier to understand
- Allow extending any Class, almost all of it can be injected
- I created Empty constructors that allow using predefined behaviors
- Create a JSON Reader
- Create an extra new Rules to detect Fraud

## Implementation

I try to use this acronyms ever on my tasks
<pre>
- OOP   Object Oriented Programing
- KISS  Keep It Simple Stupid
- DRY   Don’t Repeat Yourself
- YAGNI You Aren’t Gonna Need It
- SOLID :D
</pre>

I'd avoid to include any extra *Nuget Package*, even it could help me to finish my challenge faster, but the idea is to probe my programming skills. (My thoughts)

**The Patterns that I choosed to implement was**
- Builder Pattern
- Template Pattern
- Repository Pattern
- Specification Pattern
- Strategy via Injection

**Clean code and Defensive Programming**
- Code readable
- Validating Method arguments
- Meaningful names for variables, functions, methods, classes, etc.
- I hate comments on code, I prefer that the code can explain by itself
- Body of functions smaller as possible

## Conclusions

Was a fun challenge! I'm afraid to abuse doing Overengineering

**Some notes**
- I'd migrated all projects to .NET Core 3.1 version
- I let some TODO on code :D
- I didn't create new extra projects but I used Folders to separate each Feature
- If order Files are **too huge** you could get issues with Memory and performance!
- The code it's ready to use any IoC engine, just need a bit configuration
- I din't create any Logger, each exception it's well documented

- I'm needing a real code review

**Find me around the web**

* My profile on [Linkedin](https://www.linkedin.com/in/patocl/?locale=en_US)
* Collaborating on [GitHub](https://github.com/patocl)
* Learning on [Pluralsight](https://app.pluralsight.com/profile/patocl) 
***