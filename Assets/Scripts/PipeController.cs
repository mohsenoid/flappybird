using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour
{
		public float moveSpeed = 5;
//		GameObject gameController;

		// Use this for initialization
		void Start ()
		{
				rigidbody2D.velocity = Vector2.right * moveSpeed * -1;
//				gameController = GameObject.FindGameObjectWithTag ("GameController");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (!GameController.isRunning)
						rigidbody2D.isKinematic = true;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag.Contains ("Destroyer")) {
						Destroy (gameObject);
				}
		}
}
