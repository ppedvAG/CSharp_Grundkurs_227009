namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Schleife läuft solange die Bedingung true ist
			{
                Console.WriteLine($"while: {a}");
				if (a == 5)
					break; //Break: beendet die Schleife
                a++;
			} //Nach jedem Ende der Schleife wird die Bedingung nochmal geprüft

			int c = 0;
			int d = 10;
			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //continue: Springt in den Schleifenkopf zurück, überspringe den Rest der Schleife
                Console.WriteLine($"do-while: {c}");
            }
			while (c < d);

			//while (true) { } //Endlosschleife

			c = 0;

			while (true) //do-while mit while(true)
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine($"while-true: {c}");

				if (c >= d) //Bedingung wie bei do-while
					break;
			}

			//int z = 0;
			//while (z < 10)
			//	z++;

			//for + Tab + Tab
			for (int i = 0; i < 10; i++) //Variable wird am Anfang angelegt, dann wird die Bedingung überprüft, dann wird der Code ausgeführt, und dann wird die Variable erhöht
			{
                Console.WriteLine($"for: {i}"); //i nur innerhalb der Schleife sichtbar
            }

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine($"forr: {i}");
			}

			//Array durchgehen
			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			for (int i = 0; i < zahlen.Length; i++) //Array durchgehen und ausgeben
			{
				Console.WriteLine(zahlen[i]); //for Schleife ist fehleranfällig bei Arrays
            }

			//foreach + Tab + Tab
			foreach (int i in zahlen) //Array durchgehen aber kann nicht daneben greifen, da kein Index
			{
                Console.WriteLine(i);
            }

			foreach (int i in zahlen)
                Console.WriteLine(i); //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
			#endregion

			#region Enums
			Wochentag wt = Wochentag.Di; //7 mögliche fixe Zustände
			if (wt == Wochentag.Di)
			{

			}

			//Jeder Enum Wert hat einen Int dahinter (Mo = 0, Di = 1, ...)
			int x = 2;
			Wochentag tag = (Wochentag) x;
            Console.WriteLine(tag);

			int y = (int) tag; //Rückkonvertierung auch möglich

			//String zu Enum Wert konvertieren, Typ muss in spitzer Klammer angegeben werden
			Wochentag p = Enum.Parse<Wochentag>("Mo");
			Wochentag p2 = Enum.Parse<Wochentag>("1"); //Enum.Parse kann auch Zahlen konvertieren

			Wochentag[] tage = Enum.GetValues<Wochentag>(); //Alle Enumwerte in ein Array packen
			foreach (Wochentag wochentag in tage) //Alle Enumwerte aus einem Enum durchgehen
			{
                Console.WriteLine($"Heute ist {wochentag}");
            }
			#endregion

			#region Switch
			//If-ElseIf Baum (unschön)
			if (tag == Wochentag.Mo)
                Console.WriteLine("Wochenanfang");
			else if (tag == Wochentag.Di || tag == Wochentag.Mi || tag == Wochentag.Do || tag == Wochentag.Fr)
                Console.WriteLine("Wochenmitte");
			else if (tag == Wochentag.Sa || tag == Wochentag.So)
                Console.WriteLine("Wochenende");
			else
                Console.WriteLine("Fehler");

			//Strg + .: Schnelloptionen aufrufen
			switch (tag) //Hier angeben welche Variable überprüft werden soll
			{
				case Wochentag.Mo: //Eine if
					Console.WriteLine("Wochenanfang");
					break; //Am Ende jedes Cases ein break machen
				case Wochentag.Di: //Eine Else-If mit ||
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default: //Eine Else
					Console.WriteLine("Fehler");
					break;
			}
			
			switch (x)
			{
				case 0:
                    Console.WriteLine("Die Zahl ist 0");
					break;
				case 1:
					Console.WriteLine("Die Zahl ist 1");
					break;
				case 2:
					Console.WriteLine("Die Zahl ist 2");
					break;
			}

			//Strg + Leertaste: Vorschläge öffnen
			#endregion
		}
	}
}