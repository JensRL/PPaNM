using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static void Main(){
		//Create Tabulation Values
		double[] xs = new double[] {-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5};
		int n = xs.Length;
		double[] x2 = new double[n];
		double[] x3 = new double[n];
		double[] x4 = new double[n];
		double[] y2 = new double[n];
		double[] y3 = new double[n];
		double[] y4 = new double[n];

		int i;
		for (i=0; i<n; i++){ //Make y2 function table values
			x2[i]=xs[i];
			y2[i]=1;
			WriteLine($"{x2[i]} {y2[i]}");
		}
		Write("\n\n"); 
		
		for (i=0; i<n; i++){ //Make y3 function table values
			x3[i]=xs[i];
			y3[i]=x3[i];
			WriteLine($"{x3[i]} {y3[i]}");
		}
		Write("\n\n"); 
		
		for (i=0; i<n; i++){ //Make y4 function table values
			x4[i]=xs[i];
			y4[i]=Pow(x4[i],2);
			WriteLine($"{x4[i]} {y4[i]}");
		}

		//Calculate interpolations for all table values
		//Quadratic Interpolation of y2
		Write("\n\n");
		qspline s2 = new qspline(x2,y2);
		for (double z=x2[0]; z<=x2[x2.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s2.eval(z)}");
		}
		//Quadratic Interpolation Derivation
		Write("\n\n");
		for (double z=x2[0]; z<=x2[x2.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s2.qterpDeriv(z)}");
		}
		//Quadratic Interpolation Integration
		Write("\n\n");
		for (double z=x2[0]; z<=x2[x2.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s2.qterpInteg(z)}");
		}

		//Quadratic Interpolation of y3
		Write("\n\n");
		qspline s3 = new qspline(x3,y3);
		for (double z=x3[0]; z<=x3[x3.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s3.eval(z)}");
		}
		//Quadratic Interpolation Derivation
		Write("\n\n");
		for (double z=x3[0]; z<=x3[x3.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s3.qterpDeriv(z)}");
		}
		//Quadratic Interpolation Integration
		Write("\n\n");
		for (double z=x3[0]; z<=x3[x3.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s3.qterpInteg(z)}");
		}

		//Quadratic Interpolation of y4
		Write("\n\n");
		qspline s4 = new qspline(x4,y4);
		for (double z=x4[0]; z<=x4[x4.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s4.eval(z)}");
		}
		//Quadratic Interpolation Derivation
		Write("\n\n");
		for (double z=x4[0]; z<=x4[x4.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s4.qterpDeriv(z)}");
		}
		//Quadratic Interpolation Integration
		Write("\n\n");
		for (double z=x4[0]; z<=x4[x4.Length-1]; z+=1.0/32){
			WriteLine($"{z} {s4.qterpInteg(z)}");
		}
		Error.WriteLine("-----------------------------------------------------------------------------");
		Error.WriteLine("Quadratic spline, integrator and derivative was implemented");
		Error.WriteLine("The algorithm was applied to three different datasets");
		Error.WriteLine("Results can be seen in the plot Fig.interp.pdf");
		Error.WriteLine("Alternate plotting with interpolated sin data set can be seen in the plot fig.interp.png");
		Error.WriteLine("-----------------------------------------------------------------------------");
	}//Main
}//main
