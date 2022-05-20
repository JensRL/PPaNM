using System; 
using static System.Console; 
using static System.Math; 
using static System.Random; 

public static class main{
	public static void Main(){//Solving the hydrogen wavefunction using Jacobi EVD
		//-----------------------Investigate convergence with rmax----------------------
		WriteLine("-----------------------------------------------------------------");
		WriteLine("Using the Jacobi EVD we now solve the Hydrogen atom");
		WriteLine("-----------------------------------------------------------------");
		WriteLine("Investigating the convergence with respect to rmax");
		WriteLine("The results for the three lowest eigenvalues (energies) after Jacobi EVD are compared to analytical values of the eigenenergies");
		WriteLine("Done with 2<=r_max<=20, dr = 0.1 Bohr Radius");
		using(var outfile = new System.IO.StreamWriter("Rmax_Out.txt")){
			for(int r_max=2; r_max <= 20; r_max++){
				double rmax=r_max; 
				double dr=0.1; //Set spacing to be 0.1 Bohr Radius
				int npoints = (int)((rmax/dr)-1); //Define npoints from the chosen spacing
				vector r = new vector(npoints);
				for(int i=0; i<npoints; i++) r[i]=dr*(i+1);
				matrix H = new matrix(npoints,npoints);
				for(int i=0; i<npoints-1; i++){
		  			matrix.set(H,i,i,-2);
					matrix.set(H,i,i+1,1);
					matrix.set(H,i+1,i,1);
		  		}
				matrix.set(H,npoints-1,npoints-1,-2);
				H*=-0.5/dr/dr;
				for(int i=0;i<npoints;i++) H[i,i]+=-1/r[i];

				//EVD time
				matrix D = H.copy(); 
				matrix V = new matrix(npoints,npoints);
				V.set_unity();
				JacobiEV.JacobiCyclic(D,V);

				//Output the results
				outfile.WriteLine($"{rmax} {D[0,0]} {D[1,1]} {D[2,2]}"); //Outputting the three lowest eigenvalues
			}
		}
		WriteLine("The resulting plot can be seen as RmaxConv_fig.pdf");
		WriteLine("The three lowest eigenvalues converge within roughly 20 rmax");
		WriteLine("-----------------------------------------------------------------");

		//-----------------------Investigate convergence with npoints----------------------
		WriteLine("Investigating the convergence with respect to npoints");
		WriteLine("Done with 10<=npoints<=200, dr = 0.1 Bohr Radius");
		using(var outfile = new System.IO.StreamWriter("Npoints_Out.txt")){
			for(int npoints=10; npoints <= 200; npoints++){
				double dr=0.1; //Set spacing to be 0.1 Bohr Radius
				vector r = new vector(npoints);
				for(int i=0; i<npoints; i++) r[i]=dr*(i+1);
				matrix H = new matrix(npoints,npoints);
				for(int i=0; i<npoints-1; i++){
		  			matrix.set(H,i,i,-2);
					matrix.set(H,i,i+1,1);
					matrix.set(H,i+1,i,1);
		  		}
				matrix.set(H,npoints-1,npoints-1,-2);
				H*=-0.5/dr/dr;
				for(int i=0;i<npoints;i++) H[i,i]+=-1/r[i];

				//EVD time
				matrix D = H.copy(); 
				matrix V = new matrix(npoints,npoints);
				V.set_unity();
				JacobiEV.JacobiCyclic(D,V);

				//Output the results
				outfile.WriteLine($"{npoints} {D[0,0]} {D[1,1]} {D[2,2]}"); //Outputting the three lowest eigenvalues
			}
		}
		WriteLine("The resulting plot can be seen as NpointsConv_fig.pdf");
		WriteLine("The three lowest eigenvalues converge within roughly 180 points");
		WriteLine("-----------------------------------------------------------------");

		//Plot and compare resulting eigenfunctions (wavefunctions)
		WriteLine("We now wish to evaluate the calculated eigenfunctions");
		WriteLine("The parameters should be chosen well above the limits found above to ensure convergence.");
		WriteLine("Parameters chosen: rmax = 40, npoints = 300, dr = rmax/(npoints+1)");
		double rmax2 = 40; 
		int npoints2 = 300; 
		double dr2 = rmax2/(npoints2+1); 
		vector r2 = new vector(npoints2);
		for(int i=0; i<npoints2; i++) r2[i]=dr2*(i+1);
		matrix H2 = new matrix(npoints2,npoints2);
		for(int i=0; i<npoints2-1; i++){
  			matrix.set(H2,i,i,-2);
			matrix.set(H2,i,i+1,1);
			matrix.set(H2,i+1,i,1);
  		}
		matrix.set(H2,npoints2-1,npoints2-1,-2);
		H2*=-0.5/dr2/dr2;
		for(int i=0;i<npoints2;i++) H2[i,i]+=-1/r2[i];

		//EVD time
		matrix D2 = H2.copy(); 
		matrix V2 = new matrix(npoints2,npoints2);
		V2.set_unity();
		JacobiEV.JacobiCyclic(D2,V2);

		//Output the results
		using(var outfile = new System.IO.StreamWriter("EigenFuncs_Out.txt")){
			for(int i=0; i< r2.size; i++){
				outfile.WriteLine($"{r2[i]} {V2[0][i]*1.0/Sqrt(dr2)} {-V2[1][i]*1.0/Sqrt(dr2)} {-V2[2][i]*1.0/Sqrt(dr2)}"); //Outputting the three lowest eigenfunctions
				//outfile.WriteLine($"{r2[i]} {V2[0][i]} {V2[1][i]} {V2[2][i]}"); //Outputting the three lowest eigenfunctions
				//Normalized all solutions with 1.0/Sqrt(dr2)
			}
		}

		//Analytical results taken from Griffiths table 4.7 - radial wavefunctions of hydrogen
		using(var outfile = new System.IO.StreamWriter("RadialWaves_Out.txt")){
			for(double z=0; z<rmax2; z+=1.0/32){
				//Assume a=1
				double R1 = z*2*Exp(-z);
				double R2 = z*1.0/Sqrt(2)*(1-1.0/2*z)*Exp(-z/2);
				double R3 = z*2.0/(3*Sqrt(3))*(1-2.0/3*z+2.0/27*z*z)*Exp(-z/3);
				outfile.WriteLine($"{z} {R1} {R2} {R3}"); //Outputting the analytical radial wavefunctions
			}
		}
		WriteLine("The three lowest wavefunctions are plotted against the analytical ones in Eigenfunctions_fig.pdf");
		WriteLine("The numerical solution corresponds extremely well with the analytical one!");
		WriteLine("--------------------------------------------------------------------------");

	}//Main
}//main
