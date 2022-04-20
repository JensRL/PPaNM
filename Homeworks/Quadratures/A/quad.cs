using System; 
using static System.Console; 
using static System.Math; 

public class quad{
	//Build the 4 step quadrature
	public static double integrator(
		Func<double,double> f, 
		double a, //Start
		double b, //Stop
		double delta = 0.001, //Absolute accuracy
		double epsilon = 0.001, //Relative accuracy
		double f2 = System.Double.NaN, 
		double f3 = System.Double.NaN)
		{
		double h = b-a; //Define initial stepsize
		if (System.Double.IsNaN(f2)){ //First time we call the function we define f2 and f3
			f2 = f(a+2*h/6);
			f3 = f(a+4*h/6);
		}
		double f1 = f(a+h/6), f4 = f(a+5*h/6); //Define outer points
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a); //Higher order rule applying weights w_i
		double q = (f1+f2+f3+f4)/4*(b-a); //Lower order rule
		double err = Abs(Q-q);
		if (err <= Max(delta,epsilon*Abs(Q))) return Q; 
		else return integrator(f,a,(a+b)/2, delta/Sqrt(2), epsilon, f1,f2) + integrator(f,(a+b)/2, b, delta/Sqrt(2), epsilon, f3,f4);
	}
}
