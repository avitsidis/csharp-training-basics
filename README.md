# First exercice : Hello C# !

## Configuration, Assemblies, Types & Properties

### Configuration file

- add an appSettings entry named 'myparameter' with value 'foobar'
- Access Configuration content with System.Configuration.ConfigurationManager.AppSettings and print myparameter value in console output 

### Class Library
#### Assembly reference & properties
- create new assembly named HelloWorld.Model
- create a class Person 
    - add a string property LastName in Person
    - add a string property FirstName in Person
    - add a string property NISS in Person 
		- NISS can only contain digits
        - throw ArgumentException Exception if format is not correct
- add reference in HelloWorld to HelloWorld.Model
- in HelloWorld assembly, instanciate some Person objects and print them in the console
#### Computed property
- add a DateTime property Birthdate in Person
- add a Computed int property Age in Person (get only, no set)
#### inheritance & polymorphism
- override ToString() method in class Person (returns "FirstName LastName(NISS)")
- create a class Consultant that inherits from Person
- add a Date property Hiredate
- override ToString() method in class Person (returns "FirstName LastName(NISS) # years of experience")
- reimplement Birthdate to enforce that consultants must be older than 18 years old
    - this property must be polymorphic
	- throws InvalidArgument if Birthdate is less than 18 years ago
#### Assembly version
- change assembly version of Model to 2.0.0.0

### Nuget packages
- Install nuget package Colorful.Console
- use this library to change output to yellow in console