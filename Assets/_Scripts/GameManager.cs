using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {



	private bool pauseIsOnToggle = false;
	private float startingFixedDeltaTime;

	public bool recording = true;

	// Use this for initialization
	void Start () {
		
		PlayerPrefsManager.GetLevelUnockedStatus (0);
		PlayerPrefsManager.SetUnlockLevel (0);
		startingFixedDeltaTime = Time.fixedDeltaTime;
	}//end start
	
	// Update is called once per frame
	void Update () {

		if (CrossPlatformInputManager.GetButtonDown ("Rec")) {
			
		} else {
			
		} //end gbd Rec


		if (CrossPlatformInputManager.GetButton ("Rec")) {
			recording = false;
		} else {
			recording = true;
		} //end rec if


		if (Input.GetKeyDown (KeyCode.P)){
			PauseGame ();

		}//end Pause



	}//end update


	public void PauseGame(){

		if (pauseIsOnToggle) {
			//game is already paused, so unpause bitch!
			Time.timeScale = 1;
			Time.fixedDeltaTime = 0; //pause the physics loops
			pauseIsOnToggle = false;
		} else {
			Time.timeScale = 0;
			Time.fixedDeltaTime = startingFixedDeltaTime; //restor to project settings.

			pauseIsOnToggle = true;
		}


	}

	public bool RecordState(){
		return recording;
	}//end RecordState

}
