using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	private const int bufferSize = 1000;
	private MyKeyframe[] keyFrames = new MyKeyframe[bufferSize];
	private Rigidbody rsRigidBody;
	private GameManager rsGameManager;
	private int bufferOffset = 0; //used to offset the replay when we have not had a complete cycle
	private bool offsetSet = false;

	public bool rsRecording = true;

	// Use this for initialization
	void Start () {
		rsRigidBody = this.GetComponent<Rigidbody>();
		rsGameManager = FindObjectOfType<GameManager> ();

		
	}//end Start
	
	// Update is called once per frame
	void Update () {
		

		rsRecording = rsGameManager.RecordState ();
			//Debug.Log ("Recording - " + rsRecording);
		if (rsRecording) {
			Record ();
		} else {
			Playback ();
		}
	}//end update

	void Playback(){
		//frameNo = 700, need to go to 0. frame 1800 goto 800


		rsRigidBody.isKinematic = true;
		int frameNumber = Time.frameCount;

		int bufferFrameIndex = frameNumber % bufferSize; 
		//Mathf.Clamp (bufferFrameIndex, 1, bufferSize);
		Debug.Log ("PLAY: Frame count is " + frameNumber + " and frame index is " + bufferFrameIndex );

			if (frameNumber < bufferSize) {
			//we can not have filled a complete cycle yet so we need to skip forward to where we have playback data available
			//first run, set the offset
			if (!offsetSet) {
				bufferOffset = bufferFrameIndex-1; 
				offsetSet = true;
				}
			bufferFrameIndex -= bufferOffset;
			Debug.Log ("Frame index shifted to " +  bufferFrameIndex );
			}


		transform.position = keyFrames [bufferFrameIndex].kfPosition;
		transform.rotation = keyFrames [bufferFrameIndex].kfRotation;
		//Debug.Log ("PlayBack! " + bufferFrameIndex + " with pos of " + keyFrames [bufferFrameIndex].rsPosition.x);
		
	}//end PLayback Method

	void Record ()
	{
		rsRigidBody.isKinematic = false;
		offsetSet = false;
		bufferOffset = 0;

		int frameNumber = Time.frameCount % bufferSize;
		//print ("Recording FrameBuffer " + frameNumber);
		keyFrames [frameNumber] = new MyKeyframe (Time.time, transform.position, transform.rotation);
	}//end record method
}


public struct MyKeyframe {
	public float kfTime;
	public Vector3 kfPosition;
	public Quaternion kfRotation;

	public MyKeyframe(float time, Vector3 position, Quaternion rotation){
		kfTime = time;
		kfPosition = position;
		kfRotation = rotation;
	}
}

	public struct MyKeyframeRestorePoint {
		public float rpTime;
		public Vector3 rpPosition;
		public Quaternion rpRotation;

		public MyKeyframeRestorePoint(float time, Vector3 position, Quaternion rotation){
			rpTime = time;
			rpPosition = position;
			rpRotation = rotation;
		}

}


