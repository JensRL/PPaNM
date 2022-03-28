using System; 
using static System.Console; 
using static System.Math; 

public class JacobiEV{
	public static void timesJ(matrix A, int p, int q, double theta){ //Create function for A*J
		double c=Cos(theta),s=Sin(theta);
		for(int i=0; i<A.size1; i++){
			double aip=A[i,p],aiq=A[i,q];
			A[i,p]=c*aip-s*aiq;
			A[i,q]=s*aip+c*aiq;
			}
	}

	public static void Jtimes(matrix A, int p, int q, double theta){ //Create function for J*A
		double c=Cos(theta),s=Sin(theta);
		for(int j=0; j<A.size1; j++){
			double apj=A[p,j],aqj=A[q,j];
			A[p,j]= c*apj+s*aqj;
			A[q,j]=-s*apj+c*aqj;
		}
	}

	public static int JacobiCyclic(matrix A, matrix V){
		int sweeps = 0; //Keep track of number of sweeps
		int n = A.size1; //Set n to be size of matrix A
		V.set_unity(); //Make V a matrix of ones (full basis) to later contain eigenvectors
		bool changed; 
		do{
			sweeps++;
			changed=false;
			for(int p=0; p<n-1; p++){
				for(int q=p+1; q<n; q++){
					double apq = A.get(p,q);
					double app = A.get(p,p);
					double aqq = A.get(q,q);
					double theta = 0.5*Atan2(2*apq,aqq-app);
					double c=Cos(theta),s=Sin(theta);
					double new_app = c*c*app - 2*s*c*apq + s*s*aqq; //Notes Eq. 10pp
					double new_aqq=s*s*app + 2*s*c*apq + c*c*aqq; //Notes Eq. 10qq
					if(new_app!=app || new_aqq!=aqq){ // do rotation
						changed=true;
						timesJ(A,p,q, theta);
						Jtimes(A,p,q,-theta); // A←J^T*A*J 
						timesJ(V,p,q, theta); // V←V*J
					}
				}
			}
		} while(changed);
		return sweeps;
	}//Func
}//Main



