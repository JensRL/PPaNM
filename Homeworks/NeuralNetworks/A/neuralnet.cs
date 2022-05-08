using System; 
using static System.Math; 

public class neuralnet{
	//Declare parameters to be used throughout algorithm
	public int n; //n hidden neurons
	public Func<double,double> f; //Activation function
	public vector p; //Parameters for Neural Network a_i, b_i, w_i

	public neuralnet(int n, Func<double,double> f){ //Setup of Neural Network
		this.n = n;
		this.f = f; 
		this.p = new vector(3*n);
	}

	public double response(double x){ //Define ANN response 
		double F_p = 0;
		for(int i = 0; i < n; i++){ //Access parameters in p and calculate activation function
			double a = p[3*i+0];
			double b = p[3*i+1];
			double w = p[3*i+2];
			F_p += f((x-a)/b)*w;
		}
		return F_p;
	}

	public void trainer(vector x, vector y){
		Func<vector, double> Costfunc = C => { //Eq. 3 of notes
			p = C; //Set the parameters p equal to the variable of Costfunc
			double sum = 0; 
			for(int i=0; i<x.size; i++){
				sum += Pow(response(x[i])-y[i], 2); //Pow faster than calling response twice?
			}
			return sum/x.size;
		};
		vector v = p;
		var (res, steps) = minimize.QNMini(Costfunc, v); //Minimizing the cost function to establish optimal parameters p
		p = res;
	}
}



