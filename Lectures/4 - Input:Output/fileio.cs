using System; 
using static System.Console;  
using System.IO;

class main{
		static public int Main(){
			var reader = new System.IO.StreamReader("input.txt");
			var writer = new System.IO.StreamWriter("outfile.txt", append:false);

			//Reading from the input steam
			string line = reader.ReadLine(); //Reads until the next /n it meets
			writer.WriteLine($"line={line}");
			string[] words = line.Split(); //Default split uses whitespace characters
			foreach(string word in words){
				writer.WriteLine($"word = {word}");
				double x = double.Parse(word);
				writer.WriteLine($"x={x}");
			}
			
			reader.Close();
			writer.Close();
			return 0;
		}


}
