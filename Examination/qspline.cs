using System; 
using static System.Console; 
using static System.Math; 

public class qspline{
	//Declare variables
	double[] x, y, b, c, p, h;

	public static int binsearch(double[] x, double z){ //Implement binary search as method
		int i=0, n=x.Length, j=n-1;
		while(j-i>1){
			int m = (i+j)/2;
			if (z>x[m]) i=m;
			else j=m;
		}
		return i;
	}

	public qspline(double[] x, double[] y){ //Initialize constructor
		int n = x.Length;
		this.x = x; 
		this.y = y;
		b = new double[n-1];
		c = new double[n-1];
		//Construct qspline coefficients - S function
		int i;  
		p = new double[n-1];
		h = new double[n-1];
		for(i=0; i<n; i++){
			this.x[i]=x[i];
			this.y[i]=y[i];
		}
		for(i=0; i<n-1; i++){
			h[i]=x[i+1]-x[i];
			p[i]=(y[i+1]-y[i])/h[i];
		}
		c[0]=0; //Initial condition of c[0]=0
		//Recursion up
		for(i=0; i<n-2; i++){
			c[i+1]=(p[i+1]-p[i]-c[i]*h[i])/h[i+1];
		}
		c[n-2]=c[n-2]/2;
		//Recursion down
		for(i=n-3; i>=0; i--){
			c[i]=(p[i+1]-p[i]-c[i+1]*h[i+1])/h[i];
		}
		for(i=0; i<n-1; i++){
			b[i]=p[i]-c[i]*h[i];
		}
		//No need to return as inside constructor
	}
	
	public double eval(double z){ //Quadratic Interp Evaulation
		int i = binsearch(x,z);
		double h = z-x[i];
		return y[i]+h*(b[i]+h*c[i]); //Perform interpolation of polynomial
	}
	
	public double qterpDeriv(double z){ //Quadratic Interpolation Derivation
		int ix = binsearch(x,z);
		double dx = z-x[ix];
		return b[ix]+2*c[ix]*dx;
	}
	
	public double qterpInteg(double z){ //Quadratic Interpolation Integration
		double cumsum = 0; 
		int ix = binsearch(x,z);
		for(int i=0; i<ix; i++){
			double dy=y[i+1]-y[i], dx = x[i+1]-x[i];
			double p = dy/dx; 
			double bi = p-c[i]*dx;
			cumsum += y[i]*dx + bi*(Pow(x[i+1],2)-Pow(x[i],2))/2 + c[i] * (Pow(x[i+1],3)-Pow(x[i],3))/3;
		}
		//Last term
		double dx_ix = z-x[ix]; //dy_ix = y[ix+1]-y[ix]
		return cumsum + y[ix]*dx_ix + b[ix]*(Pow(z,2)-Pow(x[ix],2))/2 + c[ix]*(Pow(z,3)-Pow(x[ix],3))/3;
	}
}
