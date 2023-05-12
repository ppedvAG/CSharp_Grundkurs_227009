namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception("Logexception");

		try //Codeblock markieren + Rechtsklick + Snippet -> Surround With -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions sind die Fehler die auftreten können
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException
			if (x == 0)
				throw new TestException("Die Zahl darf nicht 0 sein"); //beliebige Exception werfen
		}
		catch (FormatException e) //Keine Zahl (Buchstaben)
		{
            Console.WriteLine("Keine Zahl eingegeben");
        }
		catch (OverflowException e) //Zu große/kleine Zahl
		{
            Console.WriteLine("Die Zahl ist zu klein/groß");
            Console.WriteLine();
            Console.WriteLine(e.Message); //Die interne Nachricht zum Fehler
            Console.WriteLine(e.StackTrace); //Von unten nach oben lesen um den Fehlerort zu finden
        }
		catch (TestException e)
		{
            Console.WriteLine("TestException wurde gefangen");
            Console.WriteLine(e.Message);
			e.Test();
        }
		catch (Exception e) //Fängt alle anderen Exceptions
		{
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
			//throw; //Fataler Fehler
		}
		finally //Wird immer ausgeführt auch wenn kein Fehler auftritt
		{
            Console.WriteLine("Parsen abgeschlossen");
        }
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception
{
	public TestException(string? message) : base(message)
	{
	}

	public void Test()
	{

	}
}