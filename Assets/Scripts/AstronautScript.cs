using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AstronautScript : MonoBehaviour {

	public int pointsValue;
	public OverallGameManager GManager;
	public float turnSpeed;
	public float turnDirection;
	public playerScript player;
	public GameObject godDebug;

	//ANIMATION STUFF
	private Animator anim;
	private int astronautType;
	private int idleType;
	private bool rescue;

	void Start()
	{
		anim = GetComponent<Animator> ();
		astronautType = Random.Range (0, 9);
		anim.SetInteger ("Type", astronautType);
		idleType = Random.Range (0, 4);
		anim.SetInteger ("idleType", idleType);

		turnDirection = Mathf.RoundToInt(Random.Range (-0.4999f, 1.4999f));
		if (turnDirection == 0)
			turnDirection = -1;
		turnSpeed = Random.Range (20, 50);
		player = FindObjectOfType<playerScript> ();

	}

	void Update () {
		if(!rescue)
		transform.Rotate (new Vector3 (0, 0, turnSpeed * Time.deltaTime*turnDirection));
		
		if (GManager == null)
		{
			GManager = FindObjectOfType<OverallGameManager> ();
			if (GManager == null) 
			{
				GameObject whyTho;
				whyTho = (Instantiate (godDebug, transform.position, transform.rotation));
				GManager = FindObjectOfType<OverallGameManager> ();
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			player.sEffects.PlayOneShot (player.collectDude);
			anim.SetTrigger ("rescue");
			rescue = true;
			transform.rotation = Quaternion.identity;
		}
	}
	public void isRescue()
	{
		GManager.points += pointsValue;

		Destroy (gameObject);
	}
}
