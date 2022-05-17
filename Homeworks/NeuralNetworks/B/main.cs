using System; 
using static System.Console; 
using static System.Math; 
using static System.Random;
public static class main{
	public static void Main(){
		WriteLine("--------------- Testing the implemented Artificial Neural Network --------------");
		WriteLine("The implementation now allows for derivative and integral of interpolant");
		WriteLine("Testing is carried out with respects to interpolation of the same function as before");
		//Define activation function as Gaussian Wavelet
		Func<double, double> GaussW = x => x*Exp(-x*x);
		Func<double, double> GaussWDeriv = x => (1 - 2*x*x)*Exp(-x*x);
		Func<double, double> GaussWInteg = x => -(Exp(-x*x)/2);
		Func<double, double> f = x => 3*x + x*x*Sin(x);
		WriteLine("Activation function = Gaussian Wavelet, testing function f = 3*x+x^2*sin(x)");
		WriteLine("Gaussian Wavelet has analytic derivative and integral => good choice for activation function");
		
		//Set up neural network
		int n = 15; //Hidden neurons
		neuralnet ANN = new neuralnet(n,GaussW, GaussWDeriv, GaussWInteg);
		double a = -6.3, b = 6.3; //Interval of interest
		int nx = 75; //Supervision points

		//Create x and y arrays for training
		vector xs = new vector(nx);
		vector ys = new vector(nx);

		using(var outfile = new System.IO.StreamWriter("PlottingData.txt")){
			//Create supervision data (x and y values)
			for(int i = 0; i < xs.size; i++){
				xs[i] = a + (b-a)*i/(nx-1); //Where the heck does this expression come from???
				ys[i] = f(xs[i]);
				outfile.WriteLine($"{xs[i]} {ys[i]}");
			}
			outfile.WriteLine($"\n");

			//Forming the parameters vector p for neural network
			for(int i = 0; i < ANN.n; i++){ 
				ANN.p[3*i+0] = a + (b-a)*i/(ANN.n-1);
				ANN.p[3*i+1] = 1; //bs = 1 initially
				ANN.p[3*i+2] = 1; //weights = 1 initially
			}

			//Train the network with the supervision data
			ANN.trainer(xs,ys);

			//Output the response of the trained network
			for(double i = a; i < b; i += 1.0/64){
				outfile.WriteLine($"{i} {ANN.response(i)} {ANN.response_deriv(i)} {ANN.response_integ(i)}");
			}
		}
		WriteLine("The Artificial Neural Network completed the interpolation successfully!");
		WriteLine($"For smooth interpolation the number of hidden neurons required was = {n}");
		WriteLine("The result of the interpolation is seen in figure ANNinterp_fig.pdf");
		WriteLine("The resulting derivatives and integrals are now also indicated");
		WriteLine("-------------------------------------------------------------------------------");

	}//Main
}//main
