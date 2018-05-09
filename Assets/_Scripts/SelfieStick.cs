using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

	public float panSpeed = 10f;
	public float maxCamVertAngle = 315f;
	public float minCamVertAngle = 250f;

	private GameObject targetPlayer;
	private Vector3 armAngles;


	// Use this for initialization
	void Start () {
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");
		armAngles = this.transform.rotation.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
		float camHoriz = CrossPlatformInputManager.GetAxis("CamHoriz"); //mapped to Steam Controller triggers - 4th axis.
		float camVert = CrossPlatformInputManager.GetAxis("CamVert"); //mapped to Steam Controller triggers - 5th axis.

		armAngles.y += camHoriz * panSpeed;
		armAngles.z += camVert * panSpeed;
		armAngles.z = Mathf.Clamp (armAngles.z, minCamVertAngle, maxCamVertAngle);

		this.transform.rotation = Quaternion.Euler (armAngles);
		this.transform.position = targetPlayer.transform.position;
	}
}
