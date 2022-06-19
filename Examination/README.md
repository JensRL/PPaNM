# Examination Project 2 - Berrut Rational-Function Interpolation Algorithm
## Author: Jens Reersted Larsen
## Student Number 201807725 --> 25mod(23)=2

### Project Description and Implementation
This exam project revolves around the implementation of the Berrut rational-function(s) interpolation algorithm(s). The idea was first described by J.P. Berrut in 1988, in which two rational functions were proposed as possible interpolants. In this project the $B_1$ rational-function was implemented, given by the expression: 
$B_1=\frac{\sum_{i=0}\frac{(-1)^i}{x-x_i}y_i}{\sum_{i=0}\frac{(-1)^i}{x-x_i}}$ (note: summation limit is $n$). The $B_1$ expression was found in the "interpolation.pdf" notes (equation 38) or alternatively in the 1988 article *Rational Functions for Guaranteed and Experimentally Well-Conditioned Global Interpolation* by J.P. Berrut. The $B_1$ (and $B_2$) rational function(s) can be shown to have no poles on the real axis and is infinitely differentiable (Berrut 1988). The Berrut functions are supposed to be less suceptible to the Runge phenomenon, i.e. oscillatory behavior during interpolation between equally spaced datapoints, and this is what will be investigated for several cases in this project. More specifically, the results of the Berrut interpolation will be compared to the Quadratic and Cubic spline algorithms from the course for 4 separate interpolation cases. 

### Project Results
1. Classic Discontinuous Data Example
  - The classical data example exhibits a discontinuous jump in otherwise constant datapoints. In the figure "BerrutInterpClassic.pdf" it can be seen how the Berrut implementation is a drastic improvement to the quadratic spline. However, the cubic spline algorithm outperforms the Berrut $B_1$ after the first oscillation. 
2. Polynomial Example
  - The polynomial example considers the function $f(x)=3x+x^2\cdot sin(x)$, which has multiple local minima/maxima in the investigated region. The results can be seen in the figure "BerrutInterpPoly.pdf". The Berrut algorithm once more outperformed the quadratic spline, yet exhibits more oscillatory behavior than the cubic spline implementation. 
3. Gaussian Example 
  - The Gaussian example was a simple test to see if the interpolation algorithms could fit the much used Gaussian given by the function $f(x)=1/\sqrt{2\pi}\cdot e^{-x^2/2}$. The results can be seen as "BerrutInterpGaussian.pdf". All algorithms fit the data without any problems, as is to be expected with such a nice dataset of a smooth function. 
4. Damped Oscillator Example
  - The Damped Oscillator example utilizes the function $f(x)=sin(20x)-e^{-2x}$ to test the algorithms on a highly oscillatory and changing dataset. The Berrut algorithm initially fails to reduce the oscillatory behavior, just as the quadratic spline, but much faster recoveres the correct dampened trend. As before, the cubic spline outperforms the Berrut implementation. 

### Project Extension
As an extension to the project the Berrut $B_2$ rational-function interpolant was also implemented. This rational-function interpolant is given as: 
$B_2 = \frac{\frac{1}{x-x_0}y_0+2\sum_{i=1}\frac{(-1)^i}{x-x_i}y_i+\frac{(-1)^n}{x-x_n}y_n}{\frac{1}{x-x_0}+2\sum_{i=1}\frac{(-1)^i}{x-x_i}+\frac{(-1)^n}{x-x_n}}$ (note:summation limit is $n-1$).
The Berrut interpolants were compared for the Classic data and the damped oscillator examples only, and can be inspected in the figures "BerrutCompClassic.pdf" and "BerrutCompDampedOsc.pdf" respectively. The following correlations can be seen: 
1. Classic Discontinuous Data Example
  - The $B_1$ algorithm outperforms the $B_2$, while the $B_2$ still significantly improves upon the Qspline. Both Berrut rational-functions are still outperformed by the Cspline algorithm. 
2. Damped Oscillator Example
  - The $B_2$ interpolant improves upon the $B_1$ for the first oscillation, but falls off as the oscillations are damped. Both very nicely interpolates the damped oscillator example. 

It seems that the $B_1$ and $B_2$ implementations each favorable in different situations. The optimal choice of Berrut interpolant thus seems to depend on the given dataset/function.

### Project Evaluation
The Berrut $B_1$ Rational-Function interpolation algorithm was implemented and tested extensively across 4 cases. It always outperforms the Qspline implementation, but is generally inferior to the Cspline. Furthermore, the $B_2$ rational-function was also considered in 2 of the cases, in which it became apparent that the optimal choice of Berrut interpolant seems to depend on the given situation. I would consider the project a success, as the implemented algorithm(s) performed nicely across multiple test cases. In the cases prone to the Runge phenomenon, the Berrut implementations were shown to reduce the oscillatory behavior as expected. I would rate the project as extensively solved/considered, as the comparisons with Qspline/Cspline and the implementation of $B_2$ were outside the scope of the project goals. 
