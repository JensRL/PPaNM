using System; 
using static System.Console;  
using static System.Math; 
using static vec;

class main{
		static void Main(){
				WriteLine("----------------------------------------------------");
				WriteLine("Part A:");
				WriteLine("Checking if generation of vectors and prints work:");
				vec u=new vec(100,200,300);
				u.print("u=");
				vec v=new vec(1,2,3);
				v.print("v=");
				WriteLine("Checking if addition and multiplication operations work:");
				(u+v).print($"u+v = ");
				var w=3*u-v; //If the compiler can figure out the type, you can use var instead of vec
				w.print("w=3*u-v=");
				WriteLine("----------------------------------------------------");
				WriteLine("Part B:");
				WriteLine("Checking dot product, cross product and norm:");
				vec j=new vec(1,5,10); 
				vec k=new vec(5,4,6);
				j.print("j=");
				k.print("k=");
				WriteLine($"Dot Product of j and k: {dot(j,k)}");
				WriteLine($"Cross Product of j and k: {cross(j,k)}");
				WriteLine($"Norm of j: {norm(j)}");
				WriteLine("----------------------------------------------------");
				WriteLine("Part C:");
				WriteLine($"Checking the approx method for vectors j and k: {approx(j,k)}");
				vec c = new vec(1,1,1);
				vec d = new vec(1,1,1);
				c.print("New vector c=");
				d.print("New vector d=");
				WriteLine($"Checking the approx method for vectors c and d: {approx(c,d)}");
				WriteLine("----------------------------------------------------");

		}


}
