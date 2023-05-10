namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 12);
        Console.WriteLine(m.Name); //Name wird weitergegeben
        m.WasBinIch(); //WasBinIch wird weitergegeben

		Kind k = new Kind("Max", 12);
        Console.WriteLine(k.Name); //Name wird weitergegeben
		Console.WriteLine(k.Alter); //Alter wird weitergegeben

		Console.WriteLine(m.ToString()); //M008.Mensch
    }
}

public class Lebewesen //Basisklasse
{
	public string Name { get; set; }

    public Lebewesen(string name)
    {
		Name = name;
    }

	/// <summary>
	/// virtual: Methode kann in Unterklassen überschrieben werden (normalerweise können Methoden nicht überschrieben werden)
	/// </summary>
    public virtual void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Lebewesen");
    }

	public override string ToString()
	{
		return $"Ich bin ein {base.ToString()} und mein Name ist {Name}";
	}
}

public class Mensch : Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Konstruktor von oben muss mit base(...) verkettet werden
	{ //hier bei Parametern einfach alter hinzufügen
		Alter = alter;
	}

	/// <summary>
	/// Spezifische Implementation in der Mensch Klasse für WasBinIch()
	/// </summary>
	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Mensch");
		base.WasBinIch(); //base: selbiges wie this, nur im Vererbungskontext (ruft die Methode in der Oberklasse auf)
    }

	public override sealed string ToString()
	{
		return base.ToString() + $" und bin {Alter} Jahre alt";
	}
}

public sealed class Kind : Mensch //sealed: Kann nicht weitervererben
{
	public Kind(string name, int alter) : base(name, alter)
	{

	}

	//public override string ToString()
	//{
	//	return base.ToString();
	//}
}