using System;
using static System.Console;
using static System.Math;

public class epsilon{
        static void Main(){
                maxint();
                minint();
                machineeps();
                epssum();
                
                //Check the approx function for some values a and b
                WriteLine($"1,2: {approx(1,2)}");
                WriteLine($"0,0: {approx(0,0)}");
                WriteLine($"0,1e-10: {approx(0,1e-10)}");
        }
        public static void maxint(){
                int i = 1;
                while(i+1>i) {i++;}
                
                WriteLine($"My max int = {i}");
                WriteLine($"System max int = {int.MaxValue}");
        }

        public static void minint(){
                int i = 1;
                while(i+1>i) {i=i-1;}
                
                WriteLine($"My min int = {i}");
                WriteLine($"System min int = {int.MinValue}");
        }

        public static void machineeps(){
                // Check double eps
                double x=1; 
                while(1+x!=1){x/=2;} x*=2;
                WriteLine($"Double epsilon = {x}");
                WriteLine($"Double Machine epsilon = {System.Math.Pow(2,-52)}");

                // Check float eps
                float y=1F; 
                while((float)(1F+y) != 1F){y/=2F;} y*=2F;
                WriteLine($"Float epsilon = {y}");
                WriteLine($"Float Machine epsilon = {System.Math.Pow(2,-23)}");
        }

        public static void epssum(){
                int n=(int)1e6;
                double epsilon=Pow(2,-52);
                double tiny=epsilon/2;
                double sumA=0,sumB=0;
                
                //Incorrect way
                sumA+=1; 
                for(int i=0;i<n;i++){sumA+=tiny;}
                WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");

                //Correct way
                for(int i=0;i<n;i++){sumB+=tiny;} 
                sumB+=1; // THE CORRECT CALCULATION DEPENDS ON THE LOCATION OF THE += TO THE SUM!
                WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
        }

        static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
               return Math.Abs(a-b) < tau || Math.Abs(a-b)/(Math.Abs(a)+Math.Abs(b)) < epsilon;
        }



}