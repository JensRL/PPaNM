using System; 
using static System.Console; 
using static System.Math; 

	
public class lineareq{
	public static void backsub(matrix U, vector c){//Make Back-substitution function to call
		for(int i=c.size-1; i>=0; i--){
			double sum = 0; 
			for(int k=i+1; k<c.size; k++){
				sum+=U[i,k]*c[k];
			}
			c[i]=(c[i]-sum)/U[i,i];
		}
	}

	public static void QRGS(matrix A, matrix R){ //Run Gram-Schmidt Process
		int m = A.size2; //Size of matrix A m x m matrix
		for(int i=0; i<m; i++){
			R[i,i] = A[i].norm();
			A[i] = A[i]/R[i,i]; //New orthogonal vector q_i = A_i/R_ii
			for(int j=i+1; j<m; j++){
				R[i,j] = A[i].dot(A[j]);
				A[j] = A[j]-A[i]*R[i,j];
			}
		}
	}

	public static vector QRGSSolver(matrix Q, matrix R, vector b){ //Back Substitution 
		matrix QT = Q.transpose();
		vector y = QT*b;
		backsub(R,y);
		return y;
	}

}

