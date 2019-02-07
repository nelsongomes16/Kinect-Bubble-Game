using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NovoJogo : MonoBehaviour {

	// Use this for initialization
		public void CarregarFase1(){
			SceneManager.LoadScene ("MainScene");
		}

		public void Sair(){
		Debug.Log ("quit button a funcionar!");
		Application.Quit();
		}
	}
