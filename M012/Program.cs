using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Enumerable.Range: Erzeugt eine Liste von <Start> mit <Anzahl> Elementen
		List<int> ints = Enumerable.Range(1, 20).ToList(); //Liste von 1-20

        Console.WriteLine(ints.Average());
        Console.WriteLine(ints.Sum());
        Console.WriteLine(ints.Min());
        Console.WriteLine(ints.Max());

        Console.WriteLine(ints.First()); //Gibt das erste Element zurück, gibt einen Fehler wenn es kein Element gibt
        Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element zurück, gibt den Standardwert wenn es kein Element gibt

		Console.WriteLine(ints.Last()); //Gibt das letzte Element zurück, gibt einen Fehler wenn es kein Element gibt
		Console.WriteLine(ints.LastOrDefault()); //Gibt das erste letzte zurück, gibt den Standardwert wenn es kein Element gibt

		//ints.First(e => e % 50 == 0); //Fehler
		ints.FirstOrDefault(e => e % 50 == 0); //0
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq-Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Lambda
		//Alle Fahrzeuge finden, die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs finden die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 200);

		//Autos nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Originale Liste wird nicht verändert
		fahrzeuge.OrderByDescending(e => e.Marke);

		//Autos nach Marke sortieren und danach nach MaxV
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Alle Marken in der Liste finden
		List<FahrzeugMarke> marken = fahrzeuge.Select(e => e.Marke).ToList();
		IEnumerable<FahrzeugMarke> markenEindeutig = marken.Distinct(); //Duplikate entfernen
		
		//Linq Funktion verketten
		fahrzeuge
			.Select(e => e.Marke)
			.Distinct()
			.Order();

		fahrzeuge.Select(e => e.MaxV); //Liste von Geschwindigkeiten

		//Fahren alle meine Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200); //false

		//Fährt mindestens ein Fahrzeug 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200); //true

		//Enthält die Liste Elemente?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele Audis haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi); //4

		//Was ist die Durchschnittsgeschwindigkeit von unseren Fahrzeugen?
		fahrzeuge.Average(e => e.MaxV);
		//fahrzeuge.Select(e => e.MaxV).Average();

		//Was ist die Summe der Geschwindigkeiten?
		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit: int
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit: Fahrzeug

		fahrzeuge.Max(e => e.MaxV); //Die größte Geschwindigkeit: int
		fahrzeuge.MaxBy(e => e.MaxV); //Das Fahrzeug mit der größten Geschwindigkeit: Fahrzeug

		//Teilt die Liste in X große Arrays auf (Nützlich bei z.B. Webshop)
		fahrzeuge.Chunk(5);

		//Nimmt eine Teilmenge der Liste, überspringe 2 Elemente, nimm die nächsten 5 Elemente
		fahrzeuge.Skip(2).Take(5);

		//Finde die 3 schnellsten Fahrzeuge
		fahrzeuge.OrderByDescending(e => e.MaxV).Take(3);

		//Die Durchschnittsgeschwindigkeit aller VWs
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Average(e => e.MaxV);
		#endregion

		#region Erweiterungsmethoden
		int x = 3257;
		x.Quersumme();
        Console.WriteLine(74298.Quersumme());

		fahrzeuge.Shuffle();

		Dictionary<string, int> dict = new();
		dict.Shuffle(); //Dictionary ist auch IEnumerable -> hat auch Shuffle Funktion
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}