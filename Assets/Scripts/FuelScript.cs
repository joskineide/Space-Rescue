using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour {

	public int refuelValue;
	public OverallGameManager GManager;
	public playerScript player;

	void Start()
	{
		player = FindObjectOfType<playerScript> ();
	}

	void Update () {
		if (GManager == null)
			GManager = FindObjectOfType<OverallGameManager> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			GManager.fuel += refuelValue;
			player.sEffects.PlayOneShot (player.collectBatery);
			Destroy (gameObject);
		}
	}
}
