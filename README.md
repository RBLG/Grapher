# Grapher

A modular grid based synthesizer 

![screenshot of the 3D editor](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/screenshot.PNG)

### Description:
Grapher is centered around the "table" editor. it is a grid of values, like a 3D graph which can be modified along with the graph's axis, which impact what characteristic of of the sound waves and how it is impacted.

by nature, it is very "all in one" as usual effects are present (the one i was aware of at least) but the modular architecture allow for more explorations around it (at least thats the concept, althought it does already give interesting result!)

#### Example of common effects:
- Effect name: (width axis,length axis/height axis)
- 
- Envelloppe: (Time/Amplitude) ( a dedicated envelloppe will be added later, theres... some issues on short notes. (it still work))
  
- Pass filter: (Frequency/Time) (note that it is a bit cheaty so it wont be accurate if used after some effects adding a lot of frequencies)
  
- Phase modulation: (Time/Phase)
  
and they can be combined, for example an envelope + filter:
![example of filter-envelloppe settup](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/highpassfilter_and_envelloppe.PNG)  

my current favorite being the two modulo axis, which allow transitioning between rows/columns, which combined with phase modulation for example sound really neat!

### Discord server:

Documentation is a bit lacking right now so dont hesitate asking directly if you got any question!
(considering how much people use that project i should be able to answer)

https://discord.gg/HqrgjEe3Tx

### How to install:

you can either:
- clone the repo
- open GrapherVST/GrapherVST.sln with Visual Studio
- build GrapherVST as Release
- use it by opening GrapherVST/bin/x64/Release/net5.0-windows/deploy/Grapher**VST**.dll with your daw

or:
- download the release zip
- use it by opening Grapher**VST**.dll with your daw

### To do: 
- main detune
- ci/cd
- better table editor ergonomy
- better set   editor ergonomy
- stuff for compression in table module
- more features

### Help needed:
- linux compatibility
- testing if the release actually work and UI doesnt look insane (there was some w11 shenanigans)
