using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testeAlteracoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.T)) {
			GetComponent <BubbleManager>().enabled = false;
	}
}
}
