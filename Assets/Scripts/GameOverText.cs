using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

	public TextMesh actualText;
	public OverallGameManager GManager;
	public string originalText;
	// Use this for initialization
	void Start () {
		actualText = GetComponent<TextMesh> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GManager == null)
			GManager = FindObjectOfType <OverallGameManager> ();
		originalText = "Dried out.%You saved "+ GManager.points.ToString()+ " people%before running out of power.%Press R to Restart";
		if (GManager.isAlive == true)
			actualText.color = new Color(255,255,255,0);
		if (GManager.isAlive == false)
			actualText.color = new Color (255, 255, 255, 255);
		string newText = originalText.Replace ("%","\n") ;
		actualText.text = newText;
		
	}
}
