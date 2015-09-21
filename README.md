# AncientTimesEditor
Game Editor developed for the Ancient Times Game

![](https://raw.githubusercontent.com/SimoneLocatelli/AncientTimesEditor/master/Editor.png)



This project is the Editor initially developed for the [Badasquall team] (https://www.facebook.com/BadaSquall) designed for their game Ancient Times.

Unfortunately the team decided to move to third party tools, so the project has been abandoned.
Even it's incomplete I decided to share it as it shows a nice example of maintanable and extensible architecture.

<h4>Architecture</h4>

- Solid classes decoupled in order to implement the Dependency Injection pattern
- Use of Managed Extensibility Framework (MEF) and Prism to make the application plugginable
- Look & Feel similar to Visual Studio 2013. 

<h4>Build</h4>

To build the project, navigate to the Build folder and execute the command:

```
  Build [Debug/Release]
```

<h4>Code structure</h4>

All the code lives under the Source folder. 
Navigating into it you can find all the projects that compose the "base" of the editor. 
Some of the most important projects are:

<ul>
  <li>Bootstrapper - entry point of the application</h4>
  <li>WindowShell  - contains the Editor windows, including the main one (displayed in the screenshot)</h4>
  <li>OutputWindow - similar to the Output Window from Visual Studio, it can helps the Dev to log messages.</h4>
</ul>

The editor is mainly composed by plugins and they all reside in the Plugins folder. They are retrieved at the startup of the 
execution scanning the Dlls in the same folder of the Bootstrapper. 

Using the plugins it was possible to separate the controls specific of the Badasquall team from the basic Editor parts.

