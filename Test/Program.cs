using System;

class harm{
static double f(int i){
	return 1.0/i;
	}

static int Main(){
	double s=0;
	int n=(int)1e7;
	Console.Write("n={0}\n",n);
	for(int i=1; i<=n;i++)s+=f(i);
	System.Console.Write("s={0}\n",s);
	return 0;
	}	
}
