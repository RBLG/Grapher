#User Manual

###Modules
this synthesizer is organised in modules that can be chained one after the other. althought be aware that additionnal modules have a cpu cost
even so it will be optimised in the future

#####Main Screen
allow to choose for the root module.
you can edit it by clicking the pencil icon next to it.
the detune slider, well, detune (to be implemented).

#####Table Module
the core module of the synthesizer.
Input chose what Module will provide sound to be processed by the module.
Same than the main screen you can edit it by clicking the pencil button.

the table module impact the sound waves by applying an operation defined by the selected mode (for example, an addition or a multiplication)
on a value of the wave defined by the selected height axis (for example, phase or amplitude)
, which is chosen by looking in the table of values at the position of the current values of the selected width and length axis.

for example, i have selected time and frequency as width and length, and time is currently at 21ms and frequency for the wave is 400Hz, with a duration of 1000ms
for the time axis, it will then look at \[21/1000,400/20000\]. (20000 being the maximum value on the frequency axis)

it is important to note that additionnal frequencies from the table modules' operations wont get processed as new frequencies by subsequent table modules
 because of how it work internally but its fine most time and might be improved in the future (i got ideas :) )

the brush section allow to:
- change the brush size (the slider)
- change the brush type (to be implemented).

the axis section allow to:
- define the width and length input axis
- define the height output axis
- define the operation applied to the ouput

the editor section allow to:
- change visuals on table (to be implemented)

#####Pitch
the by default module. it has no interface and just prove a simple sinus wave at the note frequency

#####Set Module

basic module that allow defining a set of waves and their harmonics (to be processed by following table modules)

###Scales/Axis
the customizable axis found in the axis settings of the 3D editor

#####Default time
the default time axis. 
- Length: change the duration in ms of the table.
- Loop: loop once the end of the table is reached

#####Modulo Time
a funky( as, cool, it doesnt make your sound funky) axis/scale that change every X ms, allowing with the default time axis/scale
to have successing pattern side by side.
- the looping option make it loop once it is done
- the random option plays the patterns not ordered
- the chunk size is how much time until it change pattern (above mentionned X)

#####Linear Frequency
a simple frequency axis/scale. it has the effect of the high notes taking most place on the grid.

#####Exponantial Frequency
an axis/scale where the frequency distribution is rebalanced to be closer to human perception

#####Mei Frequency
an axis/scale using the Mei scale which give a distribution the closest to human perception.
computation might be a bit heavier (maybe?), so use with care

#####Linear Amplitude
the amplitude axis. note that this value is only related to software output, i have no clue whats the unit too, probably not decibels?

#####Padding
decide in which channel the output will be mostly played. it is completely linear with the minimum being completely on one side
while the maximum being completely on the other side. its padding, please handle with care, it WILL hurt to listen if too strong
(padding modulation is a bad idea, i can tell you that)

#####Phase
mostly an output scale. allow to modulate the phase of the wave. it is important to note that grid values arent cumulative so when adding phase, a spike will
first forward then modulate backward. (cumulative values should come in the future)

#####TODO
-note frequency related scales
-value axis/scale (to set directly the value)


###Modes/Actions
these are operations applied to the value given by the height scale.

#####Multiply
multiply the value by between 0% and 200%
the intensity option attenuate or increase that value compared to 100%

#####Add
add the value

#####Set
replace the existing value by the value from the table

#####TODO
-min
-max









