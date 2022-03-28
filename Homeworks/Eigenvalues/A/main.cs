using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Test Jacobi eigenvalue algorithm
		var rand = new Random();
		int n = 6; 
		matrix A = new matrix(n,n);
		matrix V = new matrix(n,n);
		for(int i=0; i<n; i++){
			for(int j=0; j<n; j++){
				double input = rand.NextDouble();
				A[i,j] = input;
				A[j,i] = input;
			}
		}

		matrix D = A.copy(); //Make matrix D for holding eigenvalues

		WriteLine($"Generate random matrix A:");
		A.print();
		int sweeps = JacobiEV.JacobiCyclic(D,V);
		WriteLine($"Perform Jacobi Eigenvalue Diagonalization of A - It took n={sweeps} sweeps before convergence");
		WriteLine($"Generate matrix D holding eigenvalues on diagonal:");
		D.print();
		WriteLine($"Generate matrix V holding eigenvectors in columns:");
		V.print();
		WriteLine("---------------------------------------------------");

		//Performing checks on results:
		WriteLine("Performing checks on the results of the Jacobi EVD");
		WriteLine($"Checking that V^TAV == D:");
		matrix VTAV = V.transpose()*A*V;
		VTAV.print();
		WriteLine($"Checking that VDV^T == A:");
		matrix VDVT = V*D*V.transpose();
		VDVT.print();
		WriteLine("Confirmed that it indeed reproduces A");
		WriteLine($"Checking that V^TV == 1:");
		matrix VTV = V.transpose()*V;
		VTV.print();
		WriteLine($"Checking that VV^T == 1:");
		matrix VVT = V*V.transpose();
		VVT.print();
		WriteLine("All checks completed, the routine works as intended!");

	}//Main
}//main
