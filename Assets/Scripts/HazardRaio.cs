using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRaio : MonoBehaviour {
	public bool pisca;
	public float[] tempoApagado;
	public float[] tempoAceso;
	public int i = -1;
	public SpriteRenderer spRenderer;
	public Sprite[] SpriteType;
	public GameObject light;
	public float tempodeLuzAtiva;
	//Animações
	public Animator myAnim;


	// Use this for initialization
	void Start () {
		spRenderer = GetComponent<SpriteRenderer> ();
		if (tempoApagado.Length > 0)
			apagar ();
		else
			light.GetComponent<Collider2D>().enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		myAnim.SetBool ("isLit", light.GetComponent<Collider2D>().enabled);
	}
	void apagar()
	{
		i++;
		if (i >= tempoAceso.Length ) 
		{
			//light.SetActive (true);
			Debug.Log ("LIGHTING UP  "+ i.ToString ());
			Invoke ("reset", tempodeLuzAtiva);
			
		} 
		else 
		{
			light.GetComponent<Collider2D>().enabled = false;
			spRenderer.sprite = SpriteType [0];
			Debug.Log ("I'M DOWN FOR  "+tempoApagado [i].ToString() +"  "+ i.ToString ());
			Invoke ("acender", tempoApagado [i]);
		}
	}
	void acender()
	{
		light.GetComponent<Collider2D>().enabled = true;
		spRenderer.sprite = SpriteType [1];
		Debug.Log ("SHUTING DOWN IN  "+ tempoAceso[i].ToString()+"  " + i.ToString ());
		Invoke ("apagar", tempoAceso [i]);
	}
	void reset()
	{
		i = -1;
		light.GetComponent<Collider2D>().enabled = false;
		apagar ();
	}
}
