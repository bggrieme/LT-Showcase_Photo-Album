# LT Technical Showcase: Photo Album

This program downloads a json string from a given web address and then utilizes json.net and LINQ to produce a grouped listing of the json tokens acquired from the web address.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

.NET Core SDK (aim for version 3.1, though if you know what to edit in task.json and both .csproj files then I know this program will run on versions as early as 2.2): https://dotnet.microsoft.com/download 

Microsoft Visual Studio Code (henceforth, VSC): https://code.visualstudio.com/download

### Installing

Follow the installers for .NET Core and VSC.

Launch VSC. On the left about mid-window underneath a large "Start" there should be a blue "Add workspace folder" - click it!

A navigation window should open. Navigate to wherever you downloaded (and unzipped) the LT Showcase program. You'll want to select the folder that contains "LT Showcase.sln" and then click "Add".

Now that you've established a workspace, you should see several icons on the very left of the VSC window. If you hover over the bottom one it should label itself as "Extensions" - click it!

The navigation pane on the left will show many different extensions available to download. In the search bar towards the top of this pane type "C#". You're now looking for the C# extension authored by Microsoft - it should be the top result. Once you find it, click the green "Install" icon next to its name.

That's it! You should now be able to run this program.

## Running the program

At this point, you should be able to simply press F5 (or, "Debug" menu dropdown --> "Start Debugging").

## Running the tests

Click the "Terminal" menu dropdown and select "New Terminal".

A new Terminal pane opens at the bottom of VSC. The last line displayed should be the current workspace path. If not, navigate to the path that contains "LT Showcase.sln" using commands such as "cd .." to go up a level, and "cd your/intended/filepath/here" to navigate down levels.

Once you are at the correct directory, enter the command "dotnet test".

### THANKS!

-Benjamin Grieme
