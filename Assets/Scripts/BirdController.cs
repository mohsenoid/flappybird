using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
		public float jumpSpeed = 5;
		public float rotationAngle = 35;
		GameObject gameController;
		Vector3 rotation;
		// Use this for initialization
		void Start ()
		{
				gameController = GameObject.FindGameObjectWithTag ("GameController");
		}
	
		// Update is called once per frame
		void Update ()
		{
				rotation = transform.localEulerAngles;

				if (!GameController.isFinished) {
						if (Input.GetButtonDown ("Fire1")) {
//								Debug.Log ("Jump!");
//			rigidbody2D.AddForce (Vector2.up * jumpSpeed);
								GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
//				Vector2 jumpForce = new Vector2(0, 300);
//				rigidbody2D.velocity = Vector2.zero;
//				rigidbody2D.AddForce(jumpForce);

								rotation.z = rotationAngle;
								
						}
//		transform.rotation.Set(transform.position.y*rotationFactor,0,0,0);
//		Debug.Log (rotation.z);
						if (GameController.isRunning) {
								rotation.z -= 1.5f;
						}

						transform.localEulerAngles = rotation;
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag.Contains ("Obsticles")) {
//						Debug.Log ("Hit!!");
						gameController.SendMessage ("stopGame");
						this.GetComponent<Animator> ().SetBool ("isFlying", false);
				}

				
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				if (other.gameObject.tag.Contains ("Obsticles")) {
						//						Debug.Log ("Hit!!");
						gameController.SendMessage ("stopGame");
						this.GetComponent<Animator> ().SetBool ("isFlying", false);
						GetComponent<Rigidbody2D>().isKinematic = true;
				}
		}
}
