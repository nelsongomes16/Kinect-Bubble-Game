using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleManager : MonoBehaviour {

	[SerializeField]
	GameObject mBubblePrefab;

	public float spawningTime= 2.0f;

	private List<Bubble> mAllBubbles = new List<Bubble>();
	//private Bubble mAllBubbles = new Bubble();
	private Vector2 mBottomLeft = Vector2.zero;
	private Vector2 mTopRight = Vector2.zero;

	private void Awake () {
		//Bounding values
		Debug.Log(spawningTime);
		mBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
		mTopRight = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight / 2, Camera.main.farClipPlane));
	}

	private void OnEnable () {
		Start();
	}

	private void OnDisable () {
		GameObject[] gameobjArray = GameObject.FindGameObjectsWithTag ("Bubble");
		foreach (GameObject go in gameobjArray) {
			go.SetActive(false);
		}
	}
				
	private void Start () {
		StartCoroutine (CreateBubbles());
	}

	private void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, Camera.main.farClipPlane)), 0.5f);
		Gizmos.DrawSphere (Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight, Camera.main.farClipPlane)), 0.5f);
	}

	public Vector3 GetPlanePosition()
	{
		//posições aletórias
		float targetX = Random.Range(mBottomLeft.x/60, mTopRight.x/60);
		float targetY = Random.Range (mBottomLeft.y/60, mTopRight.y/60);

		return new Vector3 (targetX, targetY, 0);
	}

	private IEnumerator CreateBubbles()
	{
		//transform.position = GetPlanePosition ();
		//transform.rotation = Quaternion.identity;

		while (mAllBubbles.Count < 10) {
			
			//criar novas bolhas
			//GameObject newBubbleObject = Instantiate(mBubblePrefab, GetPlanePosition(), Quaternion.identity, transform);
			//float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0,0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
			//float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
			//Vector2 rand_pos = new Vector2 (spawnX, spawnY);
			//Vector2 rand_pos = new Vector2(Random.Range (0,10), Random.Range(xMin,xMax));
			//Vector2 random_pos = Camera.main.ViewportToWorldPoint(new Vector2 (Random.value, Random.value));	
			GameObject newBubbleObject = Instantiate(mBubblePrefab);
			newBubbleObject.transform.position = GetPlanePosition();
			//GameObject newBubbleObject = Instantiate(mBubblePrefab, transform.position, transform.rotation);
			//newBubbleObject = Instantiate(mBubblePrefab, transform.position, transform.rotation) as GameObject;
			//GameObject newBubbleObject = Instantiate(mBubblePrefab, GetPlanePosition(), Quaternion.identity);
			Bubble newBubble = newBubbleObject.GetComponent<Bubble> ();

			//setup bubble
			newBubble.mBubbleManager = this;
			mAllBubbles.Add(newBubble);

			yield return new WaitForSeconds (spawningTime);
		}
	}
}
