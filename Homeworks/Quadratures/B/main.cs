using System; 
using static System.Console; 
using static System.Math; 

public static class main{
	public static void Main(){
		WriteLine("------------------------------------------------");
		WriteLine("Checking implemented Clenshaw-Curtis integrator on various functions:");
		int i = 0;
		Func<double,double> invsqrtx = (x => {i++; return 1.0/Sqrt(x);});
		double invsqrtxInt = quad.integrator(invsqrtx,0,1);
		WriteLine($"Integral with ordinary integrator of 1/sqrt(x) = {invsqrtxInt} using i={i} calls");

		int j = 0;
		Func<double,double> invsqrtx_vt = (x => {j++; return 1.0/Sqrt(x);});
		double invsqrtxInt_vt = quad.vt_integrator(invsqrtx_vt,0,1);
		WriteLine($"Integral with Clenshaw-Curtis integrator of 1/sqrt(x) = {invsqrtxInt_vt} using j={j} calls");

		int k = 0;
		Func<double,double> lnxdivx = (x => {k++; return Log(x)/Sqrt(x);});
		double invlnxdivx = quad.integrator(lnxdivx,0,1);
		WriteLine($"Integral with ordinary integrator of ln(x)/Sqrt(x) = {invlnxdivx} using k={k} calls");
		
		int l = 0;
		Func<double,double> lnxdivx_vt = (x => {l++; return Log(x)/Sqrt(x);});
		double invlnxdivx_vt = quad.vt_integrator(lnxdivx_vt,0,1);
		WriteLine($"Integral with Clenshaw-Curtis integrator of ln(x)/Sqrt(x) = {invlnxdivx_vt} using l={l} calls");

		WriteLine("------------------------------------------------");
		WriteLine("Comparing with python integration routines - My Clenshaw-Curtis is faster!!!");
		



	}//Main
}//main
