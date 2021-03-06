using System; 
using static System.Console; 
using static System.Math; 
using System.Collections.Generic; //Native genlists from C#

public static class main{
	//Declare generic lists to import data into
	static List<double> Es, CS, Unc;

	//Define Breit-Wigner function
	public static double BW(double E, double m, double gamma){ //assume scaling factor A=1, we can apply later with whatever we need
		return 1/((E-m)*(E-m) + gamma*gamma/4);
	}

	//Define chi2 function 
	public static double chi2(vector x){
		//Parameters for BW function
		double m = x[0];
		double gamma = x[1];
		double A = x[2];
		double sum = 0;
		for(int i=0; i < Es.Count; i++){
			double Energy = Es[i];
			double Section = CS[i];
			double Sigma = Unc[i];
			sum += ((A*BW(Energy, m, gamma) - Section)*(A*BW(Energy, m, gamma) - Section))/(Sigma*Sigma);
		}
		return sum;
	}	

	//Find Higgs
	public static void Main(){
		WriteLine("----------------------------- Finding the Higgs Boson --------------------------");
		WriteLine("Solving the problem by fitting Breit-Wigner function to data and minimizing on its chi^2");
		//Load in the datafile - take code from Input/Output and Genlist assignments
		List<double> data = new List<double>();
		string datafile = "inputdata.txt";
		var input = new System.IO.StreamReader(datafile);
		for( string line = input.ReadLine(); line != null; line = input.ReadLine() ){
			var words = line.Split(" ");
			foreach(var word in words){
				double value_i = double.Parse(word);
				data.Add(value_i);
            }
        }
        input.Close(); //Close the input stream and continue

        //Define Energy, Cross section and uncertainty arrays from loaded data
        Es = new List<double>();
        CS = new List<double>();
        Unc = new List<double>();
        for(int j=0; j<data.Count; j++){
        	if(j%3 == 0){Es.Add(data[j]);}
        	if(j%3 == 1){CS.Add(data[j]);}
        	if(j%3 == 2){Unc.Add(data[j]);}
        }
        //WriteLine($"{Es[0]} {CS[0]} {Unc[0]}"); - The data arrays seem to be correctly loaded

        //Time for minimization
        vector x0 = new double[3] {125.3, 3.5, 6.1}; //Guess on mass [GeV], width and amplitude A 
        WriteLine($"The initial guesses on mass = {x0[0]}, width = {x0[1]}, amplitude = {x0[2]}");
        var(res,steps) = minimize.QNMini(chi2, x0, acc: 1e-5);
        double m = Abs(res[0]);
        double gamma  = Abs(res[1]);
        double A = Abs(res[2]);
        WriteLine("The results of the minimization routine were:");
        WriteLine($"Mass = {m}, Width = {gamma}, Amplitude = {A}, Nsteps = {steps}");

        if(m<127 && m>123 && A<10 && A>2){WriteLine("HIGGS MIGHT HAVE BEEN FOUND!");}
		else{WriteLine("The fit to find Higgs was unsuccesful :(");}
		//The fitting routine seems to be incredibly sensitive to the input guesses, and fails to replicate Higgs :(
        //Output fit for plotting
		WriteLine("The resulting fit to the data can be seen in figure higgsfit_fig.pdf");
		WriteLine("------------------------------------------------------------------------------");
		using(var outfile = new System.IO.StreamWriter("higgsfit.txt")){
			for(double energy = 100; energy < 160; energy += 1.0/64){
				outfile.WriteLine($"{energy} {A*BW(energy, m, gamma)}");
			}
		}

	}//Main
}//main
