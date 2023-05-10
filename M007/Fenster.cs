namespace M007
{ 
	/// <summary>
	/// Bauplan für Fenster Objekte, hier wird nur definiert wie ein Fenster aussieht
	/// </summary>
	internal class Fenster
	{
		#region Variable
		private double laenge;

		/// <summary>
		/// Gibt die Länge des Fensters zurück.</br>
		/// Get-Methoden geben das Feld dahinter zurück, und haben generell keine Parameter.
		/// </summary>
		/// <returns>Die Länge des Fensters in Meter.</returns>
		public double GetLaenge()
		{
			return laenge;
		}

		/// <summary>
		/// Setzt die Länge des Fensters auf einen neuen Wert. </br>
		/// Set-Methoden sind generell void und haben genau einen Parameter.
		/// </summary>
		/// <param name="neueLaenge"></param>
		public void SetLaenge(double neueLaenge)
		{
			if (neueLaenge > 0 && neueLaenge < 10) //Überprüfung machen bevor der Wert gesetzt wird (Sicherheit)
			{
				laenge = neueLaenge; //Neuer Wert wird hier gesetzt
			}
			else
			{
                Console.WriteLine("Neue Länge muss zwischen 0 und 10 Meter sein");
            }
		}
		#endregion

		#region Properties
		private double breite;

		public double Breite
		{
			get //Äquivalent zu GetLaenge
			{
				return breite;
			}
			set //Äquivalent zu SetLaenge
			{
				if (value > 0 && value < 5) //value: Äquivalent zu neueLaenge bei SetLaenge
				{
					breite = value;
				}
				else
				{
					Console.WriteLine("Neue Breite muss zwischen 0 und 5 Meter sein");
				}
			}
		}

		//Get-Only Property
		public double Area
		{
			get
			{
				return laenge * breite;
			}
			//set weglassen, macht wenig Sinn für eine Fläche
		}

		private FensterStatus status = FensterStatus.Geschlossen;

		public FensterStatus Status
		{
			get
			{
				return status;
			}
			private set //private set: von außen nicht angreifbar
			{
				status = value;
			}
		}

		/// <summary>
		/// Benutzer die Möglichkeit geben das Fenster zu öffnen ohne auf das Property zuzugreifen
		/// </summary>
		public void FensterOeffnen()
		{
			if (status != FensterStatus.Offen)
			{
				Status = FensterStatus.Offen;
			}
			else
			{
                Console.WriteLine("Fenster ist bereits geöffnet");
            }
		}
        #endregion

        #region Konstruktor
        public Fenster() 
		{
			Zaehler++;
		}

        /// <summary>
        /// Konstruktor: Code der bei Erstellung des Objekts ausgeführt wird
        /// </summary>
        public Fenster(double laenge, double breite) : this()
		{
			//SetLaenge(laenge);
			//Breite = breite;
			this.laenge = laenge; //this: Greife auf das Feld außerhalb vom Konstruktor zu (hier laenge von oben)
			this.breite = breite;
        }

		/// <summary>
		/// Konstruktoren verketten: mit this(...) mehrere Konstruktoren aneinanderhängen, um Redundanz zu sparen</br>
		/// Kette kann beliebig viele Konstruktoren enthalten
		/// </summary>
		public Fenster(double laenge, double breite, FensterStatus status) : this(laenge, breite)
		{
			this.status = status;
		}
		#endregion

		~Fenster()
		{
            Console.WriteLine($"Fenster eingesammelt {GetHashCode()}");
			//GetHashCode(): Zeigt die Speicheradresse
        }

		public static int Zaehler;
	}

	enum FensterStatus
	{
		Geschlossen,
		Gekippt,
		Offen
	}
}
