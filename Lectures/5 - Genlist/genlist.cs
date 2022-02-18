public class genlist<T>{
	public T[] data; 
	public genlist(){data=new T[0];}
	public void push(T item){
		int n=data.Length;
		T[] newdata = new T[n+1]; //Allocates less memory as we expand array y a factor of 2 less often
		for(int i=0; i<n; i++)newdata[i]=data[i];
		data=newdata; //data will be garbage collected
		data[n]=item;
	}
}