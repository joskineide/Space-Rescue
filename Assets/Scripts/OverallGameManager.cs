using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverallGameManager : MonoBehaviour {

	public static OverallGameManager gameManager;
	public int star;
	public int points;
	public int fuel;
	public bool isAlive;
	public AudioSource bgm;
	public AudioSource childrenSounds;
	public AudioClip warning;
	public float warningTimer;
	public playerScript player;


	void Awake()
	{

		if (gameManager == null) {
			DontDestroyOnLoad (gameObject);
			gameManager = this;
		} else if (gameManager != this) 
		{
			Destroy (gameObject);
		}
	}

	void Start () {
		
		isAlive = true;
		bgm = GetComponent<AudioSource> ();
		childrenSounds = GetComponentInChildren<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) 
		{
			player = FindObjectOfType<playerScript> ();
		}
		if (Input.GetKeyDown (KeyCode.R) && player != null)
			Restart ();
		if (fuel <= 0 && player.body.velocity.x == 0 && player.body.velocity.y == 0) {
			fuel = 0;
			isAlive = false;
		}
		if (fuel > 0)
			isAlive = true;
		if (fuel > 20)
			fuel = 20;
		if (fuel >= 0 && fuel <= 5 && isAlive == true) {
			warningTimer += Time.deltaTime;
			if (warningTimer >= 0.9) 
			{
				childrenSounds.PlayOneShot (warning);
				if (fuel >=2)
					warningTimer = 0;
				if (fuel == 1)
					warningTimer = 0.4f;
				if (fuel == 0)
					warningTimer = 0.7f;
			}
		}
	}

	public void Restart ()
	{
		fuel = 20;
		points = 0;
		SceneManager.LoadScene (2); 
		isAlive = true;
	}
}
