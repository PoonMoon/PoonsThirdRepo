using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

	private GameObject targetPlayer;

	// Use this for initialization
	void Start () {
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = targetPlayer.transform.position;
	}
}
