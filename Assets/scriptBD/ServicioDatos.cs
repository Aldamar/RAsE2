using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class ServicioDatos {

	private SQLiteConnection _conexion;
	
	public ServicioDatos(string DatabaseName){
		
		#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);
		
		if (!File.Exists(filepath))
		{
			Debug.Log("Database not in Persistent path");
			// if it doesn't ->
			// open StreamingAssets directory and load the db ->
			
			#if UNITY_ANDROID 
			var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
			while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
			// then save to Application.persistentDataPath
			File.WriteAllBytes(filepath, loadDb.bytes);
			#elif UNITY_IOS
			var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			#elif UNITY_WP8
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			
			#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
			// then save to Application.persistentDataPath
			File.Copy(loadDb, filepath);
			#endif
			
			Debug.Log("Database written");
		}
		
		var dbPath = filepath;
		#endif
		_conexion = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		Debug.Log("Final PATH: " + dbPath);     

	}
	public void CrearBD(string img, string tip, float lat, float lon, string pos, string rot, string esc){
		//_conexion.DropTable<datos> ();
		_conexion.CreateTable<datos> ();
		_conexion.InsertAll (new [] {
			new datos {
				imagen = img,
				latitud = lat,
				longitud = lon,
				tipo = tip,
				posicion = pos,
				rotacion = rot,
				escala = esc
			}

		});
	}
	
		public IEnumerable<datos> ObtenerDato(){
			return _conexion.Table<datos>();
		}
	public datos crearDato(){
		var D = new datos{
			imagen = "coca",
			latitud = Input.location.lastData.latitude,
			longitud = Input.location.lastData.longitude ,
			tipo = "2d"
		};
		_conexion.Insert (D);
		return D;
	}
	public IEnumerable<datos> GetDatos(){
		return _conexion.Table<datos>();
	}
	public IEnumerable<datos> GetObject(float latitu, float longi){
		return _conexion.Table<datos>().Where(x => x.latitud == latitu && x.longitud == longi);
	}


}
