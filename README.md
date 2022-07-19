# Grapher

a grid based synthesizer

![screenshot of the 3D editor](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/screenshot.PNG)

### How to install:

you can either:
- clone the repo
- open GrapherVST/GrapherVST.sln with Visual Studio
- build GrapherVST as Release
- use it by opening GrapherVST/bin/x64/Release/net5.0-windows/deploy/GrapherVST.dll with your daw

or:
- download the release zip
- use it by opening GrapherVST.dll with your daw

### How to use:
Grapher is composed of multiple modules. you can chain modules by using the Input setting

Here's some modules:
- 3D Editor:
  the main module. it allow you to modulate any property (on the Height axis) of a wave based on 2 others (the Width axis and Length axis)
  LH and WH Editors are variants with no Width or no Length for convenience

### Example:

- you can do both a filter and envelloppe (including filter envelloppes and sort of LFOs) with a 3D editor with:
  - Frequency as Width
  - Time as Length
  - Amplitude as Height

![example of filter-envelloppe settup](https://github.com/RBLG/Grapher/blob/master/Doc/imgs/highpassfilter_and_envelloppe.PNG)
  
- you can do phase modulation by using the phase axis as Height

- you can make your synth sound full by using the padding scale as Height, time as Length and a rapidly changing pattern
  
### In Construction:
- main detune
- release automation
- other features
