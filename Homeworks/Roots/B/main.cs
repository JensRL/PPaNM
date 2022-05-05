using System; 
using static System.Console; 
using static System.Math; 
using static System.Random;
public static class main{
	//Define class to solve shrödinger equation using ODE
	public static double ODESolve(double r, double e, double rmin, double acc = 1e-8, double eps = 1e-8){
		//In case of rmin being too low we must return something
		if (r<rmin){return r-r*r;}

		//Write Schrödinger equation decomposed into two first order differential eqs for ODE to take as input
		Func<double, vector, vector> Schro = (x,y) =>{
			return new vector(new double[] {y[1], -2*(e+1/x)*y[0]});
		};
		//Specify boundary condition at rmin and its derivative for ODE driver input
		vector ymin = new vector(new double[] {rmin-rmin*rmin, 1-2*rmin});
		vector sol = ODE.Driver(Schro, rmin, ymin, r, acc: acc, eps: eps);
		return sol[0];
	}

	//Define class for roots solver
	public static double RootsSolve(double rmin, double rmax, double acc = 1e-8, double eps = 1e-8){
		//Define function that calls the ODEsolve to create input for roots
		Func<vector,vector> input = (vector v) =>{
			double e = v[0]; //Set epsilon in schrödinger equation
			double sol_rmax = ODESolve(rmax, e, rmin, acc, eps);
			return new vector(sol_rmax);
		};
		vector start = new vector(-1.0);
		vector RootSol = roots.newton(input,start);
		double E = RootSol[0];
		return E;
	}

	//Test the implementation
	public static void Main(){
		WriteLine("-----------------------------------------------------------");
		WriteLine("Lowest root E0 for rmin = 1e-8 and rmax = 8 Bohr radii");
		double rmin = 1e-8, rmax = 8;
		double energy = RootsSolve(rmin, rmax);
		WriteLine($"The energy E0 is estimated to be: {energy} ");
		WriteLine("Expected result for ground state: -1/2 Hartree");
		WriteLine("Inspecting the resulting wavefunction and energy with the analytic results.");
		using(var outfile = new System.IO.StreamWriter("E0Solution.txt")){
			for(double r=0; r<rmax; r+=1.0/64){
				outfile.WriteLine($"{r} {ODESolve(r,energy,rmin)} {r*Exp(-r)}");
			}
		}
		WriteLine("The obtained correlation can be viewed in HydrogenE0Sol_fig.pdf");

		WriteLine("-----------------------------------------------------------");
		WriteLine("We now wish to investigate the convergence with respect to rmax and rmin:");
		using(var outfile = new System.IO.StreamWriter("rconv.txt")){
			//Put rmax convergence into index 0 of outfile
			for(double rmaxconv = 0.5; rmaxconv <= 20; rmaxconv += 0.1){
				double energy2 = RootsSolve(rmin, rmaxconv);
				outfile.WriteLine($"{rmaxconv} {energy2} {-0.5}");
			}
			outfile.WriteLine("\n");

			//Put rmin convergence into index 1 of outfile
			for(double rminconv = 0.6; rminconv >= 1e-8; rminconv -= 0.01){
				double energy3 = RootsSolve(rminconv, rmax);
				outfile.WriteLine($"{rminconv} {energy3} {-0.5}");
			}
		}
		WriteLine("The convergence of E0 with varying rmin and rmax can be seen figure 'rconvergence_fig.pdf'.");
		WriteLine("-----------------------------------------------------------");
		WriteLine("Investigating convergence with respect to ODE acc and eps.");
		WriteLine("Utilizing chosen rmin = 1e-8 and rmax = 8 Bohr radii.");
		using(var outfile = new System.IO.StreamWriter("acc_eps_conv.txt")){	
			//Put rmax convergence into index 0 of outfile
			for(double acc_conv = 0.02; acc_conv >= 1e-12; acc_conv -= 5e-5){
				double energy4 = RootsSolve(rmin, rmax, acc: acc_conv, eps: 0.0);
				outfile.WriteLine($"{acc_conv} {energy4} {-0.5}");
			}
			outfile.WriteLine("\n");

			//Put rmin convergence into index 1 of outfile
			for(double eps_conv = 0.02; eps_conv >= 1e-12; eps_conv -= 5e-5){
				double energy5 = RootsSolve(rmin, rmax, acc: 0.0005, eps: eps_conv);
				outfile.WriteLine($"{eps_conv} {energy5} {-0.5}");
			}
		}
		WriteLine("The convergence of E0 with varying acc and eps can be seen in 'acc_eps_conv_fig.pdf'.");
		WriteLine("Low acc and eps are required for any sort of convergence to E0. However, the behaviour at very low values of acc and eps is interesting.");
		WriteLine("It deviates from the expected result and some connection between acc and eps is found when varying ");
		WriteLine("There may be an ideal combination of acc and eps for proper convergence to E0");
		WriteLine("-----------------------------------------------------------");



	}//Main
}//main








