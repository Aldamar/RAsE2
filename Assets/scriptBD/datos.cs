using SQLite4Unity3d;

public class datos {


	public string imagen { get; set; }
	public float latitud { get; set; }
	public float longitud { get; set; }
	public string tipo { get; set; }
	public string posicion { get; set; }
	public string rotacion { get; set; }
	public string escala { get; set; }
	
	public override string ToString ()
	{
		return string.Format ("[datos: imagen={0}, latitud={1},  longitud={2}, tipo={3}, posicion={4}, rotacion={5},escala={6}]", imagen, latitud, longitud, tipo, posicion, rotacion,escala);
	}
}
