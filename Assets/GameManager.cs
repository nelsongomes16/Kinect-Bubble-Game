using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	[SerializeField]
	GameObject PR_BubbleManager;
	[SerializeField]
	GameObject CanvasPontos;
	[SerializeField]
	GameObject CanvasFimJogo;


	public Text timerText;
	public float InitialTime = 120;

	void OnEnable(){
		Debug.Log ("esta a ser chamada");
	}
	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		//float timeleft = 60.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//InitialTime -= Time.deltaTime;
		if(InitialTime <=0){
			timerText.text = "Acabou o tempo!";
			PR_BubbleManager.SetActive(false);
			//CanvasPontos.SetActive (false);
			CanvasFimJogo.SetActive (true);
		}
		else{
			CanvasFimJogo.SetActive (false);
			InitialTime -= Time.deltaTime;
			timerText.text = "Tempo restante: " + InitialTime.ToString ("f0") + " s";
			//print (InitialTime);
		}
	}
}
