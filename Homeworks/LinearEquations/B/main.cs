using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Test the QRGS Routine
		int n = 5; 
		//Create Matrices for test
		matrix A = new matrix (n,n);
		matrix R = new matrix (n,n); 
		matrix Q = new matrix (n,n); 

		//Create random numbers and insert in A and Q
		var rand = new Random(); 
		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				double GenNum = rand.NextDouble();
				A[i,j] = GenNum;
				Q[i,j] = GenNum;
			}
		}
		//Check that the inverse function works
		WriteLine("---------------- Check that inverse calculator works -------------------");
		WriteLine($"Randomly generated square matrix A {n}x{n}:");
		A.print();
		lineareq.QRGS(Q,R);
		matrix A_inv = lineareq.QRGSInverse(Q,R);
		WriteLine("Inverse of A is A^-1:");
		A_inv.print();
		WriteLine("Ensuring that A*A^-1 yields identity matrix:");
		matrix AAinv = A*A_inv;
		AAinv.print();
		WriteLine("It sure does to a very good approximation!");
		matrix I = new matrix(n,n);
		I.set_identity();
		WriteLine($"Is A*A^-1 approximately equal to I using method from vector class? - {AAinv.approx(I)}");

	}//Main
}//main
