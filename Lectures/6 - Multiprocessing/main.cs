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
		int N = (int)1e8;
		if(args.Length>0) N = (int)double.Parse(args[0]);
		WriteLine($"N = {(float)N}");
		//Separating the sum into two parts, one for each thread
		data x = new data();
		x.a = 1;
		x.b = N/2;
		data y = new data();
		y.a = N/2;
		y.b = N+1;
		Thread t1 = new Thread(harm);
		Thread t2 = new Thread(harm);
		t1.Start(x); //Giving the object to work with in thread t1
		t2.Start(y);
		t1.Join(); //Joining the forked threads t1 and t2 back into the main thread
		t2.Join();
		WriteLine($"Harmonic Sum from {1} to {N} is equal to {x.sum+y.sum}");
	}
}






