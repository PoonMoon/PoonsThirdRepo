using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
		[SerializeField] private float moveForce = 5; // The force added to the ball to move it.
		[SerializeField] private bool ballTorqueOn = true; // Whether or not to use torque to move the ball.
		[SerializeField] private float maxVelocity = 25; // The maximum velocity the ball can rotate at.
		[SerializeField] private float jumpPower = 2; // The force added to the ball when it jumps.

		public float groundedRayLength = 1f; // The length of the ray to check if the ball is grounded.
		private Rigidbody myBall;


        private void Start()
        {
            myBall = GetComponent<Rigidbody>();
            // Set the maximum angular velocity.
            GetComponent<Rigidbody>().maxAngularVelocity = maxVelocity;
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            // If using torque to rotate the ball...
            if (ballTorqueOn)
            {
                // ... add torque around the axis defined by the move direction.
                myBall.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*moveForce);
            }
            else
            {
                // Otherwise add force in the move direction.
                myBall.AddForce(moveDirection*moveForce);
            }

            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, groundedRayLength) && jump)
            {
                // ... add force in upwards.
                myBall.AddForce(Vector3.up*jumpPower, ForceMode.Impulse);
            }
        }
    }
}
