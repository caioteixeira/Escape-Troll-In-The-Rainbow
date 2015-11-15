using UnityEngine;
using System.Collections;

public class Horse : MonoBehaviour {

	public Vector3 movement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = movement;
	}
}
