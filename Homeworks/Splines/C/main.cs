using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static void Main(){
		//Create Tabulation Values
		int n=10;
		double[] x = new double[n];
		double[] y = new double[n];

		int i;
		for (i=0; i<n; i++){ //Make sin function table values
			x[i]=2*PI*i/(n-1);
			y[i]=Sin(x[i]);
			WriteLine($"{x[i]} {y[i]}");
		}

		//Calculate interpolations for all table values
		//Quadratic Interpolation of y
		Write("\n\n");
		cspline s = new cspline(x,y);
		for (double z=x[0]; z<=x[x.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s.eval(z)}");
		}
		//Quadratic Interpolation Derivation
		Write("\n\n");
		for (double z=x[0]; z<=x[x.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s.deriv(z)}");
		}
		//Quadratic Interpolation Integration
		Write("\n\n");
		for (double z=x[0]; z<=x[x.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s.integ(z)}");
		}
		
	}//Main
}//main
