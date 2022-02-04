using System;

class harm{
static double f(int i){
	return 1.0/i;
	}

static int Main(){
	double s=0;
	int n=(int)1e7;
	System.Console.Write("n={0}",n);
	for(int i=1; i<=n;i++)s+=f(i);
	System.Console.Write("s={0}",s);
	return 0;
	}	
}
