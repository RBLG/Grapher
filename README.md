# Grapher

A grid based synthesizer 

![screenshot of the 3D editor](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/screenshot.PNG)

### Description:
Grapher is centered around the (Table/Grid/3D? name pending) editor. it is a table of values, similar to a F(x,y)= z graph except you customize the graph rather than the equation. Then customizing the 3 axis of the graph allow to define it how it evolve and what it change.

#### Example of common tools:
- Amplitude envelope:
  - Time as Length
  - Amplitude as Height
  
- Filter:
  - Frequency as Width
  - Amplitude as Height
  - (Time as Length for envelope)
  
- Phase modulation:
  - Time as Length
  - Phase as Height
  
- Tablewave-like:
  - Time Modulo as Width
  - Time as Length
  - Amplitude/Phase as Height
  
- Padding "modulation"
  - Time as Length
  - Padding as Height
  
and they can be combined, for example an envelope + filter:
![example of filter-envelloppe settup](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/highpassfilter_and_envelloppe.PNG)  
  
### Discord server:

Documentation is a bit lacking right now so dont hesitate asking directly if you got any question!
(considering how much people use that project i should be able to answer)

https://discord.gg/HqrgjEe3Tx

### How to install:

you can either:
- clone the repo
- open GrapherVST/GrapherVST.sln with Visual Studio
- build GrapherVST as Release
- use it by opening GrapherVST/bin/x64/Release/net5.0-windows/deploy/GrapherVST.dll with your daw

or:
- download the release zip
- use it by opening GrapherVST.dll with your daw

### To do: 
(not that i will do them but its what im considering)
- main detune
- in daw automation integration
- expanding synthesis range
- reordering modules
- advanced 3D edit features
- 3D UI better scaling
- other features

### Help needed:
- release automation
- linux compatibility (mono?)/port to Rust
