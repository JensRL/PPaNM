using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Test the QRGS Routine
		var rand = new Random();
		int N = 500; 		
		//Create random matrix, decompose and log the time
		for(int n=0; n<=N; n+=10){
			matrix A = new matrix (n,n);
			matrix R = new matrix (n,n); 
			for(int i=0; i<n; i++){
				for(int j=0; j<n; j++){
					A[i,j] = rand.NextDouble();
				}
			}
		var clock = new System.Diagnostics.Stopwatch();
		clock.Start();
		lineareq.QRGS(A,R);
		clock.Stop();
		var TimeMs = clock.ElapsedMilliseconds;
		WriteLine($"{n} {TimeMs}");
		}

		Error.WriteLine("-----------------------------------------------------------------------------");
		Error.WriteLine("Operations count for QR Factorization has been investigated");
		Error.WriteLine("The 'fit' operation in GNUPLOT has been combined with the Stopwatch Diagnostics tool");
		Error.WriteLine("Results can be seen in the plot SolverTime.pdf");
		Error.WriteLine("The fit to the time sure does reproduce a O(n^3) correlation");
		Error.WriteLine("-----------------------------------------------------------------------------");

		

	}//Main
}//main
