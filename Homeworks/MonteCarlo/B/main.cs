using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Test the Monte Carlo Integrator
		WriteLine("Testing my Monte-Carlo integration with implemented Halton MC routine");
		WriteLine("----------Integrating x*y dx dy from 0 to 1 in both dimensions--------------");
		Func<vector,double> f1 = x => x[0]*x[1];
		vector a1 = new double[2] {0,0}; //Start point for integration
		vector b1 = new double[2] {1,1}; //End point for integration
		var result1 = mc.mcint(f1, a1, b1, 10000);
		var result1Hal = mc.haltonint(f1, a1, b1, 10000);
		WriteLine($"The result using plain mc is {result1.Item1} with uncertainty {result1.Item2}");
		WriteLine($"The result using Halton mc is {result1Hal.Item1} with uncertainty {result1Hal.Item2}");
		WriteLine("Expected result: 0.25");

		WriteLine("-----------Integrating (x + sin(y) + 1) dx dy, x = 0,2 and y = -pi, pi------");
		Func<vector,double> f2 = x => x[0]+Sin(x[1])+1;
		vector a2 = new double[2] {0,-PI};
		vector b2 = new double[2] {2, PI};
		var result2 = mc.mcint(f2, a2, b2, 10000);
		var result2Hal = mc.haltonint(f2, a2, b2, 10000);
		WriteLine($"The result using plain mc is {result2.Item1} with uncertainty {result2.Item2}");
		WriteLine($"The result using Halton mc is {result2Hal.Item1} with uncertainty {result2Hal.Item2}");
		WriteLine("Expected result: 8*pi = 25.13");

		WriteLine("-----------Integrating 1/([1-cos(x)*cos(y)*cos(z)]*pi^3) dx dy dz, from 0 to pi in x,y,z ------");
		Func<vector,double> f3 = x => 1/((1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*PI*PI*PI);
		vector a3 = new double[3] {0,0,0};
		vector b3 = new double[3] {PI,PI,PI};
		var result3 = mc.mcint(f3, a3, b3, 100000);
		var result3Hal = mc.haltonint(f3, a3, b3, 1000000);
		WriteLine($"The result using plain mc is {result3.Item1} with uncertainty {result3.Item2}");
		WriteLine($"The result using Halton mc is {result3Hal.Item1} with uncertainty {result3Hal.Item2}");
		WriteLine("Expected result: 1.3932");
		WriteLine("NOTE: Halton MC required far more N points (factor 10 larger than plain) to converge to the correct result for the difficult singular integral");
		WriteLine("The Halton MC did however better approximate the correct result!");
		WriteLine("--------- Investigating the scaling of the error for plain and Halton MC -----------");
		int[] Ns = {5, 10, 15, 25, 40, 50, 80, 100, 500, 1000, 2000, 5000, 8000, 10000, 15000, 20000, 25000, 30000, 40000, 50000, 60000, 80000, 100000};
		using(var outfile = new System.IO.StreamWriter("McOut.txt")){
			for(int i=0; i<Ns.Length; i++){
				var errres = mc.mcint(f1, a1, b1, Ns[i]);
				var erresHal = mc.haltonint(f1, a1, b1, Ns[i]);
				outfile.WriteLine($"{Ns[i]} {Log(errres.Item2)} {Log(erresHal.Item2)}");
			}
		}
		WriteLine("The behavior of the error with N points for the mc routines has been investigated");
		WriteLine("The first easy integral was called for plain and halton with varying N points");
		WriteLine("The results for plain and Halton mc can be seen in the MCErrs_fig.pdf");
		WriteLine("The Halton MC converges at approximately the same rate as plain MC, but to MUCH lower uncertainties");
	}//Main
}//main
