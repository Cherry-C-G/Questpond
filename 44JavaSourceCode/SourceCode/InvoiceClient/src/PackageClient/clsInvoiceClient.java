package PackageClient;
import InterFaceInvoice.*;
import Invoice.*;
import java.io.*;
public class clsInvoiceClient {

	/**
	 * @param args
	 */
	public static void main(String[] args) 
	{
	 try 
	 { 
		 	System.out.println("Enter The invoice type");
		 	BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
		    int intInvoiceType  = Integer.parseInt(in.readLine()); 
		    IInvoice objInvoice = clsFactoryInvoice.getInvoice(intInvoiceType);
		    objInvoice.print();
		   
	 }
	 catch (Exception e)
	 {
		  
	 } 


	}

}
