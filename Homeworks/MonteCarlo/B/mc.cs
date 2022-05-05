using System; 
using static System.Console; 
using static System.Math; 

	
public class mc{
	public static (double, double) mcint(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1.0;
		for(int i=0; i<dim; i++){
			V *= b[i]-a[i];
		}

		double sum = 0, sum2 = 0;
		var x = new vector(dim);
		var rand = new Random();

		for(int i=0; i<N; i++){
			for(int k=0; k<dim; k++){
				x[k]=a[k]+rand.NextDouble()*(b[k]-a[k]);
			}
			double fx = f(x); 
			sum += fx;
			sum2 += fx*fx; 
		}
		
		double mean = sum/N; 
		double sigma = Sqrt(sum2/N-mean*mean);
		var result = (mean*V, sigma*V/Sqrt(N));
		return result;
	}

	//Implementing Quasi-Random Integrator using Van der Corput and Halton sequences
	//Implement corput algorithm
	public static double corput(int n, int Base){
		double q = 0;
		double bk = 1.0/Base;
		while(n>0){
			q += (n % Base)*bk;
			n /= Base;
			bk /= Base;
		}
		return q;
	}

	//Implement Halton Algorithm 
	public static double[] halton(int n, int d, int shift=0){
		int[] Base = {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
		if(d>Base.Length){
			throw new System.Exception("Dimension too large for Halton");
		}
		double[] x = new double[d];
		for(int i=0; i<d; i++){ //Call corput algorithm
			x[i] = corput(n, Base[i+shift]);
		}
		return x;
	}

	//Implement Halton Monte-Carlo Integrator
	public static (double,double) haltonint(Func<vector,double> f, vector a, vector b, int N){
		int dim = a.size;
		double V = 1.0;
		for(int i=0; i<dim; i++){
			V *= b[i]-a[i];
		}

		double sum = 0, sum2 = 0;
		//We now run the same plain mcint but for two sequences to yield error estimate
		//We run both sequences based on the Corput-Halton algorithm above
		double[] x = new double[dim];
		double[] x2 = new double[dim];

		//In order to avoid diverging points an offset parameter is implemented
		int off = 0;

		for(int i=0; i<N; i++){
			double[] seq1 = halton(i+off,dim);
			double[] seq2 = halton(i+off,dim,4);

			for(int k=0; k<dim; k++){
				x[k]=a[k]+seq1[k]*(b[k]-a[k]);
				x2[k]=a[k]+seq2[k]*(b[k]-a[k]);
			}

			double fx = f(x); 
			double fx2 = f(x2);

			//Check for diverging results. Reject step if diverging and increase offset, otherwise sum and continue
			if (double.IsNaN(fx) || double.IsInfinity(fx) || double.IsNaN(fx2) || double.IsInfinity(fx2)){
				--i;
				++off;
			}
			else{
				sum += fx;
				sum2 += fx2; 
			}
		}
		//Calculate outputs
		double mean = sum/N; 
		double mean2 = sum2/N;
		var result = (mean*V, Abs(mean*V-mean2*V));
		return result;
	}
}











