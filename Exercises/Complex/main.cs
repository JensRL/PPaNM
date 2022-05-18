using System; 
using static System.Console; 
using static System.Math;
using static cmath;
using static complex; 

public static class main{
	static void Main(){
		complex MinusOne = new complex(-1,0);
		WriteLine("-----------------------------------");
		WriteLine($"Sqrt of -1: {cmath.sqrt(MinusOne)}");
		WriteLine($"Sqrt of i: {cmath.sqrt(cmath.I)}");
		WriteLine($"exp(i) = {cmath.exp(cmath.I)}");
		WriteLine($"exp(i*pi) = {cmath.exp(cmath.I*PI)}");
		WriteLine($"i^i: {cmath.I.pow(cmath.I)}");
		WriteLine($"log(i): {cmath.log(cmath.I)}");
		WriteLine($"sin(i*pi): {cmath.sin(cmath.I*PI)}");
	}



}


