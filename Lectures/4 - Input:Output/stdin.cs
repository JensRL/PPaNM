using System; 
using static System.Console;  
using System.IO;

class main{
		static public int Main(){
			//Outputting to the out and error streams
			WriteLine("This goes to stdout");
			Out.WriteLine("This goes to stdout");
			Error.WriteLine("This goes to stderr");
			System.IO.TextWriter stdout = System.Console.Out;
			stdout.WriteLine("Another stdout");

			//Reading from the input stream
			string line = ReadLine(); //Reads until the next /n it meets
			WriteLine($"line={line}");
			string[] words = line.Split(); //Default split uses whitespace characters
			foreach(string word in words){
				WriteLine($"word = {word}");
				double x = double.Parse(word);
				WriteLine($"x={x}");
			}
			/*
			string line = In.ReadLine();
			var stdin = System.Console.In;
			string s = stdin.ReadLine();
			*/
			return 0;
		}


}
