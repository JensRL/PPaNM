using System; 
using static System.Console;
using System.Threading;

public class main{
	public class data{public int a,b; public double sum;} //Creating data class to pull into harm function
	//We will create separate instances of data for each thread to avoid sharing memory between cpu cores
	
	public static void harm(object obj){
		data d = (data)obj;
		d.sum = 0; 
		WriteLine($"Harmonic Sum from {d.a} to {d.b}");
		for(int i=d.a; i<d.b; i++){
			d.sum += 1.0/i;
		}
		WriteLine($"Harmonic Sum from {d.a} to {d.b} is equal to {d.sum}");

	}
	public static void Main(string[] args){
		WriteLine("Using one thread:");
		int N = (int)1e8;
		if(args.Length>0) N = (int)double.Parse(args[0]);
		WriteLine($"N = {(float)N}");
		//Running a single thread
		data x = new data();
		x.a = 1;
		x.b = N;
		Thread t1 = new Thread(harm);
		t1.Start(x); 
		t1.Join();
		WriteLine($"Using 1 Thread: Harmonic Sum from {1} to {N} is equal to {x.sum}");
	}
}






