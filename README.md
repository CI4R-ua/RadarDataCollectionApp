# RadarDataCollectionApp

This application aims to provide a functionality to record data from multiple sensors at same time via a single click.


Each radar has its own software for collecting the data. 


## Ancertok

The Graphical User Interface (SDR-GUI) is used to configure Ancertok radar and record the data. 

Progammatically : This application simulates the actual process of collecting the data. In other words, what you manually had
to do to start recording is now done by this application using [AutoIt scripting language](https://www.autoitscript.com/site/). 

## Kinect

Besides Kinect Studio (GUI), there is a tool named KSUtil that allows us to record data from the command line. To check the tool out, you can simply enter "KSUtil.exe" on the Windows command prompt. 

Progammatically: Records the data via command line. 

## Xethru

[ModuleConnector]( https://www.xethru.com/community/resources/module-connector-windows.78/), a DLL, is used to configure the Xethru modules (radar) and collect the data. 

Matlab script "X4record2.m" accesses ModuleConnector and connects 


Programmatically: 
