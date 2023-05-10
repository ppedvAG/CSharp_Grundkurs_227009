namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(2, 3); //Funktionsaufruf über den Namen der Funktion, Parameter müssen mit angegeben werden
			PrintAddiere(5, 1);
			PrintAddiere(4, 9);

			int summe = Addiere(3, 4); //Ergebnis der Addiere Funktion in eine Variable schreiben
            Console.WriteLine(summe);

			double summe2 = Addiere(4.5, 1); //Über die Parameter wird gesteuert welche Funktion ausgewählt wird
            Console.WriteLine(summe2);

			int summe3 = Addiere(3, 4, 5);
            Console.WriteLine(summe3);

			Summiere(1, 2, 3); //3 Parameter
			Summiere(1, 2, 3, 4, 5, 6); //6 Parameter
			Summiere(); //Keine Parameter sind auch beliebig viele Parameter

			Subtrahiere(1, 2);
			Subtrahiere(1, 2, 3);

			SubtrahiereOderAddiere(3, 8);
			SubtrahiereOderAddiere(1, 4);
			SubtrahiereOderAddiere(3, 2);
			SubtrahiereOderAddiere(7, 8, true);

			Test(y: 4, z: 1); //w und x übersprungen
			Test(w: 3, z: 9); //x und y übersprungen

			int sub;
			int add = AddiereUndSubtrahiere(3, 4, out sub);
            Console.WriteLine($"Summe: {add}, Differenz: {sub}");

			//int result;
			bool b = int.TryParse("123", out int result); //Feld wird hier direkt erstellt
			if (b)
			{
                Console.WriteLine($"Parsen hat funktioniert: {result}");
            }
			else
			{
                Console.WriteLine("Parsen hat nicht funktioniert");
            }

			(int, int) ergebnisse = AddiereUndSubtrahiere(4, 5);
            Console.WriteLine($"Summe: {ergebnisse.Item1}, Differenz: {ergebnisse.Item2}");
        }

		/// <summary>
		/// Berechnet die Summe von x und y und schreibt diese in die Konsole.<br/>
		/// Funktion mit void (kein Rückgabewert), Zwei Parameter: x und y
		/// </summary>
		/// <param name="x">Die erste Zahl</param>
		/// <param name="y">Die zweite Zahl</param>
		static void PrintAddiere(int x, int y)
		{
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

		/// <summary>
		/// Funktion mit Rückgabetyp (int), muss ein Ergebnis zurück geben
		/// </summary>
		/// <returns>Die Summe von x und y</returns>
		static int Addiere(int x, int y)
		{
			return x + y; //return: Ergebnis der Funktion zurückgeben, Funktion wird beendet
        }

		/// <summary>
		/// Überladung: Methode mit dem selben Namen wie eine andere Methode, aber mit anderen Parametern
		/// </summary>
		static double Addiere(double x, double y)
		{
			return x + y;
		}

		static int Addiere(int x, int y, int z)
		{
			return x + y + z;
		}

		/// <summary>
		/// Params: Gibt die Möglichkeit beliebig viele Parameter zu übergeben
		/// </summary>
		static double Summiere(params double[] zahlen)
		{
			//double d = 0;
			//foreach (double x in zahlen)
			//	d += x;
			//return d;
			return zahlen.Sum();
		}

		/// <summary>
		/// Optionaler Parameter (hier z): Gibt Parametern Standardwerte, müssen bei Aufruf der Funktion nicht übergeben werden
		/// </summary>
		static double Subtrahiere(int x, int y, int z = 0)
		{
			return x - y - z;
		}

		/// <summary>
		/// Über den Boolean wird gesteuert wie die Funktion arbeitet (Sonderfall)
		/// </summary>
		/// <param name="add">Steuert ob die Funktion Addiert oder Subtrahiert (true = Addieren, false = Subtrahieren)</param>
		static double SubtrahiereOderAddiere(int x, int y, bool add = false)
		{
			//if (add)
			//	return x + y;
			//else
			//	return x - y;
			return add ? x + y : x - y;
		}

		/// <summary>
		/// Über optionale Parameter kann die Funktion konfiguriert werden
		/// </summary>
		static void Test(int w = 0, int x = 0, int y = 0, int z = 0) { }

		/// <summary>
		/// out: Gibt die Möglichkeit mehrere Werte zurück zu geben
		/// </summary>
		/// <param name="sub">Das Ergebnis der Subtraktion</param>
		/// <returns>Das Ergebnis der Addition</returns>
		static int AddiereUndSubtrahiere(int x, int y, out int sub)
		{
			sub = x - y;
			return x + y;
		}

		/// <summary>
		/// Tupel: Typ der mehrere Werte halten, ähnlich wie Array, aber einfacher zum Bearbeiten ist
		/// </summary>
		/// <returns>Ein Tupel, welches das Ergebnis der Addition (Item1) und das Ergebnis der Subtraktion (Item2) zurückgibt</returns>
		static (int, int) AddiereUndSubtrahiere(int x, int y)
		{
			return (x + y, x - y);
		}

		/// <summary>
		/// Enum als Parameter um eine Sicherheit zu bieten bei den Parametern
		/// </summary>
		static string PrintWochentag(DayOfWeek tag)
		{
			switch(tag)
			{
				case DayOfWeek.Monday: return "Montag"; //Bei einem Switch mit return muss kein break verwendet werden
				case DayOfWeek.Tuesday: return "Dienstag";
				case DayOfWeek.Wednesday: return "Mittwoch";
				case DayOfWeek.Thursday: return "Donnerstag";
				case DayOfWeek.Friday: return "Freitag";
				case DayOfWeek.Saturday: return "Samstag";
				case DayOfWeek.Sunday: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}

		static void PrintZahl(int z)
		{
            Console.WriteLine(z);
            return; //Aus Funktion herausspringen / Funktion beenden
            Console.WriteLine(); //Kann nicht erreich werden
        }
	}
}