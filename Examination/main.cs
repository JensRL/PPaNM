using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static void Main(){
		//Create Tabulation Values and call cspline + berrut for each one
		WriteLine("------------------------------------------------------------------");
		WriteLine("FOR FULL PROJECT DESCRIPTION REFER TO THE README.txt FILE");
		WriteLine("The Berrut B1 rational function interpolation algorithm is tested");
		WriteLine("Multiple comparisons with the cubic- and quadratic spline algorithms have been made");
		WriteLine("The oscillatory behavior due to the Runge phenomenon has generally been reduced by the Berrut approach");
		WriteLine("Multiple test cases were considered and can be inspected in the outputted pdf figures");
		WriteLine("------------------------------------------------------------------");		
		using(var outfile = new System.IO.StreamWriter("PlottingData.txt")){
			//---------------------Create first interpolation dataset-----------------------
			double[] x1 = new double[] {0.5,1,2,3,4,5,6,6.5};
			double[] y1 = new double[] {1,1,1,1,2,2,2,2};
			cspline c1 = new cspline(x1,y1);
			qspline q1 = new qspline(x1,y1);
			//Output dataset
			for(int i = 0; i<=x1.Length-1; i++){outfile.WriteLine($"{x1[i]} {y1[i]}");};
			outfile.WriteLine($"\n");
			for(double x = x1[0]; x <= x1[x1.Length-1]; x+=1.0/32){
				outfile.WriteLine($"{x} {q1.eval(x)} {c1.eval(x)} {berrut.b1(x,x1,y1)}");
			}
			outfile.WriteLine($"\n");

			//---------------------Create second interpolation dataset-----------------------
			Func<double, double> f2 = x => 3*x + x*x*Sin(x);
			double[] x2 = new double[] {-6,-5,-4,-3,-2,-1,0,1,2,3,4,5,6};
			double[] y2 = new double[x2.Length];
			for(int i=0; i<=x2.Length-1; i++){
				y2[i] += f2(x2[i]);
			}
			//Output dataset
			for(int i = 0; i<=x2.Length-1;i++){outfile.WriteLine($"{x2[i]} {y2[i]}");};
			outfile.WriteLine($"\n");
			cspline c2 = new cspline(x2,y2);
			qspline q2 = new qspline(x2,y2);
			for(double x = x2[0]; x<=x2[x2.Length-1]; x+=1.0/32){
				outfile.WriteLine($"{x} {q2.eval(x)} {c2.eval(x)} {berrut.b1(x,x2,y2)}");
			}
			outfile.WriteLine($"\n");

			//---------------------Create third interpolation dataset-----------------------
			Func<double, double> f3 = x => 1.0/Sqrt(2*PI)*Exp(-(x*x)/(2));
			double[] x3 = new double[] {-3,-2.5,-2,-1.5,-1,-0.5,0,0.5,1,1.5,2,2.5,3};
			double[] y3 = new double[x3.Length];
			for(int i=0; i<=x3.Length-1; i++){
				y3[i] += f3(x3[i]);
			}
			//Output dataset
			for(int i = 0; i<=x3.Length-1;i++){outfile.WriteLine($"{x3[i]} {y3[i]}");};
			outfile.WriteLine($"\n");
			cspline c3 = new cspline(x3,y3);
			qspline q3 = new qspline(x3,y3);
			for(double x = x3[0]; x<=x3[x3.Length-1]; x+=1.0/32){
				outfile.WriteLine($"{x} {q3.eval(x)} {c3.eval(x)} {berrut.b1(x,x3,y3)}");
			}
			outfile.WriteLine($"\n");	

			//---------------------Create third interpolation dataset-----------------------
			Func<double, double> f4 = x => Sin(20*x)*Exp(-2*x);
			double[] x4 = new double[] {-1,-0.8,-0.6,-0.4,-0.2,0,0.2,0.4,0.6,0.8,1,1.2};
			double[] y4 = new double[x4.Length];
			for(int i=0; i<=x4.Length-1; i++){
				y4[i] += f4(x4[i]);
			}
			//Output dataset
			for(int i = 0; i<=x4.Length-1;i++){outfile.WriteLine($"{x4[i]} {y4[i]}");};
			outfile.WriteLine($"\n");
			cspline c4 = new cspline(x4,y4);
			qspline q4 = new qspline(x4,y4);
			for(double x = x4[0]; x<=x4[x4.Length-1]; x+=1.0/32){
				outfile.WriteLine($"{x} {q4.eval(x)} {c4.eval(x)} {berrut.b1(x,x4,y4)}");
			}
			outfile.WriteLine($"\n");

		}

		using(var outfile = new System.IO.StreamWriter("BerrutCompData.txt")){
			//---------------------Create first interpolation dataset-----------------------
			double[] x1 = new double[] {0.5,1,2,3,4,5,6,6.5};
			double[] y1 = new double[] {1,1,1,1,2,2,2,2};
			cspline c1 = new cspline(x1,y1);
			qspline q1 = new qspline(x1,y1);
			//Output dataset
			for(int i = 0; i<=x1.Length-1; i++){outfile.WriteLine($"{x1[i]} {y1[i]}");};
			outfile.WriteLine($"\n");
			for(double x = x1[0]; x <= x1[x1.Length-1]; x+=1.0/32){
				outfile.WriteLine($"{x} {q1.eval(x)} {c1.eval(x)} {berrut.b1(x,x1,y1)} {berrut.b2(x,x1,y1)}");
			}
			outfile.WriteLine($"\n");

			//---------------------Create third interpolation dataset-----------------------
			Func<double, double> f4 = x => Sin(20*x)*Exp(-2*x);
			double[] x4 = new double[] {-1,-0.8,-0.6,-0.4,-0.2,0,0.2,0.4,0.6,0.8,1,1.2};
			double[] y4 = new double[x4.Length];
			for(int i=0; i<=x4.Length-1; i++){
				y4[i] += f4(x4[i]);
			}
			//Output dataset
			for(int i = 0; i<=x4.Length-1;i++){outfile.WriteLine($"{x4[i]} {y4[i]}");};
			outfile.WriteLine($"\n");
			cspline c4 = new cspline(x4,y4);
			qspline q4 = new qspline(x4,y4);
			for(double x = x4[0]; x<=x4[x4.Length-1]; x+=1.0/32){
				outfile.WriteLine($"{x} {q4.eval(x)} {c4.eval(x)} {berrut.b1(x,x4,y4)} {berrut.b2(x,x4,y4)} ");
			}
			outfile.WriteLine($"\n");
		}
	}//Main
}//main
