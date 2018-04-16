using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class BallTickler : MonoBehaviour {


	public float keyRepeatTime = 1f;

	public bool repeaterClear = true;


	
	// Update is called once per frame
	void Update () {


		print (CrossPlatformInputManager.GetAxis("Horizontal"));

		bool fire = CrossPlatformInputManager.GetButton("Fire");


		if (fire && repeaterClear ==true){
			Debug.Log ("Cross plat Input manager KEYDOWN " + fire);
			repeaterClear = false;
			Invoke ("ResetRepeater",keyRepeatTime);
		}

		if (CrossPlatformInputManager.GetButtonUp("Fire"))
		{
			repeaterClear =true;
		}
	}


	private void ResetRepeater(){
		
		repeaterClear = true;
		//poop a lot

	}

}
