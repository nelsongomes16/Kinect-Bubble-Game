using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bubble : MonoBehaviour {
	//public Sprite mBubbleSprite;
	//public Sprite mPopSprite;
	[SerializeField]
	GameObject BubblePrefab;
	[HideInInspector]
	public BubbleManager mBubbleManager = null;
	public float velocidadeJogo = 0.9f;

	private Vector3 mMovementDirection = Vector3.zero;
	//private SpriteRenderer mSpriteRenderer = null;
	private Coroutine mCurrentChanger = null;

	private void OnEnable () {
		mCurrentChanger = StartCoroutine (DirectionChanger ());
	}

	private void OnDisable()
	{
		StopCoroutine (mCurrentChanger);
	}

	private void OnBecameInvisible()
	{
		//gameObject.SetActive (false);
		transform.position = mBubbleManager.GetPlanePosition();
		// Retorna ao Bubblemanager
	}


	// Update is called once per frame
	private void Update () {
		//Movement
		transform.position += mMovementDirection * Time.deltaTime * velocidadeJogo;
		//rotation
		transform.Rotate(Vector3.forward * Time.deltaTime * mMovementDirection.x * 20, Space.Self);
	}

//	public IEnumerator Pop()
//	{
//		mSpriteRenderer.sprite = mPopSprite;
//
//		StopCoroutine (mCurrentChanger);
//		mMovementDirection = Vector3.zero;
//
//		yield return new WaitForSeconds (0.5f);
//
//		transform.position = mBubbleManager.GetPlanePosition ();
//
//		mSpriteRenderer.sprite = mBubbleSprite;
//		mCurrentChanger = StartCoroutine (DirectionChanger ());
//	}

	private IEnumerator DirectionChanger()
	{
		while (gameObject.activeSelf) {
			//mMovementDirection = new Vector2 (Random.Range (0, 100) * 0.01f, Random.Range (0, 100) * 0.01f);
			mMovementDirection = new Vector2 (Random.Range (-100, 100) * 0.01f, Random.Range (0, 100) * 0.01f);

			yield return new WaitForSeconds (5.0f);
			//yield return new WaitForSeconds (3.0f);
		}
	}
}
