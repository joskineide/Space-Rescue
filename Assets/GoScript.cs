using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScript : MonoBehaviour {
	public int whereTo;
	public SpriteRenderer visible;

	void Start () {
		visible = GetComponent<SpriteRenderer> ();
		visible.color = new Color (1, 1, 1, 0);
	}
	
	// Update is called once per frame
	private void OnMouseOver()
	{
		if (Input.GetMouseButton (0)) {
			SceneManager.LoadScene (whereTo);
		}
	}
}
