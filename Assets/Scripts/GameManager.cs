using UnityEngine;
using System.Collections;
using EarthTroll.Player;

public class GameManager : MonoBehaviour {
	public int score;
	public HUDManager hud;
	public Player player; 

	private int originalPlayerSpeed = 0;
	private int playerPositionOffset = 0;

	void Start () {
		Time.timeScale = 1.0f;
		originalPlayerSpeed = player.speed;
		playerPositionOffset = Mathf.Abs((int)player.transform.position.x);
	}

	void Update () {
		score = playerPositionOffset + ((int)player.transform.position.x);
		player.speed = originalPlayerSpeed + (int)player.transform.position.x;
	}

	public IEnumerator GameOver() {
		hud.GameOver();
		yield return new WaitForSeconds(1f);
		Time.timeScale = 0f;
	}
}
