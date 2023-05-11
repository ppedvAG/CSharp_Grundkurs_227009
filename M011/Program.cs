namespace M011
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> list = new List<int>(); //Erstellung einer Liste mit Generic
			list.Add(1); //T wird ersetzt durch int
			list.Add(2); //T wird ersetzt durch int
			list.Add(3); //T wird ersetzt durch int

			list.Remove(2); //Ersetzt das erste gefundene Element
			list.RemoveAt(0); //Entfernt das Element an der Stelle

			List<string> strList = new List<string>();
			strList.Add("1"); //T wird ersetzt durch string

			Console.WriteLine(list[0]); //Angreifen 1:1 wie bei Array
			list[0] = 10; //Zuweisung wie bei Array

            Console.WriteLine(list.Count); //Count statt Length, nicht Count() benutzen

			list.Sort();

			foreach (int i in list)
			{
                Console.WriteLine(i);
            }

			if (list.Contains(1))
			{

			}

			list.Clear(); //Entleert die Liste

			///////////////////////////////////////////////////////////////////

			Stack<int> stack = new(); //new(): Ergänzt den Typ von rechts
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			stack.Push(4);

            Console.WriteLine(stack.Peek()); //Oberstes Element anschauen

            Console.WriteLine(stack.Pop()); //Oberstes Element anschauen und herunternehmen


			Queue<int> queue = new(); //new(): Ergänzt den Typ von rechts
			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);
			queue.Enqueue(4);

			Console.WriteLine(queue.Peek()); //Erstes Element anschauen

			Console.WriteLine(queue.Dequeue()); //Erstes Element anschauen und herunternehmen

			///////////////////////////////////////////////////////////////////

			Dictionary<string, int> einwohnerzahlen = new(); //Liste von KeyValue-Paaren, Keys müssen einzigartig sein
			einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter: Key = string, Value = int
			einwohnerzahlen.Add("Berlin", 3_650_000);
			einwohnerzahlen.Add("Paris", 2_160_000);
			//einwohnerzahlen.Add("Paris", 2_160_000); //ArgumentException

			if (!einwohnerzahlen.ContainsKey("Paris")) //Schauen ob der Key bereits existiert
			{

			}

			Console.WriteLine(einwohnerzahlen["Wien"]); //Elemente angreifen über den Key (wie bei Array)

			foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //var: Compiler ergänzt den Typen automatisch, Strg + . auf var -> expliziten Typen generieren
			{
                Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner."); //mit kv.Key und kv.Value die einzelnen Werte angreifen
            }

			List<string> staedte = einwohnerzahlen.Keys.ToList(); //Nur die Keys nehmen
			List<int> einwohner = einwohnerzahlen.Values.ToList(); //Nur die Values nehmen
		}
	}
}