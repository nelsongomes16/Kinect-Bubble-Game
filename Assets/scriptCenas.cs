using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptCenas : MonoBehaviour {
	[SerializeField]
	GameObject PR_BubbleManager;
	[SerializeField]
	GameObject CanvasPontos;
	[SerializeField]
	GameObject CanvasMenuPricipal;
	[SerializeField]
	GameObject CanvasFimJogo;

	public InputField Inputtempojogo;
	public InputField Inputspawningtime;
	public InputField Inputvelocidadejogo;
	public InputField Inputtamanhobolas;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.M)) {
			PR_BubbleManager.SetActive(false);
			CanvasPontos.SetActive (false);
			CanvasMenuPricipal.SetActive (true);
			//Destroy(gameObject.CompareTag("Bubble"));
//			changeWindModeSound.Play ();

			//ProjectileAddForce.instance.rigidbody.AddRelativeForce (Vector3.right * 250);
			//			wind.transform.position= new Vector3 (357, -5, 195);
			//			wind.transform.rotation= Quaternion.Euler(0,235,0);
		}
		if (Input.GetKey (KeyCode.J)) {
			PR_BubbleManager.SetActive (true);
			CanvasPontos.SetActive(true);
			CanvasMenuPricipal.SetActive (false);
			//CanvasPontos.active = true;
			//PR_BubbleManager.GetComponent<BubbleManager>().Start();
			//PR_BubbleManager.GetComponent<BubbleManager> ().spawningTime = 0.5f; //funciona
			//SceneManager.LoadScene ("MainScene");
	}
}
	public void CarregarNovoJogo(){
		SceneManager.LoadScene ("MainScene");
//		PR_BubbleManager.SetActive (true);
//		CanvasPontos.SetActive(true);
		CanvasMenuPricipal.SetActive (false);
	}

	public void Sair(){
		Debug.Log ("quit button a funcionar!");
		Application.Quit();
	}

	public void CarregarNovoJogo2(){
//		PR_BubbleManager.SetActive (true);
//		CanvasPontos.SetActive(true);
		SceneManager.LoadScene ("MainScene");
		CanvasFimJogo.SetActive (false);
	}
	public void CarregarMenuPrincipal(){
		//PR_BubbleManager.SetActive (true);
		CanvasPontos.SetActive(false);
		CanvasFimJogo.SetActive (false);
	}

	public void JogoNovasDefinições(){
		int tempojogo = int.Parse(Inputtempojogo.text);
		float spawningtime = float.Parse (Inputspawningtime.text);
		float velocidadejogo = float.Parse (Inputvelocidadejogo.text);
		float tamanhobolas = float.Parse (Inputtamanhobolas.text);

		PR_BubbleManager.SetActive (true);
		CanvasPontos.SetActive(true);
		GameObject.Find ("PR_BubbleManager").GetComponent<BubbleManager> ().spawningTime = spawningtime; //funciona
		GameObject.FindGameObjectWithTag("TempoRestante").GetComponent<GameManager>().InitialTime = tempojogo; // funciona
		GameObject.FindGameObjectWithTag("Pontuacao").GetComponent<pontos>().score = 0;
		GameObject.FindGameObjectWithTag("Pontuacao").GetComponent<pontos>().total = 0;
		//GameObject.FindGameObjectWithTag("Bubble").GetComponent<Bubble>().velocidadeJogo = velocidadejogo; //funciona

		GameObject[] GOs = GameObject.FindGameObjectsWithTag ("Bubble");
		for(int i=0;i<GOs.Length;i++){
			
		GOs[i].GetComponent<Transform>().localScale = new Vector3(tamanhobolas,tamanhobolas,tamanhobolas); //funciona
		GOs[i].GetComponent<Bubble>().velocidadeJogo = velocidadejogo;
		}
		//CanvasConfigs.SetActive (false);
		//total e pontos=0;
	}
}