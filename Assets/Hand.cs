using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour {

	[SerializeField]
	AudioSource rebenta_bolha;

	public Transform mHandMesh;

	private void Update () 
	{
		mHandMesh.position = Vector3.Lerp (mHandMesh.position, transform.position, Time.deltaTime * 15.0f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag ("Bubble"))
			return;

		Bubble bubble = collision.gameObject.GetComponent<Bubble> ();
//		StartCoroutine (bubble.Pop ());
		collision.gameObject.SetActive (false);
		rebenta_bolha.Play ();
		pontos.instance.score += 1;
	}
}