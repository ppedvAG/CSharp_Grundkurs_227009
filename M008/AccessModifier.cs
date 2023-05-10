namespace M008;

class AccessModifier //Klassen und Member ohne Modifier sind Internal
{
	public string Name { get; set; } //Kann überall gesehen werden (auch außerhalb vom Projekt)

	private int Alter { get; set; } //Kann nur in dieser Klasse gesehen werden

	internal string Wohnort { get; set; } //Kann überall gesehen werden (nur im Projekt)


	protected string Lieblingsfarbe { get; set; } //Nur in dieser Klasse und in Unterklasse (auch außerhalb vom Projekt)

	protected internal string Lieblingsnahrung { get; set; } //Kann überall im Projekt gesehen werden (internal) und in Unterklassen auch außerhalb vom Projekt

	protected private DateTime Geburtsdatum { get; set; } //Kann nur in dieser Klasse und in Unterklassen nur im Projekt gesehen werden
}