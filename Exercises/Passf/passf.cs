using System; 
using static System.Console; 
using static System.Math; 

public class passf{
	public static void make_table(Func<double,double> f, double a, double b, double dx){
		while (a <= b){
			WriteLine($"x = {a}, sin(x) = {f(a)}");
			a += dx;
		}
		/*
		while (a >= b){
			WriteLine($"x = {b}, sin(x) = {f(b)}");
		}
		*/
	}
}