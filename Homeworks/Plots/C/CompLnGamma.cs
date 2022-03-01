using System;
using static System.Console;
using static System.Math;
using static cmath;
using static complex;

class main{
	public static complex G(complex x){
		if(x.Re<0) return (PI/cmath.sin(PI*x))/(G(1-x));
		if(x.Re<9) return (G(x+1))/(x);
		complex loggamma=x*cmath.log(x+1/(12*x-1/x/10))-x+cmath.log(2*PI/x)/2;
		return cmath.exp(loggamma);
	}

	public static void Main(){
		for(double x=-5; x<=5; x+=1.0/10){//BE CAREFUL with double x, as it then doesnt know how to use <, and will run differently in different architectures
			for(double y=-5; y<=5; y+=1.0/10){
				complex z = new complex(x,y);
				complex gamma = G(z);
				double absgamma = cmath.abs(gamma);
				WriteLine($"{z.Re} {z.Im} {absgamma}");;
			}
		}
	}
}