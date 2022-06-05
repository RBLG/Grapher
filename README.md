# Grapher

a grid based synthesizer

![screenshot](https://github.com/RBLG/Grapher/blob/dev/res/examples/screenshot.png)

#How to install:

work in progress, so far you have to clone and compile yourself


#How to use:

Grapher is composed of the following modules that can be chained:

- Pitch:
  this module produce a sin wave of the note choosen. it is the default intput module for all module with inputs.

- Harmonic Editor:
  this module produce a base sin wave and/or it harmonics based on what you do with the interface


- 3D Editor:
  the main module. it modulate extensively the sound produced by it input based on the grid and the scales choosen for axis.
  for example:
  - with frequency on the width axis, time on the length axis and amplitude on the height axis, you can make both an envelloppe and/or a filter like this:

![screenshot](https://github.com/RBLG/Grapher/blob/dev/res/examples/highpassfilter_and_envelloppe.png)
  
  - you could also replace the amplitude scale on the height axis by frequency to do frequency modulation
  - you can also change the duration of the time scale to make it slower/faster

- 2D Editor:
  in the 3D editor you can change the length and width of the grid to get more or less resolution. when setting one or the other to 1, it will switch to 2D editor, which is basically a conventional graphic envelloppe editor... but it can do much more!
  you can open a 2D editor by default using LH Editor (length & height) or WH Editor (width & height) in the input menu. (the difference being visual format)

