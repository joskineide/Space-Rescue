using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour {

	public OverallGameManager GManager;
	public bool isEnder;

	void Update () {
		if (GManager == null)
			GManager = FindObjectOfType <OverallGameManager> ();
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if (isEnder) 
			{
				SceneManager.LoadScene (5);
			}else 
			{
				if (GManager.fuel <= 0)
					GManager.fuel = 1;
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
		}
	}
}
