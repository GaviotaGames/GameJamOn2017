using UnityEngine;
using System.Collections;

public class ScorePersistente : MonoBehaviour {

	//Referencia estatica a la clase
	private static ScorePersistente _instance;
	//Podemos coger la referencia pero no modificarla
	public static ScorePersistente Instance{ get; private set;}
	//El score que tiene el personaje
	float Score = 0f;
	string Name = "JHB";

	// Use this for initialization
	void Start () {
		//Comprobamos si existe una instancia, en caso que exista, vemos si 
		//es este objeto, sino destruimos el objeto
		if (Instance != null && Instance != this) {
			Destroy (gameObject);
		} else {
			//No existe instancia
			//Guardamos nuestra referencia
			Instance = this;
			//Le decimos a unity que no destruya el objeto entre escenas
			DontDestroyOnLoad(gameObject);

		}

	}

	//Pedimos el Score que le queda al personaje
	public float getPlayerScore(){
		return Score;
	}
	//Modificamos el Score que le queda al personaje
	public void setPlayerScore(float newScore){
		Score = newScore;
	} 
	public string getPlayerName(){
		return Name;
	}
	public void setPlayerName(string newName){
		Name = newName;
	} 
}