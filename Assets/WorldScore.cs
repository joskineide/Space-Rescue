using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScore : MonoBehaviour {
    public int curWorld;
    public int maxScore;
    public TextMesh actualText;
    public GlobalGameManager gManager;

	void Update () {
        gManager = FindObjectOfType<GlobalGameManager>();
        actualText = GetComponent<TextMesh>();
        actualText.text = gManager.worldScores[curWorld]+" / "+maxScore;
	}
}
