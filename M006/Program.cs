using M006.Bauteil;

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		Fenster f = new Fenster(); //new: Objekt aus Bauplan erstellen ohne Standardwerte
		f.SetLaenge(5);
		f.Breite = 2;

		Fenster f2 = new Fenster();
		f2.SetLaenge(3);
		f2.Breite = 4;

        Console.WriteLine(f.Area);
        //f.Area = 3;

        Console.WriteLine(f.Status);
		//f.Status = FensterStatus.Offen;

		f.FensterOeffnen(); //Beide Objekte haben vom Bauplan auch die Methode bekommen
		f2.FensterOeffnen();

		Fenster f3 = new Fenster(3, 3, FensterStatus.Gekippt); //Standardwerte hier direkt setzen

		//Referenzen zwischen Objekten
		Raum r = new Raum();
		Tuer t = new Tuer();
		r.Tuere = t;
		r.Fensters = new Fenster[8];
		r.Fensters[0] = f;
		r.Fensters[1] = f2;
		r.Fensters[2] = f3;

		//Console, int, double -> System
		//File, Directory, Path -> System.IO
		//HttpClient --> System.Net.Http
    }
}