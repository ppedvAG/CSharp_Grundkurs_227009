using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Test Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//Streams();

		//NewtonsoftJson();

		//SystemJson();

		//Xml();
	}

	static void Streams()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Test Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Flush(); //Stream in das File schreiben
		sw.Close(); //Wichtig: schließen

		using (StreamWriter sw2 = new StreamWriter(filePath)) //using-Block: schließt den unterliegenden Stream nach Ende des Blocks automatisch
		{
			sw2.WriteLine("Test4");
			sw2.WriteLine("Test5");
			sw2.WriteLine("Test6");
		} //Stream wird hier automatisch geschlossen

		using StreamReader sr = new StreamReader(filePath); //using-Statement: schließst das File am Ende der Methode automatisch
		sr.ReadToEnd().Split(Environment.NewLine); //Jede Zeile im File ist ein Element im Array

		List<string> lines = new();
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine());

		//Schnelle Methoden
		File.WriteAllText(filePath, "Test123");
		File.WriteAllLines(filePath, lines);

		string read = File.ReadAllText(filePath);
		string[] readLines = File.ReadAllLines(filePath);
	}

	static void NewtonsoftJson()
	{

		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Test Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

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

		//JsonSerializerSettings settings = new();
		//settings.Formatting = Formatting.Indented;
		//settings.TypeNameHandling = TypeNameHandling.Objects;

		//string json = JsonConvert.SerializeObject(fahrzeuge, settings);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson, settings);
	}

	static void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Test Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//Streams();

		//NewtonsoftJson();

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

		JsonSerializerOptions settings = new();
		settings.WriteIndented = true;

		string json = JsonSerializer.Serialize(fahrzeuge, settings);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson, settings);
	}

	static void Xml()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Test Ordner

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zum File

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

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

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new StreamWriter(filePath))
			xml.Serialize(sw.BaseStream, fahrzeuge);

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> readFzg = xml.Deserialize(sr.BaseStream) as List<Fahrzeug>;
		}
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

    public Fahrzeug()
    {
        
    }
}

public enum FahrzeugMarke { Audi, BMW, VW }