using System;
using static System.Console; 
using static System.Math;

public class stdin{
	public static void Main(){
		WriteLine("--------------------------------------------------------------------------------");
		WriteLine("Reading input x from different streams and outputting table with x, sin(x) and cos(x)");
		WriteLine("Reading from std input stream:");
		char[] delimiters = {' ','\t','\n'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for( string line = ReadLine(); line != null; line = ReadLine() ){
			var words = line.Split(delimiters,options);
			foreach(var word in words){
				double x = double.Parse(word);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
        }
	}
}