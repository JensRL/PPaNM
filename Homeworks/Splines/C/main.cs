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
		
		Error.WriteLine("-----------------------------------------------------------------------------");
		Error.WriteLine("Cubic spline, integrator and derivative was implemented");
		Error.WriteLine("The algorithms were applied to a dataset of sin(x) values");
		Error.WriteLine("The GNUPLOT cubic spline routine reproduces an identical fit to my algorithm");
		Error.WriteLine("Results can be seen in the plot Fig.interp.pdf");
		Error.WriteLine("-----------------------------------------------------------------------------");
	}//Main
}//main
