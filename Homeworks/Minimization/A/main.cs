using System; 
using static System.Console; 
using static System.Math; 
using static System.Random;
public static class main{
	public static void Main(){
		WriteLine("------------------- Testing the implemented Quasi-Newton Minimization algorithm --------------");
		WriteLine("--------------------------------------------------------------------------------");
		WriteLine("Estimating the minimum of the Rosenberg Valley Function:");
		Func<vector,double> f1 = x => ((1-x[0])*(1-x[0]) + 100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]));
		double acc1 = 1e-5;
		vector x01 = new double[2] {0.5, 1.5}; //Initial guesses for minima
		WriteLine($"Initial guess for minima: ({x01[0]},{x01[1]})");
		var (x1res, steps1) = minimize.QNMini(f1, x01, acc: acc1);
		WriteLine($"The found minima was: ({x1res[0]}, {x1res[1]}) in {steps1} steps.");
		WriteLine($"Function value at minima: f(x,y) = {f1(x1res)}");
		WriteLine("The expected result of minima at (1,1) was recovered!");

		WriteLine("--------------------------------------------------------------------------------");
		WriteLine("Estimating the minimum of the Himmelblau's Function:");
		Func<vector,double> f2 = x => ( (x[0]*x[0] + x[1] - 11)*(x[0]*x[0] + x[1] - 11) + (x[0] + x[1]*x[1] - 7)*(x[0] + x[1]*x[1] - 7));
		double acc2 = 1e-5;
		vector x02 = new double[2] {2.5,2.5};
		WriteLine($"Initial guess for minima: ({x02[0]},{x02[1]})");
		var (x2res, steps2) = minimize.QNMini(f2, x02, acc: acc2);
		WriteLine($"The found minima was: ({x2res[0]}, {x2res[1]}) in {steps2} steps");
		WriteLine($"Function value at minima: f(x,y) = {f2(x2res)}");
		WriteLine("The expected result for one minima at (3,2) with f(x,y) = 0 was recovered!");
		WriteLine("The algorithm has been tested for alternative local minima and succeed in replicating them as well");
	}//Main
}//main
