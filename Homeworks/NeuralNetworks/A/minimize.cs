using System; 
using static System.Console; 
using static System.Math; 

public class minimize{
	//We need to build 2 functions, 1 for the gradient of the objective function and 1 for quasi-newton minimization
	public static vector grad(Func<vector,double> f, vector x){
		//Initialize setup
		int n = x.size;
		vector g = new vector(n);
		double fx = f(x);
		double eps = Pow(2,-26); //Set eps to machine epsilon

		//Carry out a Newton step as in Roots
		for(int i = 0; i < n; i++){
			double dx = Abs(x[i])*eps;
			if( Abs(x[i]) < Sqrt(eps)){ //in case x_i is very small (zero)
				dx = eps;
			}
			x[i] += dx;
			g[i] = (f(x)-fx)/dx;
			x[i] -= dx;
		}
		return g;
	}

	public static (vector, int) QNMini(Func<vector,double> f, vector x0, double acc=1e-3){
		int steps = 0; //Record amount of steps the algorithm requires
		double eps = Pow(2,-26); 

		//Initial setup
		vector x = x0.copy();
		int n = x.size;
		double fx = f(x); 
		vector gx = grad(f,x);

		//Hessian Matrix
		matrix B = new matrix(n,n);
		B.set_unity(); 

		while(acc < gx.norm() && steps < 10000){ //norm of gradient should be less than acc for every step, and max steps is set to 10000
			steps++; 
			//We wish to use Quasi Newton method, thus we want to infer rank-1 updates directly to the inverse Hessian matrix
			vector dx = -B*gx; //Eq. 6 of notes

			//Check for step accenptance
			if(dx.norm() < eps*x.norm()){ // |s^T y| > eps
				Error.WriteLine($"Unsuccesful step: |s^T y| < eps at nstep = {steps}");
				break;
			}
			if(dx.norm() < acc){ //Norm of gradient less than accuracy
				Error.WriteLine($"Unsuccesful step: |grad| < acc at nstep = {steps}");
				break;
			}

			//Backtracking line-search according to eq. 9
			vector z; 
			double fz, lambda = 1;
			while(true){
				z = x + dx*lambda;
				fz = f(z);
				if(fz < fx){
					break; //Acceptance of step
				}
				if(lambda < eps){
					B.set_unity();
					break; //Minimal lambda reached - unconditional acceptance of step and B returned to unity
				}
				lambda /= 2;
			}

			//Rank-1 update 
			vector s = z-x;
			vector gz = grad(f,z);
			//Definitions from below eq. 12
			vector y = gz - gx; 
			vector u = s - B*y; 

			//Solve eq. 18
			double u_T_y = u.dot(y); //Has u been transposed properly???

			if(Abs(u_T_y) > eps){ //Reference value from Dmitris notes: 1e-6, but I used eps
				B.update(u,u,1/u_T_y); //Eq. 18
			}
			else{
				B.set_unity();
			}
			//Redefine starting parameters to fit the step taken
			x = z; 
			gx = gz; 
			fx = fz; 
		}
		return (x, steps);
	}	
}






