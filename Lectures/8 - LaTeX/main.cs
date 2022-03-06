using static System.Console;
using System;

class main{
	public static void Main(){
		double dx = 1.0/32, shift = dx/2;
		for(double x=-5; x<=5; x+=1.0/1000){
			WriteLine($"{x} {sfuncs.gamma(x)}");
		}
	}


}