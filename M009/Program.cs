namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("", 0); //Variablentyp Mensch, kann alle Objekte vom Typ Mensch halten oder einer Unterklasse von Mensch

		Lebewesen l = new Mensch("", 0); //Variablentyp Lebewesen, kann alle Objekte vom Typ Lebewesen halten oder einer Unterklasse von Lebewesen

		object o = new Mensch("", 0); //Variablentyp Object, kann alle Objekte halten
		o = 123; //int
		o = "123"; //string
		o = false; //bool

		//l = new Hund("");
		m = (Mensch) l; //kompatibel mit Mensch weil ein Mensch Objekt an Lebewesen hängt
		//m = (Mensch) o; //Funktioniert nur wenn ein Mensch an o hängt
		l = m; //Immer möglich, da in m nur Objekte passen die auch in l passen würden

        //GetType(): gibt den Typen des derzeitigen Objekts zurück, anhand eines Varialennamens
        Console.WriteLine(m.GetType()); //M009.Mensch
        Console.WriteLine(l.GetType()); //M009.Mensch
		Console.WriteLine(o.GetType()); //System.Boolean

		//typeof(<Klassenname>): generiert ein Type-Objekt anhand eines Typ Namens
		Type gt = m.GetType(); //Bei Variablen
		Type type = typeof(Mensch); //keine Variable

		#region Exakter Typvergleich
		if (m.GetType() == typeof(Mensch)) //Hängt an m ein Mensch dran?
		{
			//true
		}

		if (l.GetType() == typeof(Mensch)) //Hängt an l ein Mensch dran?
		{
			//true
		}

		if (l.GetType() == typeof(Hund)) //Hängt an l ein Hund dran?
		{
			//false
		}
		#endregion

		#region Vererbungshiearchie Typvergleich
		if (m is Mensch) //Hängt an m ein Mensch oder eine Unterklasse von Mensch dran?
		{
			//true
		}

		if (l is Mensch) //Hängt an l ein Mensch oder eine Unterklasse von Mensch dran?
		{
			//true
		}
		#endregion


		Lebewesen[] leb = new Lebewesen[2]; //Array das verschiedene Lebewesen halten kann
		leb[0] = new Mensch("", 0);
		leb[1] = new Hund("");
		//leb[2] = new Lebewesen("");

		foreach (Lebewesen lebewesen in leb)
		{
			if (lebewesen.GetType() == typeof(Mensch))
			{
				//Hier habe ich einen Menschen zu 100%
				Mensch mensch = (Mensch) lebewesen;
                Console.WriteLine($"Der Mensch ist {mensch.Alter} Jahre alt");
            }

			if (lebewesen is Hund h) //Schneller Cast bei is-Typvergleich
			{
				//Hund h = (Hund) lebewesen; //Zeile wird gespart durch schnellen Cast
				//h.Bellen();
			}

			Console.WriteLine(lebewesen.ToString());
        }
	}
}

/// <summary>
/// abstract: Gibt eine Strukturklasse vor
/// </summary>
public abstract class Lebewesen
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	/// <summary>
	/// Abstrakte Methoden haben keinen Body, und müssen in den Unterklasse implementiert werden
	/// </summary>
	public abstract void Bewegen(int distanz);

	public override string ToString()
	{
		return $"Der Typ dieses Objekts ist {GetType().Name}"; //GetType().Name ist abhängig von dem eigentlichen Typ des Objekts
	}
}

public class Mensch : Lebewesen
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name)
	{
		Alter = alter;
	}

	/// <summary>
	/// Implementation erzwungen
	/// </summary>
	public override void Bewegen(int distanz)
	{
        Console.WriteLine($"Der Mensch bewegt sich {distanz}m");
    }
}

public class Hund : Lebewesen
{
	public Hund(string name) : base(name)
	{
	}

	public void Bellen()
	{
        Console.WriteLine("Wuff");
    }

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Der Hund bewegt sich {distanz}m");
	}
}