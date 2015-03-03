using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
		public float speed;
		public float speedPace;
		public float timeDelay;
		public float timePace;
		float respawnTimer;
		public Text scoreText;
		int score;
		public GameObject pipe;
		public Transform startPosition;
		public static bool isRunning;
		public static bool isFinished;
		public int pipeMaxY = 2;
	public int pipeMinY = -1;
		public GameObject restartButton;
		public GameObject tutorButton;
		Vector2 gravity;


		// Use this for initialization
		void Start ()
		{
				score = 0;
				isRunning = false;
				isFinished = false;

				gravity = Physics2D.gravity;
				Physics2D.gravity = Vector2.zero;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetButtonDown ("Fire1") && !isFinished) {
						startGame ();
				}

				if (isRunning) {
						respawnTimer += Time.deltaTime;
						if (respawnTimer > timeDelay) {
								respawnTimer = 0f;

				int random = Random.Range (pipeMinY, pipeMaxY);

								var newPosition = startPosition.position;
								newPosition.y += random;
				
								Instantiate (pipe, newPosition, Quaternion.identity);
				
								speed += speedPace;
								timeDelay -= timePace;
						}
				}

				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.Quit ();
				}
		}

		void stopGame ()
		{
				isRunning = false;
				//Application.LoadLevel (Application.loadedLevel);
				restartButton.SetActive (true);
				isFinished = true;
		}

		public void restartGame ()
		{
//		isRunning = false;
				Application.LoadLevel (Application.loadedLevel);
		}

		public void startGame ()
		{
				isRunning = true;
				tutorButton.SetActive (false);
				Physics2D.gravity = gravity;
		}

		void updateScore ()
		{
				score++;
				scoreText.text = score + "";
		}
}
