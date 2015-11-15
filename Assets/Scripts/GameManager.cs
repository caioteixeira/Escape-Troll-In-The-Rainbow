using UnityEngine;
using System.Collections;
using EarthTroll.Player;

public class GameManager : MonoBehaviour {
	public int score;
	public Player player; 

	private int originalPlayerSpeed = 0;
	private int playerPositionOffset = 0;

	void Start () {
		originalPlayerSpeed = player.speed;
		playerPositionOffset = Mathf.Abs((int)player.transform.position.x);
	}

	void Update () {
		score += playerPositionOffset + ((int)player.transform.position.x);
		player.speed = originalPlayerSpeed + (int)player.transform.position.x;
	}	
}
