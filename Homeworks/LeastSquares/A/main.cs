using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Perform the lsfit, output data and fit
		//Create data arrays with uncertainties from Dmitri
		double[] x = new double[] {1, 2, 3, 4, 6, 9, 10, 13, 15}; //Time in days
		double[] y = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1}; //Activity 
		double[] dy = new double[] {5,5,5,5,5,5,1,1,1,1}; //Uncertainties
		var fs = new Func<double,double>[] { z => 1.0, z => z};//, z => z*z };

		//Output datafile	
		using(var Out_Data = new System.IO.StreamWriter("Out_Data.txt")){
			for(int i=0; i<x.Length; i++){
				Out_Data.WriteLine($"{x[i]} {y[i]} {dy[i]}");
			}
		}
		//Form the function data and uncertaintity of it
		for(int i=0; i<y.Length; i++){
			dy[i]=dy[i]/y[i]; //Unc
			y[i] = Math.Log(y[i]); //Func value
		}

		//Perform the lsfit
		double[] c = lsfit.leastsqfit(x, y, dy, fs);

		//Output the fit file
		using(var Out_Fit = new System.IO.StreamWriter("Out_Fit.txt")){
			for(double t=0; t<=16; t+=1.0/32){
				double output = 0;
				for(int j=0; j<fs.Length; j++){
					output += c[j]*fs[j](t);
				}
				//Error.WriteLine($"Output now is {output}");
				Out_Fit.WriteLine($"{t} {Math.Exp(output)}");
			}
		}

		WriteLine("------------------- Check Halflife of Ra-224 --------------------");
		WriteLine($"The fit parameters are {c[0]} and {c[1]}");
		WriteLine($"Yields a fitted lambda value of -c[1] = {-c[1]}");
		WriteLine($"Half-Life is given as ln(2)/lambda = {Math.Log(2)/(-c[1])} days");
		WriteLine($"This corresponds badly with the modern day value of around 3.6 days (Wiki)");
		WriteLine("A plot representing the fit is outputted as lsfit_fig.pdf");
		WriteLine("-----------------------------------------------------------------");

	}//Main
}//main
