## vnamini_sharp

###Introduction

VNAMini is basically just a C# project to get data from a MiniVNA v1 mini vector network analyzer (VNA). MiniVNA's are used by amateur radio and electronics enthusiasts to measure the effectiveness of antennas, analyze electronic circuits, and many other things too. The MiniVNA is a relatively cheap VNA and, even though outdated and limited in functionality, is still a useful measurement tool. Having bought one a few years ago and written a Windows Mobile app for it, I decided it was time to write a version in C#.

The code here can be used simply as a program to get data from a MiniVNA, but the intention is that it provides a more useful function: an example of how to create your own C# code to customise your MiniVNA. I wrote the code using SharpDevelop with a Windows Form interface, so that it should be easily ported to Linux and OSX. SharpDevelop is free and open-source, allowing C# programming on more OS's than just Microsoft Windows, so seemed an excellent tool for creating this version of VNAMini.

###Current status

At the moment VNAMini is a work in progress and has very limited functionality, but that will change over time and updated code will be stored here. However, at the moment you can use the code to get data over a USB serial link or Bluetooth, view graphs of return loss and phase, and export the data to a CSV file to look at in a spreadsheet.

So even though there's still a lot to do, the code should provide useful information on how to use C# with a MiniVNA.
