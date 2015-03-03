using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
	GameObject gameController;
	bool isScored;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		isScored = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Contains ("Player") && !isScored) {
			gameController.SendMessage ("updateScore");
			isScored=true;
		}
	}
}
	