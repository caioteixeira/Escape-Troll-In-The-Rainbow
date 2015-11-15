using UnityEngine;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class Test1 : MonoBehaviour {

	public GameObject myoObject; 
	ThalmicMyo tMyoComponent;
	private Pose _lastPose = Pose.Unknown;
	// Use this for initialization
	void Start () {
		tMyoComponent = myoObject.GetComponent<ThalmicMyo> ();

	}
	
	// Update is called once per frame
	void Update () {
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (tMyoComponent.pose != _lastPose) {
			_lastPose = tMyoComponent.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (tMyoComponent.pose == Pose.Fist) {

							} 
			if (tMyoComponent.pose == Pose.WaveIn) {

	}
			if (tMyoComponent.pose == Pose.WaveOut) {
				
			}


}
}
}
