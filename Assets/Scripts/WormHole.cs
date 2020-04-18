using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHole : MonoBehaviour {
	public bool travel;
	private Animator myAnim;
	public WormHole destination;
	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		myAnim.SetBool ("Travel", travel);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (!travel ) 
		{
			
			travel = true;
			destination.travel = true;
			other.gameObject.transform.position = destination.transform.position;

			Invoke ("validateTravel", 1f);
			destination.Invoke ("validateTravel", 1f);
		}/*else if (other.gameObject.tag == "Meteor" && !meteorTravel ) 
		{

			meteorTravel = true;
			other.gameObject.transform.position = destination.position;

			Invoke ("validateMeteorTravel", 1f);
		}*/


	}
	void validateTravel()
	{
		travel = false;


	}
	/*void validateMeteorTravel()
	{
		meteorTravel = false;
	}*/


}
