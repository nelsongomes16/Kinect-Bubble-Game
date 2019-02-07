using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour {
	public BodySourceManager mBodySourceManager;
	public GameObject mJointObject;

	private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();

	private List<JointType> _joints = new List<JointType> {
		JointType.HandLeft,
		JointType.HandRight,
	};


	// Update is called once per frame
	void Update () 
	{
		#region Get Kinect data
		Body[] data = mBodySourceManager.GetData();
		if (data==null)
			return;

		List<ulong> trackedIds = new List<ulong>();
		foreach(var body in data)
		{
			if(body ==null)
				continue;
			if (body.IsTracked)
				trackedIds.Add(body.TrackingId);
		}
		#endregion

		#region Delete Kinect bodies
		List<ulong> knowIds = new List<ulong>(mBodies.Keys);
		foreach(ulong trackingId in knowIds)
		{
			if(!trackedIds.Contains(trackingId))
			{
				//DEstroi o body object
				Destroy(mBodies[trackingId]);
				// Remove from list
				mBodies.Remove(trackingId);
			}
		}
		#endregion

		#region Create Kinect bodies
		foreach(var body in data)
		{
			if(body == null)
				continue;

			if (body.IsTracked)
			{
				//Cria um body se ele nao for tracked
				if(!mBodies.ContainsKey(body.TrackingId))
					mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
				//Update positions
				UpdateBodyObject(body, mBodies[body.TrackingId]);
			}
		}
		#endregion
	}

	private GameObject CreateBodyObject(ulong id)
	{
		//create body parent
		GameObject body = new GameObject("Body:" + id);

		//create joints
		foreach (JointType joint in _joints)
		{
			//create object
			GameObject newJoint = Instantiate(mJointObject);
			newJoint.name = joint.ToString ();

			//parent to body
			newJoint.transform.parent = body.transform;
		}

		return body;
	}

	private void UpdateBodyObject(Body body, GameObject bodyObject)
	{
		//update joints
		foreach(JointType _joint in _joints)
		{
			//get new target position
			Joint sourceJoint = body.Joints[_joint];
			Vector3 targetPosition = GetVector3FromJoint (sourceJoint);
			targetPosition.z = 0;

			//get joint, set new position
			Transform jointObject = bodyObject.transform.Find(_joint.ToString());
			jointObject.position = targetPosition;
		}
	}

	private Vector3 GetVector3FromJoint(Joint joint)
	{
		return new Vector3 (joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
	}
}
