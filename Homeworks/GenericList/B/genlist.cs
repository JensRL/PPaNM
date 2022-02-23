using static System.Console;

public class genlist<T>{
	public T[] data;
	public int size=0,capacity=2;
	public genlist(){ data = new T[capacity]; }
	public void push(T item){ /* add item to list */
		if(size==capacity){
			T[] newdata = new T[capacity*=2];
			for(int i=0;i<size;i++)
				newdata[i]=data[i];
				data=newdata;
			}
		data[size]=item;
		size++;
		WriteLine($"Size of array: {size}");
		WriteLine($"Capacity of array: {capacity}");
		}

	public void remove(int i){
		for(int j=i; j<size; j++) {
			data[j] = data[j+1];
			//size--;
			WriteLine($"j is now {j}");
		}
	}
	
}

