using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour
{
		public float groundSpeed = 5;
		public Transform startPosition;

		// Use this for initialization
		void Start ()
		{
				GetComponent<Rigidbody2D>().velocity = Vector2.right * groundSpeed * -1;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (GameController.isFinished)
						GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		else
			GetComponent<Rigidbody2D>().velocity = Vector2.right * groundSpeed * -1;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
//				Debug.LogError (other.tag);

				if (other.tag.Contains ("Destroyer"))
						transform.position = new Vector3 (startPosition.position.x, transform.position.y, transform.position.z);
		}
}
