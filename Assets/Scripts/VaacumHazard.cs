using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaacumHazard : MonoBehaviour {
	
	public float meteorForce;
	public float playerForce;
	public bool isPull;


	private Vector2 Direction;
	public playerScript player;

	void Start () {
	player = FindObjectOfType<playerScript> ();
		if (isPull) 
		{
			meteorForce = -meteorForce;
			playerForce = -playerForce;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Direction = thePlayer.transform.position - transform.position;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Meteor") 
		{
			Direction = other.transform.position - transform.position;
			//thePlayer.body.AddForce (Direction * Force);
			if (other.gameObject.tag == "Player") {
				if (player.lastBoost >= 0.5f) {
					player.body.AddForce (playerForce * Direction);
					player.isPulled = true;
				}
				//other.transform.RotateAround (transform.position, new Vector3 (0, 0, 1), Time.deltaTime * 90);

				//Debug.Log (player.body.velocity.y.ToString ());
			} 
			else if (other.gameObject.tag == "Meteor") 
			{
				Rigidbody2D otherBody = other.GetComponent<Rigidbody2D> ();
				otherBody.AddForce (meteorForce * Direction);
			}
		}
			//other.transform.RotateAround (transform.position, new Vector3 (0, 0, 1),90 * Time.deltaTime);
			//Vector3 direction = other.transform.position - transform.position;
			//other.GetComponent<Rigidbody2D>().AddForce(Direction* Force);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			player.isPulled = false;
		}
	}

}
