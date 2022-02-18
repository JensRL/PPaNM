using System;
using static System.Console;
using static System.Math;

public class cmdline{
	public static void Main(string[] args){
		WriteLine("Reading from command line stream:");
		foreach(var arg in args){
			double x = double.Parse(arg);
			WriteLine($"{x} {Sin(x)} {Cos(x)}");
		}
	}
}