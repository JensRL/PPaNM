using static System.Console;
using System;

class main{
	public static void Main(){
		for(double x=0; x<=500; x+=1.0/1000){
			WriteLine($"{x} {sfuncs.ex(x)}");
		}
	}


}