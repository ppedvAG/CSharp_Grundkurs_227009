namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 5; i++)
			{
				Fenster f = new Fenster();
			}

			GC.Collect(); //Hier GC erzwingen
			GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren
			#endregion

			#region Static
			//Statische Member: Global
			//Müssen ohne Objekt arbeiten
			//Werden angesprochen über den Klassennamen

			//Console c = new Console();
			//c.WriteLine();
			Console.WriteLine();

			Fenster f20 = new Fenster();
			f20.FensterOeffnen();
			//Fenster.FensterOeffnen(); //nicht möglich, da Methode sich auf ein spezifisches Objekt bezieht

			Fenster.Zaehler++;
            //f2.Zaehler++; //nicht möglich

            Console.WriteLine(Fenster.Zaehler); //7
			#endregion

			#region Werte-/Referenztypen
			//Referenztyp
			//class
			//==, != vergleichen die Speicheradressen
			//Zuweisungen sind Referenzen statt Kopien

			//Wertetyp
			//struct
			//==, != werden die Inhalte verglichen
			//Zuweisungen sind Kopien statt Referenzen

			//Wertetyp
			int original = 5;
			int x = original; //Inhalt wird kopiert
			original = 10; //x != original

			//Referenztyp
			Fenster f1 = new Fenster();
			Fenster f2 = f1; //Referenz zum Objekt f1 herstellen
			f1.SetLaenge(9); //Beide Objekte werden verändert

            Console.WriteLine(f1.GetHashCode());
            Console.WriteLine(f2.GetHashCode());
			#endregion

			#region Null
			Fenster f3; //Standardmäßig null (es hängt keine Referenz zu einem Objekt daran)
			f3 = new Fenster(); //Objekt erstellen und Referenz herstellen
			f3 = null; //Zeiger trennen (Objekt wird dann eventuell eingesammelt)

			//f3.FensterOeffnen(); //Nicht vorhandenes Object kann nicht geöffnet werden

			if (f3 != null)
			{
				f3.FensterOeffnen();
			}
			else
			{
                Console.WriteLine("Fenster existiert nicht");
            }
			
			f3?.FensterOeffnen(); //Schneller Null-Check: Wenn f3 nicht null ist, führe den Code aus, ansonsten wird er übersprungen

			if (f3 is null || f3 is not null) //Selbiges wie == und != null
			{

			}
			#endregion
		}
	}
}