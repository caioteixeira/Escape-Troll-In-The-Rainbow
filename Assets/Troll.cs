using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
	}
}
