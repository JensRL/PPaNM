using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Test the QRGS Routine
		int n = 8, m = 5; 
		//Create Matrices for test
		matrix A = new matrix (n,m);
		matrix R = new matrix (m,m); 
		matrix Q = new matrix (n,m); 

		//Create random numbers and insert in A and Q
		var rand = new Random(); 
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				double GenNum = rand.NextDouble();
				A[i,j] = GenNum;
				Q[i,j] = GenNum;
			}
		}
		//Check that QR Decomposition works
		WriteLine("--------------------- Testing the QRGS Decomposition ----------------");
		WriteLine("Random generated matrix A:");
		A.print();
		//QRGS decompose 
		lineareq.QRGS(Q,R);
		WriteLine("QRGS Decomposed Q Matrix:");
		Q.print();
		WriteLine("QRGS Decomposed R Matrix, which is hopefully right triangular:");
		R.print();
		WriteLine("Checking that Q^T*Q = 1:");
		matrix QTQ = Q.transpose()*Q;
		QTQ.print();
		WriteLine("Only tiny values on off-diagonal - it's good enough!");
		WriteLine("Check that Q*R=A:");
		matrix QR = Q*R;
		QR.print();
		WriteLine("Yep that looks like A!");

		//Now to check the solver 
		int n2 = 6;
		int m2 = n2; 
		WriteLine("--------------------- Testing the implemented solver----------------");
		matrix A2 = new matrix(n2,m2);
		matrix R2 = new matrix(n2,m2);
		vector b = new vector(n2);
		for(int i=0; i<n2; i++){
			b[i] = rand.NextDouble();
			for(int j=0; j<m2; j++){
				A2[i,j] = rand.NextDouble();
			}
		}
		WriteLine("Random generated matrix A2:");
		A2.print();
		WriteLine("Random generated vector b:");
		b.print();
		//Create copy of A2 for later use
		matrix A2_copy = A2.copy();
		lineareq.QRGS(A2, R2); 
		WriteLine("QRGS Decomp of A and R:");
		A2.print();
		R2.print();
		WriteLine("Solving the system for solution (y):");
		vector y = lineareq.QRGSSolver(A2, R2, b);
		y.print();
		WriteLine("Checking that the solution satisfies A*y=b:");
		vector Ay = A2_copy*y;
		WriteLine("A*y is equal to:");
		Ay.print();
		WriteLine("Which is equal to b: ");
		b.print();
		WriteLine("The system has been solved!");
		WriteLine($"Is A*y approximately equal to b using method from vector class? - {Ay.approx(b)}");


	}//Main
}//main
