using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingEnergyScript : MonoBehaviour {

	public Sprite[] health;
	public SpriteRenderer actSprite;
	public OverallGameManager GManager;

	void Start () {
		GManager = FindObjectOfType<OverallGameManager> ();
		actSprite = GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (GManager == null)
			GManager = FindObjectOfType<OverallGameManager> ();
			
		actSprite.sprite = health[GManager.fuel];
	}
}
