using System; 
using static System.Console; 
using static System.Math; 
using static System.Random;
public static class main{
	public static void Main(){
		WriteLine("----------------------Testing the implemented Roots Solver --------------");
		WriteLine("--------------------- Roots of f = x^3-3x^2+4 --------------------");
		Func<vector,vector> f1 = x => new vector(3*x[0]*x[0]-6*x[0]);
		vector x1 = new double[1] {3};
		vector res1 = roots.newton(f1, x1);
		WriteLine("The result is found using the implemented Newton Step Root-Finder algorithm");
		WriteLine("We call the algorithm with the derivative of the function: f' = 3x^2-6x");
		WriteLine($"The determined root is: x={res1[0]}");
		WriteLine("Expected result: 2");
		
		WriteLine("--------------------- Roots of Rosenbrocks Valley Function --------------------");
		Func<vector,vector> f2 = x => new vector(2*(200*x[0]*x[0]*x[0] - 200*x[0]*x[1] + x[0] - 1), 200*(x[1] - x[0]*x[0]));
		vector x2 = new double[2] {0.9,1.1};
		vector res2 = roots.newton(f2, x2);
		WriteLine("We call the algorithm with the derivative of the function: f' = 2*(200x^3-200xy+x-1), 200*(y-x^2)");
		WriteLine($"The determined root is: x = {res2[0]} and y = {res2[1]}");
		WriteLine("Expected result: 1,1");
		
	}//Main
}//main
