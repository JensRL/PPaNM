using System; 
using static System.Console; 
using static System.Math; 

public class roots{
	public static vector newton(Func<vector,vector> f, vector x0, double eps=1e-2){
		//In case of root guess being x0=0, the routine never runs. Implementing a fix to get it running
		for(int i=0; i<x0.size; i++){
			if(x0[i] == 0){x0[i] = 1e-5;}
		}

		//Initial setup of variables 
		vector x = x0.copy();
		int n = x0.size;
		matrix J = new matrix(n, n);
		vector y = new vector(n); //Output vectors
		vector fy = new vector(n);
		double deltax = 0; //Set some delta x that doesnt stop the loop for now
		
		bool run = true;
		while(run){
			//Calculate the Jacobian matrix
			vector fx = f(x); //Make sure to have the f(x) value before you change anything in the for loop
			for(int i=0; i<n; i++){
				deltax = Abs(x[i])*Pow(2,-26);
				x[i] += deltax;
				vector df = f(x)-fx; //f(x) with added deltax - f(x)
				for(int k=0; k<n; k++){
					J[k,i] = df[k]/deltax;
				}
				x[i] -= deltax;
			}

			//Perform QR decomposition
			matrix Q = J.copy();
			matrix R = new matrix(n,n);
			lineareq.QRGS(Q,R);
			vector Nstep = lineareq.QRGSSolver(Q,R,-fx); //The Newton step

			//Check acceptance of step
			double s = 2.0;
			bool check = true; 
			while(check){
				s /= 2;
				y = x + Nstep*s;
				fy = f(y);
				if (fy.norm() < (1-s/2)*fx.norm() || s < 1.0/64){check = false;}
			}

			x = y; //Set x equal to x + Nstep
			fx = fy; //Set function value to value of x with step
			if (fx.norm()<eps || Nstep.norm() < deltax){run = false;}
		}
		
		return x;
	}
}
