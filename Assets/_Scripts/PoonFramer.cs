using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoonFramer : MonoBehaviour {

	public float time;
	public Vector3 position;
	public Quaternion rotation;


	public PoonFramer (float pTime, Vector3 pPosition, Quaternion pRotation){

		time = pTime;
		position = pPosition;
		rotation = pRotation;

	}

}
