namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Eine Variable die mehrere Werte speichern kann (statt einem)
			int[] zahlen; //Arrayvariable mit [] nach Typ (<Typ>[])
			zahlen = new int[10]; //Array mit Länge 10 erstellen
			zahlen[3] = 10; //An die Stelle 3 den Wert 10 schreiben
			//zahlen[10] = 10; //Nicht möglich, da Indizes im Array von 0-9 gehen
			Console.WriteLine(zahlen[3]);

            Console.WriteLine(zahlen.Length); //Die Länge des Arrays (10)
            Console.WriteLine(zahlen.Contains(10)); //Überprüft, ob ein Element im Array enthalten ist -> true
            Console.WriteLine(zahlen.Contains(5)); //false

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, Länge automatisch (5)
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise (wie oben, nur kurz)
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5, 6, 7 }; //Kürzeste Schreibweise

			//Mehrdimensionale Arrays: Arrays mit mehreren Koordinaten (X, Y, Z, ...)
			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3): Deklaration mit Komma in der Klammer
			zweiDArray[1, 1] = 9;
			Console.WriteLine(zweiDArray[1, 1]);

			zweiDArray = new int[,] //Direkte Initialisierung
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

            Console.WriteLine(zweiDArray.Length); //Produkt der Dimensionen (3x3) = 9
            Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen finden (2)
            Console.WriteLine(zweiDArray.GetLength(0)); //Länge der gegebenen Dimension zurückgeben (3)
            Console.WriteLine(zweiDArray.GetLength(1)); //Länge der gegebenen Dimension zurückgeben (3)
			#endregion

			#region Bedingungen
			//Vergleichsoperatoren: ==, !=, <, >, <=, >=
			//Zwei Werte vergleichen (z.B. 2 Ints, 2 Strings, ...)

			//Logische Operatoren: &&, ||, !, ^
			//Prädikate verbinden -> a == b && a == c

			int z1 = 8;
			int z2 = 5;

			if (z1 == 8) //Wenn z1 8 ist
			{
				//Führe den Code hier aus
			}
			else
			{
				//Wenn z1 nicht 8 ist
			}

			if (z1 < z2)
			{
				//Wenn z1 kleiner als z2
			}

			if (z1 == 8) //Wenn z1 8 ist
			{
				//Führe den Code hier aus
			}
			else if (z1 == z2)
			{
				//Wenn z1 gleich z2
			}
			else
			{
				//Wenn z1 nicht 8 ist
			}

			if (z1 == 8 && z2 == 5)
			{
				//Wenn z1 gleich 8 und z2 gleich 5
			}

			if (z1 == 8 || z2 == 5)
			{
				//Wenn z1 gleich 8 oder z2 gleich 5 oder beides
			}

			if (zahlen.Contains(10))
			{
				//Wenn zahlen 10 enthält
			}

			if (!zahlen.Contains(5))
			{
				//Wenn zahlen nicht 5 enthält
			}

			if (z1 == 8 ^ z2 == 5)
			{
				//Wenn z1 gleich 8 oder z2 gleich 5 aber nicht beides
			}

			//Fragezeichen Operator (Ternary Operator): if's vereinfachen
			if (z1 != z2)
			{
                Console.WriteLine("z1 ungleich z2");
            }
			else
			{
                Console.WriteLine("z1 gleich z2");
            }

			//Bei einzeiligen if's und elses können die Klammern weggelassen werden
			if (z1 != z2)
				Console.WriteLine("z1 ungleich z2");
			else
				Console.WriteLine("z1 gleich z2");

			//? ist die if, : ist die else
			string s = z1 != z2 ? "z1 ungleich z2" : "z1 gleich z2";
            Console.WriteLine(s);

			Console.WriteLine(z1 != z2 ? "z1 ungleich z2" : "z1 gleich z2");

            Console.WriteLine(zahlen.Contains(10) ? "zahlen enthält 10" : "zahlen enthält nicht 10");
            #endregion
        }
	}
}