# Grapher

A modular grid based synthesizer 

![screenshot of the 3D editor](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/screenshot.PNG)

### Description:
Grapher is an experimental synthesizer centered around the "table" editor. it is a grid of values, like a 3D graph which can be modified along with the graph's axis, which impact what characteristic of of the sound waves and how it is impacted.

by nature, it is very "all in one" as usual effects are present (the one i was aware of at least) but the modular architecture allow for more explorations around it

#### Example of common effects:
- Effect name: (width axis,length axis/height axis)

- Envelloppe: (Time/Amplitude)
  
- High/Low Pass filter: (Frequency/Time)
  
- Phase modulation: (Time/Phase)
  
and they can be combined, for example an envelope + filter:
![example of filter-envelloppe settup](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/highpassfilter_and_envelloppe.PNG)  

### Discord server:

Documentation is to be done, so dont hesitate asking directly on [discord](https://discord.gg/HqrgjEe3Tx) if you need anything!


### How to install:

you can either:
- download the release zip
- use it by opening Grapher**VST**.dll with your daw

or:
- clone the repository
- open GrapherVST/GrapherVST.sln with Visual Studio
- build GrapherVST as Release
- use it by opening GrapherVST/bin/x64/Release/net5.0-windows/deploy/Grapher**VST**.dll with your daw

please report any malfunction, it help a lot :)

### To do: 
- main detune
- ci/cd
- better table editor ergonomy
- better   set editor ergonomy
- implementation of compression-like features in table module
- more features
