using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		Mensch m = new Mensch();
		m.Job = "Softwareentwickler";
		m.Gehalt = 5000;

		//m.Lohnauszahlung();
        Console.WriteLine(m.Jahresgehalt());
        Console.WriteLine(m.LohnProStunde(m.Gehalt));

		IArbeit arbeit = m; //IArbeit Variable wie bei Vererbung (siehe Fahrzeug)
		arbeit.Lohnauszahlung(); //IArbeit Methode auswählen

		ITeilzeitArbeit ta = m;
		ta.Lohnauszahlung(); //ITeilzeitArbeit Methode auswählen

		//IEnumerable: Basisinterface von allen Listen in C#
		List<int> e1 = new List<int>();
		int[] e2 = new int[10];
		IEnumerable<int> e3 = e1; //e1 und e2 hier kompatibel

		Test(e1);
		Test(e2);
		Test(e3);

		if (m is IArbeit) //Schauen ob das Objekt das Interface hat
		{

		}
    }

	static void Test<T>(IEnumerable<T> x) { }
}

public class Mensch : IArbeit, ITeilzeitArbeit
{
	public string Job { get; set; }

	public int Gehalt { get; set; }

	void IArbeit.Lohnauszahlung()
	{
        Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
    }

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt / 2}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche.");
	}

	public int Jahresgehalt()
	{
		return Gehalt * 12;
	}

	public double LohnProStunde(int lohn)
	{
		return lohn / (IArbeit.Wochenstunden * 4.0);
	}
}

/// <summary>
/// Interface: Definition von Funktionen und Properties, die in der entsprechenden Unterklasse implementiert werden müssen</br>
/// IArbeit: Gibt den Unterklassen die Möglichkeit zu arbeiten
/// </summary>
public interface IArbeit //Interfaces fangen per Konvention mit I an
{
	static readonly int Wochenstunden = 40;

	string Job { get; set; }

	int Gehalt { get; set; }

	void Lohnauszahlung();

	int Jahresgehalt();

	double LohnProStunde(int lohn);

	void Test()
	{
		//Bad Practice
    }
}

public interface ITeilzeitArbeit
{
	static readonly int Wochenstunden = 20;

	void Lohnauszahlung();

	int Jahresgehalt();

	double LohnProStunde(int lohn);
}