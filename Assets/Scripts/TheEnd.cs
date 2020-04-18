using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour {

	public TextMesh actualText;
	public OverallGameManager gManager;
	public float cmonTimer;
	public string originalText;

	// Use this for initialization
	void Start () {
		actualText = GetComponent<TextMesh> ();
	}

	// Update is called once per frame
	void Update () {
		if (gManager == null)
			gManager = FindObjectOfType<OverallGameManager> ();
		if (gManager.points > 0 && gManager.points < 33)
			originalText = "You saved: "+ gManager.points.ToString()+ " out of 33 people% and finished before running out of power.%Congratulations!";
		if (gManager.points == 0)
			originalText = "You saved no one and%finished before running out of power.%At least you survived.%Alone.%Forever.";
		if (gManager.points >= 33)
			originalText = "You managed to save everyone%and even had some power left!%Congratulations!";
		string newText = originalText.Replace ("%","\n") ;
		actualText.text = newText;
		cmonTimer += Time.deltaTime;
		if (Input.anyKeyDown && cmonTimer >= 1f)
			gManager.Restart();	
	}
}