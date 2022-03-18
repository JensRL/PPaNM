using System; 
using static System.Console; 
using static System.Math; 

	
public static class linspline{
	public static int binsearch(double[] x, double z){ //Implement binary search as method
		int i=0, n=x.Length, j=n-1;
		while(j-i>1){
			int m = (i+j)/2;
			if (z>x[m]) i=m;
			else j=m;
		}
		return i;
	}

	public static double linterp(double[] x, double[] y, double z){ //Linear Interp evaulation
		int i = binsearch(x,z);
		double dy=y[i+1]-y[i], dx = x[i+1]-x[i];
		return y[i]+dy/dx*(z-x[i]);
	}

	public static double linterpInteg(double[] x, double[] y, double z){ //Linear Interpolation
		double cumsum = 0; 
		int ix = binsearch(x,z);
		for(int i=0; i<ix; i++){
			double dy=y[i+1]-y[i], dx = x[i+1]-x[i];
			cumsum += y[i]*dx + dy/dx * Pow(dx,2)/2;
		}
		double dy_ix=y[ix+1]-y[ix], dx_ix = x[ix+1]-x[ix];
		return cumsum+y[ix]*dx_ix + dy_ix/dx_ix * Pow(dx_ix,2)/2;
	}
}

