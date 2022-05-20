using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static void Main(){
		double b=0.25, c=5; //Define constants for use
		Func<double,vector,vector> F = delegate(double t,vector y){
			double theta=y[0], omega=y[1];
			return new vector(omega,-b*omega-c*Sin(theta)); //Defining example function from scipy
		};

		//Call driver of RK45 to solve system
		double start=0, stop = 10; //Define start/stop criteria
		vector ystart = new vector(PI-0.1,0.1);
		//Output fit 
		vector ys = ODE.Driver(F,start,ystart,stop);
		
		/* This output method did not reproduce the correct step sizes of the algorithm - Output is formed from the algorithm itself now!
		using(var outfile = new System.IO.StreamWriter("DampedOsc.txt")){
			for(double i = start; i<= stop; i+=1.0/32){
				vector ys = ODE.Driver(F,i,ystart,i+1.0/32);
				outfile.WriteLine($"{i} {ys[0]} {ys[1]}");
				ystart[0] = ys[0]; ystart[1] = ys[1];
			};
		};
		*/
		WriteLine("-----------------------------------------------------------------------");
		WriteLine("The Runge-Kutta 45 stepper and driver is tested for a damped oscillator");
		WriteLine($"The final solutions are theta={ys[0]} and omega={ys[1]}");
		WriteLine("The results are seen in the plot DampedOsc_fig.pdf");
	}//Main
}//main
