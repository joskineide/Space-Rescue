using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacleDad : MonoBehaviour {
	public bool isOnArea;
	public bool isBoss;
	public bool anyOnArea;
	public Vector3 target;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Player" || isBoss ) 
		{
			isOnArea = true;
			Debug.Log("pode matar filhão!!");
		}
		anyOnArea = true;
		target = other.transform.position;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			isOnArea = false;
			Debug.Log("Ta seguro");
		}
		anyOnArea = false;

	}
}
