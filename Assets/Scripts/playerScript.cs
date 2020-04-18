using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

	public Rigidbody2D body;
	public float Truster;
	public float checker;
	public float turnspeed;
	public float speedcheckerx;
	public float speedcheckery;
	public OverallGameManager GManager;
	public Animator anim;
	public AudioSource sEffects;
	public AudioClip boom;
	public AudioClip poof;
	public AudioClip newStage;
	public AudioClip collectDude;
	public AudioClip collectBatery;
	private float rotating;
	//Colisão
	public SpriteRenderer playerRender;
	private float actualFuel;
	public float tempoInvencivel;
	private float tempoInvencivelCounter;
	public float lastBoost;
	public bool isPulled;
	public float gravRotate;
	public float rotateSpeed;
	[HideInInspector]public bool crash;




	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
		sEffects = GetComponent<AudioSource> ();
		sEffects.PlayOneShot (newStage);
		GManager = FindObjectOfType<OverallGameManager> ();
		playerRender = GetComponent<SpriteRenderer> ();
		tempoInvencivelCounter = tempoInvencivel;

	}

	/*void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == 8) 
		{
			WallType orientation = other.GetComponent<WallType> ();
			if ((body.velocity.x > 0 && orientation.Type == 1) ||(body.velocity.x < 0 && orientation.Type == 2))
				body.velocity = new Vector2 (0, body.velocity.y);
			if ((body.velocity.y > 0 && orientation.Type == 3) || (body.velocity.y < 0 && orientation.Type == 4))
				body.velocity = new Vector2 (body.velocity.x,0);
		}
	}
*/
	void Update () {
		if (GManager == null) 
		{
			GManager = FindObjectOfType<OverallGameManager> ();
		}
		lastBoost += Time.deltaTime;
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			if (rotating > -1)
				rotating -= Time.deltaTime * rotateSpeed;
			else
				rotating = -1;
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			if (rotating < 1)
				rotating += Time.deltaTime * rotateSpeed;
			else
				rotating = 1;
		} else if (rotating != 0){
			rotating = rotating / rotateSpeed;
			if (rotating < 0.01f && rotating > -0.01f)
				rotating = 0;				
		}
		transform.Rotate (new Vector3 (0, 0, (rotating * -turnspeed * Time.deltaTime) + (gravRotate * Time.deltaTime)));
		anim.SetFloat ("Rotating",Mathf.Abs(rotating));
		//if (GManager == null)
		//	GManager = FindObjectOfType<OverallGameManager> ();
		speedcheckerx = body.velocity.x;
		speedcheckery = body.velocity.y;
		if (GManager.fuel <= 0 && body.velocity.x == 0 && body.velocity.y == 0) 
		{
			GManager.isAlive = false;
		}
		if (body.velocity.y != 0 && isPulled == false) 
			body.AddForce (new Vector2 (0, -body.velocity.y * checker));
		if (body.velocity.x != 0 && isPulled == false)
			body.AddForce (new Vector2 (-body.velocity.x * checker, 0));

		if (Input.GetKeyDown (KeyCode.Space) && GManager.fuel > 0) {
			body.AddForce (transform.up*Truster);
			GManager.fuel--;
			lastBoost = 0;
			sEffects.PlayOneShot(boom);
			anim.Play ("AstronautPropel");
		}
		if (Input.GetKeyDown (KeyCode.Space) && GManager.fuel <= 0) {
			sEffects.PlayOneShot(poof);
			anim.Play ("AstronautPooh");
		}

		/*if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0, 0, -turnspeed));
			anim.Play ("AstronautRotate");
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0, 0, turnspeed));
			anim.Play ("AstronautRotate");
		} */


		//Colisão
		if(crash)
		{
			tempoInvencivelCounter -= Time.smoothDeltaTime;
			if (tempoInvencivelCounter > tempoInvencivel *  0.66f && tempoInvencivelCounter < tempoInvencivel) {
				playerRender.color = new Color (playerRender.color.r, playerRender.color.g, playerRender.color.b, 0.2f);
			} else if (tempoInvencivelCounter > tempoInvencivel *  0.33f) {
				playerRender.color = new Color (playerRender.color.r, playerRender.color.g, playerRender.color.b, 1f);
			}else if (tempoInvencivelCounter > 0f) {
				playerRender.color = new Color (playerRender.color.r, playerRender.color.g, playerRender.color.b, 0.2f);
			}else{
				playerRender.color = new Color (playerRender.color.r, playerRender.color.g, playerRender.color.b, 1f);
				tempoInvencivelCounter = tempoInvencivel;
				crash = false;
			}
		}

	}

	public void hit(int damage)
	{
		Debug.Log ("CRASH");
		if (!crash) {
			GManager.fuel -= damage;
		}
		crash = true;



	}
}
