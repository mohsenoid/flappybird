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
		public Text highscoreText;
		int score, highscore;
		public GameObject pipe;
		public Transform startPosition;
		public static bool isRunning;
		public static bool isFinished;
		public int pipeMaxY = 2;
		public int pipeMinY = -1;
		public GameObject restartMenu;
		public GameObject tutorButton;
		Vector2 gravity;


		// Use this for initialization
		void Start ()
		{
				score = 0;
				highscore = PlayerPrefs.GetInt ("High Score");

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
				highscoreText.text = highscore + "";
				restartMenu.SetActive (true);
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
		
				PlayerPrefs.SetInt ("Last Score", score);
		
				if (score > highscore) { //when player dies set highscore = to that score
						highscore = score;
						PlayerPrefs.SetInt ("High Score", highscore);
			
						Debug.Log ("High Score is " + highscore);
			
				} 

				scoreText.text = score + "";
				
		}
}
