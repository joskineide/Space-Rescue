using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacleBigScript : MonoBehaviour {
	public tentacleDad myDad;
	private bool attack;
	private Animator anim;
	public playerScript thePlayer;
	private Vector3 direction;
	public float force;
	public int damage;
	public float delay;
	public float delayCounter;
	private SpriteRenderer spRender;
	// Use this for initialization
	void Start () {
		spRender = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		thePlayer = FindObjectOfType<playerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		

		anim.SetBool ("Attack", myDad.isOnArea);
		if (myDad.isOnArea) {
			delayCounter += Time.deltaTime;
			direction = thePlayer.transform.position - transform.position;
			float zRot = Mathf.Atan2 (direction.x, direction.y) * Mathf.Rad2Deg;
			//transform.right = direction;
			transform.rotation = Quaternion.Euler (0f, 0f, -zRot + 180f);

			if (!thePlayer.crash) {
				attack = true;
				delayCounter = 0;
			}

		} else {
			attack = false;

		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Player") 
		{
			
			//other.GetComponent<Rigidbody2D> ().AddForce (force * direction,ForceMode2D.Impulse);
			thePlayer.hit (damage);
		}
		other.GetComponent<Rigidbody2D> ().AddForce (force * direction,ForceMode2D.Impulse);
	}
}
