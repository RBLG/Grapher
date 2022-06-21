#User Manual

###Modules
this synthesizer is organised in modules that can be chained one after the other. althought be aware that additionnal modules have a cpu cost
even so it will be optimised in the future

#####Main Screen
allow to choose for the root module.
you can edit it by clicking the pencil icon next to it.
the detune slider, well, detune (to be implemented).

#####Table Module/3D Editor
the core module of the synthesizer.
Input chose what Module will provide sound to be processed by the module.
Same than the main screen you can edit it by clicking the pencil button.

the brush section allow the following actions:
- change the brush size (the slider)
- change the brush type (to be implemented).
the grid is what impact your sound:
- it process the sound values based on current values based on the width and length units selected.
- by default those are frequency (in Hz) for the width and time (in ms) for the length.
- it process the sound by changing some properties of the sound defined by the 3rd axis, height, and applying a mathematical operation on it
- by default it change the amplitude property by multiplying it by between 0% and 200%

Axis settings allow to customize the Width, Length, Height axis/scale and how the value is impacted.

#####Pitch
the by default module. it has no interface and just prove a simple sinus wave at the note frequency

#####Harmo Editor
a variant of the 3D editor that allow you to add harmonics. 
(for now it is pretty basic and additionnal harmonics do have an additive cpu cost. still usable)


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
it is important to note that since frequency is calculated since the beginning of the note, frequency modulation is more and more intense
as time pass. (it still does reset every notes)
it is important to note that because of how stuff work internally, additionnal frequencies added by modulation are not handled exactly by frequencies
scales as they have very limited perception of the waves shapes

#####Exponantial Frequency
an axis/scale where the frequency distribution is rebalanced to be closer to human perception

#####Mei Frequency
an axis/scale using the Mei scale which give a distribution the closest to human perception.
computation might be a bit heavy, so use with care

#####Linear Amplitude
the amplitude axis. note that this value is only related to software output, i have no clue whats the unit too.
it is probably exponantial compared to decibels?

#####Padding
decide in which channel the output will be mostly played. it is completely linear with the minimum being completely on one side
while the maximum being completely on the other side

#####Phase
mostly an output scale. allow to modulate the phase of the wave. it is important to note that grid values arent cumulative so a spike will
first forward then modulate backward. (cumulative values should come in the future)

#####TODO
-note frequency related scales
-value axis/scale (to set directly the value)


###Modes/Actions
these are operations applied to the value given by the height scale.

#####Multiply
multiply the value by between 0% and 200%
the intensity option attenuate or increase that value compared to 100%

#####TODO
-add (add to the existing value)
-set (replace the value)









