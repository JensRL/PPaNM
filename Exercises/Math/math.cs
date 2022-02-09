using static System.Console;
using static System.Math;
public static class math{
		public static void test(){
				double x=Sin(9), y=Cos(9);
				WriteLine($"Sin^2+Cos^2={x*x+Pow(y,2)}");
				double sqrt2 = Sqrt(2.0);
				WriteLine($"sqrt(2)={sqrt2}");
				WriteLine($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal 2)");
		}
}