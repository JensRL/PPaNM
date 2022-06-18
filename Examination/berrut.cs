using System;
using System.Diagnostics;
using static System.Math;

public class berrut{
	public static double b1(double x, double[] xi, double[] yi){
		double numerator = 0;
		double denominator = 0;
		int n = xi.Length;
		for(int i = 0; i < n; i++){ 
			if(x == xi[i])return yi[i]; //Exact evaluation in certain cases
			numerator += Pow(-1,i)/(x-xi[i])*yi[i];
			denominator += Pow(-1,i)/(x-xi[i]);
		}
		return numerator/denominator;
	}

	public static double b2(double x, double[] xi, double[] yi){
		int n = xi.Length;
		double numerator = 1.0/(x-xi[0])*yi[0] + Pow(-1,n-1)/(x-xi[n-1])*yi[n-1]; //First and third term
		double denominator = 1.0/(x-xi[0]) + Pow(-1,n-1)/(x-xi[n-1]); //First and third term 
		for(int i=1; i<n-1; i++){
			if(x == xi[i])return yi[i];
			numerator += 2*(Pow(-1,i)/(x-xi[i])*yi[i]); //Second term with summation over i 
			denominator += 2*(Pow(-1,i)/(x-xi[i])); 
		}
		return numerator/denominator;
	}
}
