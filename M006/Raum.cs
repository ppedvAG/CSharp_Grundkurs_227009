using M006.Bauteil; //per using Namespaces/Klassen importieren

namespace M006
{
	internal class Raum
	{
		public Fenster[] Fensters { get; set; }
		
		public Tuer Tuere { get; set; }

		public double Laenge, Breite, Hoehe;
	}
}
