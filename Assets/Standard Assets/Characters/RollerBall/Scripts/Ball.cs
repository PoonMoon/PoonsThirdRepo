using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    

	public class Ball : MonoBehaviour
    {
		[SerializeField] private float moveForce = 5; 					// The force added to the ball to move it.
		public bool ballTorqueOn = true; 								// Whether or not to use torque to move the ball.
		public float xAnaloguePosition;  					// The maximum velocity the ball can rotate at.
		public float topSpeed;  
		public Vector3 velocityVector;
		public float groundedRayLength = 1f;  							// The length of the ray to check if the ball is grounded.

		private Rigidbody myBall;

		public float maxVelTweak = 1f;
		public float currentVelocity;
		public enum xDirection {LEFT,RIGHT,NONE};
		public xDirection myXdirection;
		public float jumpPower = 2f;  									// The force added to the ball when it jumps.
		public float fallMulitplier = 2.5f;  							//gives a stronger fall, Mario esq rather than true physics
		public float shortJumpingMultiplier =  2.0f; 
		public bool ballJump =false;
		public float rayDepth = 0.1f;

		private void Start()

        {
            myBall = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
			myBall.maxAngularVelocity = topSpeed;
			//myBall. = topSpeed;
			xAnaloguePosition = CrossPlatformInputManager.GetAxis ("Horizontal");
			myXdirection = xDirection.NONE;

        }//end Start


		private bool Grounded(){
			RaycastHit underTheBall;
			Ray lookDownRay = new Ray (this.transform.position, Vector2.down);
			if (Physics.Raycast (lookDownRay, out underTheBall, rayDepth)) {

				//Debug.Log ("RAAAAYYYY HIT");
				return true;
			} else {

				return false;
			}
		}



        public void Move(Vector3 moveDirection, bool jump)
        {





			//are we on the ground?
			if (Grounded ()) {
				//if we are on the ground allow a jump request from BallUserControl
				ballJump = jump;
			} else {
				//we are in the air so ignore the request and let Ball deal with jump mechanic
				ballJump = false;
			}

			xAnaloguePosition = CrossPlatformInputManager.GetAxis ("Horizontal") ;  //top speed is set by the position of the stick unless its max then use topSpeed
			currentVelocity = myBall.velocity.z;
			//Debug.Log ("Ang Vel " + myBall.angularVelocity);
			//Debug.Log (" Vel " + myBall.velocity);
			if (xAnaloguePosition < 0) {
				myXdirection = xDirection.LEFT;
			} else if (xAnaloguePosition > 0) {
				myXdirection = xDirection.RIGHT;
			} else {
				myXdirection = xDirection.NONE;
			}//end if on Direction

			//can we accelerate?
		
			if (CanWeAccelerate()) {

				// If using torque to rotate the ball...
				if (ballTorqueOn) {
					// ... add torque around the axis defined by the move direction.
					myBall.AddTorque (new Vector3 (moveDirection.z, 0, -moveDirection.x) * moveForce);
				} else {
					// Otherwise add force in the move direction.
					myBall.AddForce (moveDirection * moveForce);
				}//end if on ball torque bool


			} //end if on myXdirection


			if (ballJump) {
				//jump
				myBall.AddForce(Vector3.up*jumpPower);
	
				if (myBall.velocity.y < 0) { //if we have reached the apex or ar falling...
					myBall.velocity += Vector3.up * Physics.gravity.y * (fallMulitplier - 1) * (Time.deltaTime); // the minus one means then that the multiplier is a 2x / 2.5 x as we already have 1 gravirty
				} 

//				else if (myBall.velocity.y > 0 && !CrossPlatformInputManager.GetButton ("Jump")) {
//					myBall.velocity += Vector3.up * Physics.gravity.y * (shortJumpingMultiplier - 1) * (Time.deltaTime);
//				}
			}//end if jump


		} //end Move Method


		private bool CanWeAccelerate(){

			//works out if we are allowed to keep adding force.  Its a no if the stick's position is not 
			//full left or right given the speed, but if we have full left or right (-1 or 1) then allow the top speed to be set by topSpeed

			if (xAnaloguePosition == 1 || xAnaloguePosition == -1) 
			{
				return true;
			}
			else if (myXdirection == xDirection.LEFT && currentVelocity > xAnaloguePosition || myXdirection == xDirection.RIGHT && currentVelocity < xAnaloguePosition) 
			{
				return true;
			} 
			else 
			{
				return false;
			}  
		}//end CanWeAccel Method





		void OnCollisionEnter(Collision hitObject){
			//Debug.Log ("HIT!  Ball collided with " + hitObject.gameObject.name);
			
		}




    }//end Ball CLASS






}//end Namespace
