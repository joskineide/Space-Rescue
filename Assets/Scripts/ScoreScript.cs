using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public TextMesh actualText;
	public OverallGameManager GManager;
	// Use this for initialization
	void Start () {
		actualText = GetComponent<TextMesh> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GManager == null)
			GManager = FindObjectOfType<OverallGameManager> ();
		actualText.text = ("Saved: " +GManager.points.ToString());
	}
}
