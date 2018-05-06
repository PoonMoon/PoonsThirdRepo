using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BallTickler : MonoBehaviour {


	public float keyRepeatTime = 1f;

	public bool repeaterClear = true;


	
	// Update is called once per frame
	void Update () {


		print (CrossPlatformInputManager.GetAxis("Horizontal"));

		bool jump = CrossPlatformInputManager.GetButton("Jump");


		if (jump && repeaterClear ==true){
			Debug.Log ("Cross plat Input manager KEYDOWN " + jump);
			repeaterClear = false;
			Invoke ("ResetRepeater",keyRepeatTime);
		}

		if (CrossPlatformInputManager.GetButtonUp("Jump"))
		{
			repeaterClear =true;
		}
	}


	private void ResetRepeater(){
		
		repeaterClear = true;
		//poop a lot

	}

}
