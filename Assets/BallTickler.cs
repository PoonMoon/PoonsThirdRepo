using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BallTickler : MonoBehaviour {


	public float keyRepeatTime = 1f;

	private bool repeaterClear = true;


	
	// Update is called once per frame
	void Update () {

		bool fire = CrossPlatformInputManager.GetButton("fire");


		if (fire && repeaterClear ==true){
			Debug.Log ("Cross plat Input manager KEYDOWN " + fire);
			repeaterClear = false;
			Invoke ("ResetRepeater",keyRepeatTime);
		}

		if (CrossPlatformInputManager.GetButtonUp("fire"))
		{
			repeaterClear =true;
		}
	}


	private void ResetRepeater(){
		
		repeaterClear = true;
		//poop

	}

}
