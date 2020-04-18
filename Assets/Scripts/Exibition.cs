using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exibition : MonoBehaviour {

	public float CMONtimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CMONtimer += Time.deltaTime;
		if (Input.anyKeyDown && CMONtimer>= 1f)
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex +1);		
	}
}
