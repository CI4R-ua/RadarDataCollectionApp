# RadarDataCollectionApp

This application aims to provide a functionality to record data from multiple sensors at same time via a single click.


## Data collecting process
Each radar comes with its own software for collecting the data. Below, explanation of how the application manages to connect with the radar and how it collects the data is provided. 

to collect data are explained. 


### Ancertok

The Graphical User Interface (SDR-GUI) is used to configure Ancertok radar and record the data. 

Progammatically : This application simulates the actual process of collecting the data. In other words, what you manually had
to do to start recording is now done by this application using [AutoIt scripting language](https://www.autoitscript.com/site/). 

### Kinect

Besides Kinect Studio (GUI), there is a tool named KSUtil that allows us to record data from the command line. To check the tool out, you can simply enter "KSUtil.exe" on the Windows command prompt. 

Progammatically: Records the data via command line. 

### Xethru

[ModuleConnector]( https://www.xethru.com/community/resources/module-connector-windows.78/), a DLL, is used to configure the Xethru modules (radar) and collect the data. 

Matlab script "C:\Users\RSL\Documents\Xethru\lib64\X4record2.m" accesses ModuleConnector and configures the radar. 


Programmatically: Executable, "X4record.exe", is provided with neccessary arguments and is then run. Initially, the data is dumped into another location but is moved to the right directory when the data becomes available. (More info in the code). 

### 77ghz

mmWave Studio software is used to configure the radar and collect the data from 77ghz radar. Since, mmWave Studio can only collect data for one radar at a time, each of the 77ghz radar has to have its own software on different computer.

Programmatically : The client-server model is used here to connect two computers. Client makes the connection with the server and once the connection is established, server asks the client to start collecting data for the 77ghz radar. The client code uses AutoIt scripting language to simulate the actual process of collecting data. 

Client code resides here => "C:\Users\Home\Desktop\Network_test\Windowsapplicationform1" 


