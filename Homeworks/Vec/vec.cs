using static System.Console;
using static System.Math;

public class vec{
		public double x,y,z;

		//Constructors
		public vec(double a, double b, double c){
				x=a; y=b; z=c;
				}
		public vec(){x=y=z=0;}

		//Print Method
		public void print(string s){
				Write(s); WriteLine($"{x} {y} {z}");
				}
		public void print(){this.print("");}

		//Vector Operations
		public static vec operator*(vec u, double c){
				return new vec(c*u.x, c*u.y, c*u.z);
				}

		public static vec operator*(double c, vec u){
				return u*c;
				}

		public static vec operator+(vec u, vec v){
				return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
				}
		public static vec operator+(vec u){return u;}
		public static vec operator-(vec u){return -1*u;}
		public static vec operator-(vec u, vec v){
				return new vec(u.x-v.x, u.y-v.y, u.z-v.z); //More computationally optimal
				}

		//Dot Product
		public static vec dot(vec u, vec v){
				return new vec(u.x*v.x, u.y*v.y, u.z*v.z);
		}
		//Cross Product
		public static vec cross(vec u, vec v){
				return new vec(u.y*v.z-u.z*v.y, u.x*v.z-u.z*v.x, u.x*v.y-u.y*v.x);
		}
		//Norm 
		public static double norm(vec u){
				double norm = (Sqrt(Pow(u.x,2)+Pow(u.y,2)+Pow(u.z,2)));
				return norm;
		}



		
}
