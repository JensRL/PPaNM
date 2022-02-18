using System;
using static System.Console; 

class main{
	public delegate double fun_of_3_doubles(double x, double y, double z);

	public static Func<double> make_fa(){
		double a=0;
		Func<double> fa = delegate(){a++; return a;}; //The local variable is now in the function definition!
		return fa; //The compiler captures a closure, and returns the function + the environment (variables)
	}

	public static void Main(){
		//Defining Functions
		System.Func<double> fun = delegate(){return 7;}; //a delegate type 
		Func<double,double> square = delegate(double x){return x*x;}; //last argument inside <> is return type
		Action hello = delegate(){WriteLine("hello");}; //A function with no return type 
		fun_of_3_doubles f3 = delegate(double x, double y, double z){return 9;};
		Func<double, double, double, double> f4 = delegate(double x, double y, double z){return 4;};

		//Test if it works
		hello();
		WriteLine($"fun() = {fun()} should be equal 7");
		WriteLine($"Square of 2 = {square(2)} should be equal 4");
		WriteLine($"f3(2) = {f3(1,2,3)} should be equal 9");
		WriteLine($"f4(2) = {f4(1,2,3)} should be equal 4");

		//New functions
		double a=0;
		Action fa = delegate(){a++;}; //The function will reference the defined variable a
		fa();
		WriteLine($"a = {a} should be 0 or >1<"); //The variable is captured by reference in fa
		fa();
		WriteLine($"a = {a} should be 0 or >2<"); //Would be 0 if captured by value instead of reference
		fa();
		WriteLine($"a = {a} should be 0 or >3<"); 
		fa();
		WriteLine($"a = {a} should be 0 or >4<"); 

		//Call make_fa function twice
		Func<double> fb = make_fa();
		WriteLine($"fb() = {fb()} should be 1");
		WriteLine($"fb() = {fb()} should be 2");
		WriteLine($"fb() = {fb()} should be 3"); //The variable is not accesible, but it sits in our function and thus changes
		Func<double> fc = make_fa();
		WriteLine($"fc() = {fc()} should be 4 or >1<"); //The variable is not kept from the previous function call - returns a new closure!
	}
}