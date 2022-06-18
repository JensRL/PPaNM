# Examination Project 2 - Berrut Rational-Function Interpolation Algorithm
## Author: Jens Reersted Larsen
## Student Number 201807725 --> 25mod(23)=2

### Project Description and Implementation
This exam project revolves around the implementation of the Berrut rational-function interpolation algorithm. The idea was first described by J.P. Berrut in 1988, in which two rational-function were proposed as possible interpolants. In this project the $B_1$ rational-function was implemented, given by the expression: 
$B_1=\frac{\sum_{i=0}^{n} \frac{(-1)^i}{x-x_i}y_i}{\sum_{i=0}^{n}\frac{(-1)^i}{x-x_i}}$. The $B_1$ expression was found in the "interpolation.pdf" notes (equation 38) or alternatively in the 1988 article *Rational Functions for Guaranteed and Experimentally Well-Conditioned Global Interpolation* by J.P. Berrut. The $B_1$ (and $B_2$) rational function(s) can be shown to have no poles on the real axis and is infinitely differentiable (Berrut 1988). The $B_1$ function is supposed to be less suceptible to the Runge phenomenon, i.e. oscillatory behavior during interpolation between equally spaced datapoints, and this is what will be investigated for several cases in this project. More specifically, the results of the Berrut interpolation will be compared to the Quadratic and Cubic spline algorithms from the course for 4 separate interpolation cases. 


$B_1=\frac{\sum_{i=0}^n\frac{(-1)^i}{x-x_i}y_i}{\sum\frac{(-1)^i}{x-x_i}}$



### Project Results
1. Classic Discontinous Data Example
  - The classical data example exhibits a discontinous jump in otherwise constant datapoints. In the figure "BerrutInterpClassic.pdf" it can be seen how the Berrut implementation is a drastic improvement to the quadratic spline. However, the cubic spline algorithm outperforms the Berrut. 
2. Polynomial Example
  - The polynomial example considers the function $f(x)=3x+x^2\cdot sin(x)$, which has multiple local minima/maxima in the investigated region. The results can be seen in the figure "BerrutInterpPoly.pdf". The Berrut algorithm once more outperformed the quadratic spline, yet exhibits more oscillatory behavior than the cubic spline implementation. 
3. Gaussian Example 
  - The Gaussian example was a simple test to see if the interpolation algorithms could fit the much used Gaussian given by the function $f(x)=1/\sqrt{2\pi}\exp(-x^2/2)$. The results can be seen as "BerrutInterpGaussian.pdf". All algorithms fit the data without any problems, as is to be expected with such a nice dataset of a smooth function. 
4. Damped Oscillator Example
  - The Damped Oscillator example utilizes the function $f(x)=\sin(20x)-\exp(-2x)$ to test the algorithms on a highly oscillatory and changing dataset. The Berrut algorithm initially fails to reduce the oscillatory behavior, just as the quadratic spline, but much faster recoveres the correct dampened trend. As before, the cubic spline outperforms the Berrut implementation. 

### Project Extension
$B_2$ was implemented?

### Project Evaluation
The Berrut Rational-Function interpolation algorithm was implemented and tested extensively across 4 cases. Furthermore...
