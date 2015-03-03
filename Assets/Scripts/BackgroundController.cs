using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
		public float backgroundSpeed = 3;
		public Transform startPosition;
		// Use this for initialization
		void Start ()
		{
//				rigidbody2D.velocity = Vector2.right * backgroundSpeed * -1;
		}
	
		// Update is called once per frame
		void Update ()
		{
//				if (!GameController.isRunning)
//						rigidbody2D.isKinematic = true;
		}

//	void OnDestroy(){
//		Debug.Log ("test");
//		ga
//		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag.Contains ("Destroyer"))
						transform.position = startPosition.position;
//			Debug.Log ("Distroy!!");
//			Destroy (other.gameObject);
		}

}
