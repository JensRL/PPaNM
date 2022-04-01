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
		//Perform ODE
		var xlist = new genlist<double>();
		var ylist = new genlist<vector>();
		vector ys = ODE.Driver(F,start,ystart,stop,xlist,ylist);
		
		//Output ODE
		using(var outfile = new System.IO.StreamWriter("solution.txt")){
			for(int i=0; i<xlist.size; i++){
				outfile.WriteLine($"{xlist.data[i]} {ylist.data[i][0]} {ylist.data[i][1]}");
			}
		}
		
		WriteLine("-----------------------------------------------------------------------");
		WriteLine("The Runge-Kutta 45 stepper and driver is tested for a damped oscillator");
		WriteLine($"The final solutions are theta={ys[0]} and omega={ys[1]}");
		WriteLine("The results are seen in the plot DampedOsc_fig.pdf using the outputted genlists");
	}//Main
}//main
