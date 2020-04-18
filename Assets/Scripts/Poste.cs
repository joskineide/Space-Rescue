using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poste : MonoBehaviour {
	public float[] tempoApagado;
	public float[] tempoAceso;
	private int i;
	private bool aceso;
	private bool raio;
	private Collider2D myCol;
	private float horadoRaio;
	public Animator anim;

	// Use this for initialization
	void Start () {
		acender ();
		anim = GetComponent<Animator> ();
		myCol = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		raio = true;
		anim.SetBool ("Aceso", aceso);
		anim.SetBool ("Raio", raio);
	}
	void acender()
	{
		if (i > tempoAceso.Length) 
		{
			raio = true;

		}

		Invoke ("apagar", tempoApagado [i]);
		aceso = !aceso;
	}
	void apagar ()
	{
		
		Invoke ("acender", tempoAceso [i]);
		i++;
		aceso = !aceso;
	}
}
