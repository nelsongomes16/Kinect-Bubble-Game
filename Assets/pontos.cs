using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pontos : MonoBehaviour {
	
	public static pontos instance;
	public int score = 0;
	public int total = 0;
	[SerializeField]
	Text pontosText;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		total = score;
		pontosText.text = "Pontuação: " + total.ToString();
	}
}
