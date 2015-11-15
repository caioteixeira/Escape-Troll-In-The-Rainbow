using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {
	public GameManager gm; 

	public Text scoreText;

	public CanvasGroup gameOver;
	public Text gameOverScoreText;
	
	void Start () {
	
	}

	void Update () {
		scoreText.text = "Score: " + gm.score;
	}

	public void GameOver () {
		GetComponent<Animator>().SetTrigger("GameOver");
		gameOverScoreText.text = "Score: " + gm.score; 
	}

	public void Retry () {
		Application.LoadLevel("rainbow-road");
	}
}
