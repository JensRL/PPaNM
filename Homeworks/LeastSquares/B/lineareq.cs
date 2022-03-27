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
	
	public static vector QRGSSolver(matrix A, vector b){
		matrix Q = A.copy();
		matrix R = new matrix(A.size2, A.size2);
		QRGS(Q,R);
		return QRGSSolver(Q,R,b);
	}

	public static vector QRGSSolver(matrix Q, matrix R, vector b){ //Solve QRGS 
		matrix QT = Q.transpose();
		vector y = QT*b;
		backsub(R,y);
		return y;
	}

	public static matrix QRGSInverse(matrix Q, matrix R){//Calculate inverse of A
		int n = Q.size2;
		matrix I = new matrix(n,n);
		I.set_identity();

		matrix inv = new matrix(n,n);
		for(int i=0; i<n; i++){
			vector e_i = I[i]; //unit vector in the i direction
			vector x_i = QRGSSolver(Q,R,e_i);
			inv[i] = x_i;
		}
		return inv;
	}
	
}

