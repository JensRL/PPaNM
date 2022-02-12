using static System.Console;

public class vec{
		public double x,y,z;

		//Constructors
		public vec(double a, double b, double c){
				x=a; y=b; z=c;
				}
		public vec(){x=y=z=0;}

		//Print Method: u.print("u=");
		public void print(string s){
				Write(s); WriteLine($"{x} {y} {z}");
				}
		public void print(){this.print("");}
		public static void print(vec v){v.print("static method:");}

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
		

}
