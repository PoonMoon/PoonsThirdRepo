using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour {

	private GameObject targetPlayer;

	//private Transform cameraTarget;

	// Use this for initialization
	void Start () {
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () {
		//cameraTarget = targetPlayer.transform.position;
		transform.LookAt (targetPlayer.transform);

	}
}
