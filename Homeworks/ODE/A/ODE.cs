using System; 
using static System.Console; 
using static System.Math; 

public class ODE{
	//Build the Stepper algorithm
	public static (vector, vector) RKstep45(Func<double,vector,vector> f, double x, vector y, double h){
		//Define k vectors for the RK45 from the Butcher's Tableau
		vector k1 = h*f(x, y);
		vector k2 = h*f(x + 1.0/4*h, y + 1.0/4*k1);
		vector k3 = h*f(x + 3.0/8*h, y + 3.0/32*k1 + 9.0/32*k2);
		vector k4 = h*f(x + 12.0/13*h, y + 1932.0/2197*k1 - 7200.0/2197*k2 + 7296.0/2197*k3);
		vector k5 = h*f(x + h, y + 439.0/216*k1 - 8.0*k2 + 3680.0/513*k3 - 845.0/4104*k4);
		vector k6 = h*f(x + 1.0/2*h, y - 8.0/27*k1 + 2*k2 - 3544.0/2565*k3 + 1859.0/4104*k4 - 11.0/40*k5);
		//Define returns
		vector yh = y + 16.0/135*k1 + 0*k2 + 6656.0/12825*k3 + 28561.0/56430*k4 - 9.0/50*k5 +2.0/55*k6;
		vector yhstar = y + 25.0/216*k1 + 0*k2 + 1408.0/2565*k3 + 2197.0/4104*k4 - 1.0/5*k5 + 0*k6;
		vector err = yh-yhstar;
		return (yh, err);
	}
		
	//Build the Driver algorithm
	public static vector Driver(
		Func<double, vector, vector> f,
		double a, //Start point
		vector ya, //Initial condition
		double b, //End point
		double h = 0.01, //Initial step size
		double acc = 1e-8, //Accuracy goal
		double eps = 1e-8  //Relative accuracy goal
	){
		if(a>b) throw new Exception("Driver: a>b");
		double x=a; 
		vector y=ya;
		double Power = 0.25;
		double Safety = 0.95;
		//int maxiter = 10000;
		//int i = 0;
		do{
			//i++;
	        if(x>=b) return y; //ODE is solved
	        if(x+h>b) h=b-x;   //Last step to b
	        var (yh,erv) = RKstep45(f,x,y,h); //Call stepper
	        double tol = Max(acc,yh.norm()*eps) * Sqrt(h/(b-a)); //Tolerance definition
	        double err = erv.norm();
	        if(err<=tol){ 
	        	x+=h; 
	        	y=yh; 
	        	//Send step path to stderr for plotting
	        	Error.Write($"{x}");
	        	for(int i=0; i<y.size; i++){
	        		Error.Write($" {y[i]}");
	        	};
	        	Error.WriteLine();
	        } // Accept step
			h *= Min( Pow(tol/err,Power)*Safety , 2); // Readjust stepsize according to power and safety
        }while(true);//while(i<maxiter);
        //WriteLine($"The reached value is x={x}");
        //return null;
	}
	
}
