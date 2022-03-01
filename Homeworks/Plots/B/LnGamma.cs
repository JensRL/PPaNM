using System;
using static System.Console;
using static System.Math;
class main{
	public static double lngamma(double x){
		if(x<0)return Log(PI/Sin(PI*x)) - Log(lngamma(1-x));
		if(x<9)return (lngamma(x+1))-Log(x);
		double loggamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return loggamma;
	}

	public static void Main(){
		for(double x=0; x<=75; x+=1.0/1000){//BE CAREFUL with double x, as it then doesnt know how to use <, and will run differently in different architectures
			WriteLine($"{x} {lngamma(x)}");
		}

	}
}