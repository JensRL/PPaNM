using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static void Main(){
		//Create Tabulation Values
		int n=10, N=20;
		double[] x = new double[n];
		double[] y = new double[n];
		int i;
		for (i=0; i<n; i++){
			x[i]=2*PI*i/(n-1);
			y[i]=Sin(x[i]);
			WriteLine($"{x[i]} {y[i]}");
		}
		
		//Make newlines for new plotting input (intergration solved plots)
		Write("\n\n"); 

		//Linear Interpolation
		double z, step=(x[n-1]-x[0])/(N-1);
		for (z=x[0], i=0; i<N; z=x[0]+(++i)*step){
			WriteLine($"{z} {Sin(z)} {linspline.linterp(x,y,z)}");
		}

		//Linear Interpolation Integration
		Write("\n\n");
		for (z=x[0], i=0; i<N; z=x[0]+(++i)*step){
			WriteLine($"{z} {Cos(z)} {linspline.linterpInteg(x,y,z)}");
		}
		Error.WriteLine("-----------------------------------------------------------------------------");
		Error.WriteLine("Linear spline and integrator was implemented");
		Error.WriteLine("Results can be seen in the plot Fig.interp.png");
		Error.WriteLine("-----------------------------------------------------------------------------");
	}//Main
}//main
