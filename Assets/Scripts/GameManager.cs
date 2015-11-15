using UnityEngine;
using System.Collections;
using EarthTroll.Player;
using System;

public class GameManager : MonoBehaviour {
	public int score;
	public HUDManager hud;
	public Player player; 

	public Camera playerCam;
	public Camera cam;

	private int originalPlayerSpeed = 0;
	private int playerPositionOffset = 0;

	void Start () {
		Time.timeScale = 1.0f;
		originalPlayerSpeed = player.speed;
		playerPositionOffset = Mathf.Abs((int)player.transform.position.x);

		StartCoroutine(StartCutscene());
	}

	void Update () {
		score = playerPositionOffset + ((int)player.transform.position.x);

		player.speed = originalPlayerSpeed + (int)Math.Log(Math.Abs(player.transform.position.x));
	}	

	IEnumerator StartCutscene() {
		playerCam.enabled = false;
		cam.enabled = true;

		yield return new WaitForSeconds(2.5f);

		playerCam.enabled = true;
		cam.enabled = false;

	}

	public IEnumerator GameOver() {
		hud.GameOver();
		yield return new WaitForSeconds(0.5f);
		Time.timeScale = 0f;
	}

    public bool SetNewScore()
    {
        int high = PlayerPrefs.GetInt("HighScore");
        if (score > high)
        {
            PlayerPrefs.SetInt("HighScore", score);
            return true;
        }
        return false;
    }

    public int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
            return PlayerPrefs.GetInt("HighScore");
        else
            return -1;
    }
}
