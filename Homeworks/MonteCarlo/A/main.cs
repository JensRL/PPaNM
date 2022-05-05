using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Test the Monte Carlo Integrator
		WriteLine("Testing my Monte-Carlo integration routine");
		WriteLine("----------Integrating x*y dx dy from 0 to 1 in both dimensions--------------");
		Func<vector,double> f1 = x => x[0]*x[1];
		vector a1 = new double[2] {0,0}; //Start point for integration
		vector b1 = new double[2] {1,1}; //End point for integration
		var result1 = mc.mcint(f1, a1, b1, 10000);
		WriteLine($"The result is {result1.Item1} with uncertainty {result1.Item2}");
		WriteLine("Expected result: 0.25");

		WriteLine("-----------Integrating (x + sin(y) + 1) dx dy, x = 0,2 and y = -pi, pi------");
		Func<vector,double> f2 = x => x[0]+Sin(x[1])+1;
		vector a2 = new double[2] {0,-PI};
		vector b2 = new double[2] {2, PI};
		var result2 = mc.mcint(f2, a2, b2, 10000);
		WriteLine($"The result is {result2.Item1} with uncertainty {result2.Item2}");
		WriteLine("Expected result: 8*pi = 25.13");

		WriteLine("-----------Integrating 1/([1-cos(x)*cos(y)*cos(z)]*pi^3) dx dy dz, from 0 to pi in x,y,z ------");
		Func<vector,double> f3 = x => 1/((1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*PI*PI*PI);
		vector a3 = new double[3] {0,0,0};
		vector b3 = new double[3] {PI,PI,PI};
		var result3 = mc.mcint(f3, a3, b3, 100000);
		WriteLine($"The result is {result3.Item1} with uncertainty {result3.Item2}");
		WriteLine("Expected result: 1.3932");


	}//Main
}//main
