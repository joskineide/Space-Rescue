using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

	public int damage = 1;
	public playerScript player;
	public OverallGameManager GManager;
	public Animator anim;
	public bool isExplody;
	public float turnSpeed;
	public bool isMoving;
	public float MovingSpeed;
	public Rigidbody2D body;
	public int meteorType;
	public bool dead;
	public float deathTimer;
	public float turnDirection;
	public AudioSource meteorSounds;
	public AudioClip crashSound;
	public AudioClip explodeSound;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType <playerScript> ();
		body = GetComponent <Rigidbody2D> ();
		anim = GetComponent <Animator> ();
		turnSpeed = Random.Range (20, 50);
		turnDirection = Mathf.RoundToInt(Random.Range (-0.4999f, 1.4999f));
		if (turnDirection == 0)
			turnDirection = -1;
		meteorType = Mathf.RoundToInt (Random.Range (-0.499f, 3.499f));
		anim.SetInteger ("MeteorType", meteorType);
		anim.SetBool ("IsExplody", isExplody);
		if (isMoving == true)
			body.AddForce (transform.up*MovingSpeed);
		meteorSounds = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, turnSpeed * Time.deltaTime*turnDirection));
		if (GManager == null)
			GManager = FindObjectOfType<OverallGameManager> ();
		if (dead) {
			deathTimer += Time.deltaTime;
			CircleCollider2D Bob = GetComponent<CircleCollider2D> ();
			Bob.isTrigger = true;
			anim.SetBool ("Boom", true);


			if (deathTimer >= 0.3f)
				Destroy (gameObject);
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			meteorSounds.PlayOneShot (crashSound);
			if (GManager.fuel > 0)
				player.hit (1);
		}
		else if (other.gameObject.tag == "Meteor" && isExplody == false) 
		{
			meteorSounds.PlayOneShot (crashSound);
		}
	
		else if (other.gameObject.tag == "Meteor" && isExplody == true) 
		{
			meteorSounds.PlayOneShot (explodeSound);
			dead = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Map")
			Destroy (gameObject);
	}


}
