using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static double erf(double z){
		Func<double,double> f = delegate(double x){return Exp(-x*x);};
		double result = quad.integrator(f:f,a:0,b:z,delta:1e-6,epsilon:0);
		return result*2/Sqrt(PI);
	}

	public static void Main(){
		WriteLine("------------------------------------------------");
		WriteLine("Checking implemented integrator on various functions");
		//Define some test functions and integrate
		Func<double,double> sqrtx = (x => Sqrt(x));
		double sqrtxInt = quad.integrator(sqrtx,0,1);
		WriteLine($"Integral of sqrt(x) = {sqrtxInt}, which resembles 2/3");
		Func<double,double> invsqrtx = (x => 1.0/Sqrt(x));
		double invsqrtxInt = quad.integrator(invsqrtx,0,1);
		WriteLine($"Integral of 1/sqrt(x) = {invsqrtxInt}, which is equal to 2");
		Func<double,double> xsquared = (x => 4.0*Sqrt(1-x*x));
		double invxsquared = quad.integrator(xsquared,0,1);
		WriteLine($"Integral of 4*sqrt(1-x^2) = {invxsquared}, which is equal to pi");
		Func<double,double> lnxdivx = (x => Log(x)/Sqrt(x));
		double invlnxdivx = quad.integrator(lnxdivx,0,1);
		WriteLine($"Integral of ln(x)/Sqrt(x) = {invlnxdivx}, which is equal to -4");
		WriteLine("------------------------------------------------");
		WriteLine("Implementing the errorfunction using my own quad routine:");
		//Call and calculate the errorfunction
		int ncalls=0;
		Func<double,double> f = delegate(double x){
			ncalls++; 
			return Log(x)/Sqrt(x);
		};
		double result = quad.integrator(f,a:0,b:1,delta:1e-6,epsilon:1e-6); //Calling my quad function with certain accuracies 
			for(double x=-3; x<=3; x+=1.0/8){
				Error.WriteLine($"{x} {erf(x)}");
			}
		WriteLine("The obtained result can be seen in the fig.erf.pdf figure");



	}//Main
}//main
