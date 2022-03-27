using System; 
using static System.Console; 
using static System.Math; 

	
public class lsfit{
	public static double[] leastsqfit(double[] x, double[] y, double[] dy, Func<double,double>[] fs){ 
		int n = x.Length, m=fs.Length;
		//Make A matrix and b vector
		matrix A = new matrix(n,m); 
		vector b = new vector(n);
		//Make Q and R matrices for QRGS
		matrix Q = A.copy();
		matrix R = new matrix(Q.size2, Q.size2);

		for(int i=0; i<n; i++){
			b[i]=y[i]/dy[i];
			for(int k=0; k<m; k++){
				Q[i,k]=fs[k](x[i])/dy[i];
			}
		}
		lineareq.QRGS(Q,R); //QRGS decompose 
		vector c = lineareq.QRGSSolver(Q, R, b); //Solve the system Rc = Q^T*b

		//Return the output
		double[] result = new double[c.size];
		for(int i=0; i<result.Length; i++){
			result[i]=c[i];
		}
		return result;
	}
}

