using System; 
using static System.Console; 
using static System.Math; 
using static passf;

public class main{
	public static void Main(){
		for(int k=1; k<=3; k++){
			WriteLine($"Making table for sin({k}*x)");
			passf.make_table(x => Sin(k*x), 0, 2*PI, 0.1);
		}
	}
}