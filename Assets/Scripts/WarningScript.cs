using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningScript : MonoBehaviour {

	public float lilTimer;
	public int blinks;
	public SpriteRenderer settingCollors;
	// Use this for initialization
	void Start () {
		settingCollors = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		lilTimer += Time.deltaTime;
		if (lilTimer >= 0.2) 
		{
			if (blinks <= 7) 
			{
				if (blinks%2 == 1) 
				{
					settingCollors.color = new Color (255,255,255,255);
				}
				if (blinks%2 == 0) 
				{
					settingCollors.color = new Color (255,255,255,0);
				}
				blinks++;
			}
			if (blinks >= 8) 
			{
				Destroy (gameObject);
			}
			lilTimer = 0;
		}
		
	}
}
