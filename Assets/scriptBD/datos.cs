using SQLite4Unity3d;

public class datos {


	public string imagen { get; set; }
	public float latitud { get; set; }
	public float longitud { get; set; }
	public string tipo { get; set; }
	public string posicion { get; set; }
	public string rotacion { get; set; }
	public string escala { get; set; }
	public string colorR { get; set; }
	public string colorG{ get; set; }
	public string colorB { get; set; }
	public string colorA { get; set; }
	public string descripcion { get; set; }
	
	public override string ToString ()
	{
		return string.Format ("[datos: imagen={0}, latitud={1},  longitud={2}, tipo={3}, posicion={4}, rotacion={5},escala={6}, colorR{7}],colorG{8},colorB{9},colorA{10}, descripcion{11}", imagen, latitud, longitud, tipo, posicion, rotacion,escala,colorR,colorG,colorB,colorA,descripcion);
	}
}
