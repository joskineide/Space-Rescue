using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int step = 0; step <= 7; step++) 
		{
			Debug.Log (step.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
