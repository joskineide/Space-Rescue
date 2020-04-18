using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject Meteor;
	public float daddySpeed;
	public float fireRate;
	public float age;
	public bool daddyIsExplody;

	// Use this for initialization
	void Start () {
		age = daddySpeed; 
	}
	
	// Update is called once per frame
	void Update () {
		age += Time.deltaTime;
		if (age >= fireRate)
		{
			GameObject Bob;
			AsteroidBehaviour Greg = Meteor.GetComponent<AsteroidBehaviour>();
			Greg.MovingSpeed = daddySpeed;
			Greg.isMoving = true;
			Greg.isExplody = daddyIsExplody;
			Bob = (Instantiate(Meteor,transform.position,transform.rotation));
			age = 0;
		}
	}
}
