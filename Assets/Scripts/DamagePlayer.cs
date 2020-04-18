using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
	
	public int damage =1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.GetComponent<playerScript> ().hit (damage);
		} else if (other.gameObject.tag == "Meteor" && other.gameObject.GetComponent<AsteroidBehaviour> ().isExplody) 
		{
			other.gameObject.GetComponent<AsteroidBehaviour> ().dead = true;
		}
	}
}
