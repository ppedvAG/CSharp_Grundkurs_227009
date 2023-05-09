namespace M002
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Variablen
			//int: Ganze Zahl
			int zahl; //Variable deklarieren
			zahl = 5; //Wert in eine Variable schreiben

            Console.WriteLine(zahl); //cw + Tab

			int zahlMalZwei = zahl * 2; //Zahl von oben wiederverwenden
            Console.WriteLine(zahlMalZwei);

			string wort = "Hallo"; //string: Text, doppelte Hochkomma
			char buchstabe = 'A'; //char: Einzelner Buchstabe, einzelne Hochkomma

			//Kommazahlen: double, float, decimal
			double kommazahl = 325.7582; //Kommazahl mit Punkt
			float floatZahl = 325.7582f; //Kommazahlen sind standardmäßig doubles, konvertieren mit F am Ende
			decimal decimalZahl = 325.7582m; //Kommazahlen sind standardmäßig doubles, konvertieren mit M am Ende

			//bool: Wahr-/Falschwert (true oder false)
			bool b = true;
			b = false;
			#endregion

			#region Strings
			//Strings verbinden
			string kombi = "Das Wort ist: " + wort;
            Console.WriteLine(kombi);

			string kombination = "Das Wort ist: " + wort + ", die Zahl ist: " + zahl + ", der bool ist: " + b; //Anstrengend
            Console.WriteLine(kombination);

			//String Interpolation: Code in Strings einbinden, wird häufig verwendet um Strings zusammenzubauen
			string interpolation = $"Das Wort ist: {wort}, die Zahl ist: {zahl}, der bool ist: {b}"; //Dollarzeichen vor String
            Console.WriteLine(interpolation);

			//Escape-Sequenzen: Gibt die Möglichkeit besondere Zeichen in den String einzubauen
			//\n: Zeilenumbruch, \t: Tab
			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			Console.WriteLine("Umbruch\n\tUmbruch");

            Console.WriteLine("Backslash \\"); //Zwei Backslashes werden zu einem Backslash

			//Verbatim-String: Ignoriert Escape-Sequenzen, nützlich bei Pfaden
			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_05_09";
			#endregion

			#region Eingabe
			////Console.ReadLine(): Eingabe vom Benutzer über die Konsole lesen
			//string eingabe = Console.ReadLine(); //Eingabe wird in die Variable geschrieben
			//Console.WriteLine($"Deine Eingabe ist: {eingabe}");

			////Parse: String in einen anderen Typen umwandeln
			//int eingabeZahl = int.Parse(eingabe); //Eingabe zu int umwandeln
			//double eingabeDouble = double.Parse(eingabe);

			////Console.ReadKey(): Einzelnes Zeichen abfragen
			//char c = Console.ReadKey().KeyChar; //Gedrücktes Zeichen in die char Variable schreiben
			#endregion

			#region Konvertierung
			string s = zahl.ToString(); //Beliebige Typen zu String konvertieren

			//Casting, Typecasting, Cast: Einen Typen in einen anderen Typen umwandeln
			double d = 52354.32957239;
			int i = (int) d; //Nicht direkt möglich, Umwandlung erzwingen
			double di = i;

			long l = 932579237598237589;
			int li = (int) l; //long ist zu groß für int -> Umwandlung erzwingen
			#endregion

			#region Arithmetik
			int z1 = 5;
			int z2 = 8;

            Console.WriteLine(z1 + z2); //Nur das Ergebnis der Addition kommt hier heraus, originale Zahlen werden nicht verändert
            Console.WriteLine(z2 % z1); //Modulo: Rest der Division, 8/5=1, 3R

			z1 = z1 + z2; //Ergebnis von z1 + z2 in z1 schreiben
			z1 += z2; //Selbiges wie oben nur kürzer

			z1++; //Erhöhe die Zahl um 1 und schreibe das Ergebnis direkt in die Variable
			z1--; //Verringere die Zahl um 1 und schreibe das Ergebnis direkt in die Variable

			double z3 = 48753.3285672378957;
			//Rundungsfunktionen: Floor, Ceiling, Round
			Math.Floor(z3); //Originale Zahl wird nicht verändert
			Math.Ceiling(z3); //Originale Zahl wird nicht verändert
			Math.Round(z3); //Round: Auf- oder Abrunden, rundet bei .5 zur nächsten geraden Zahl
			Math.Round(4.5); //4
			Math.Round(5.5); //6

			double zweiKomma = Math.Round(z3, 2); //Auf X Kommastellen runden
            Console.WriteLine(zweiKomma);

            Console.WriteLine(8 / 5); //Int-Division, da zwei Ints als Argumente (Ergebnis 1 statt 1.6)
            Console.WriteLine(8.0 / 5); //Kommadivision erzwingen, wenn eine der beiden Zahlen eine Kommazahl ist
            Console.WriteLine(8d / 5);
            Console.WriteLine(8f / 5);
            Console.WriteLine((double) z1 / z2); //z1 temporär zu einem Double umwandeln
            #endregion
        }
	}
}