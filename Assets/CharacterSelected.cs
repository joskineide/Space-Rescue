using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour {
    public GlobalGameManager gManager;
    public SpriteRenderer actualSprite;
    public Sprite[] characters;

	void Start () {
        gManager = FindObjectOfType<GlobalGameManager>();
        actualSprite = GetComponent<SpriteRenderer>();
        actualSprite.sprite = characters[gManager.curChar];
	}
	
	void Update () {
		
	}
}
