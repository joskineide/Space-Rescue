using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {
    public int[] worldScores;
    public int[] stageScores;
    public int[] stageBattery;
    public int curChar;
	public int curStar;
    private static GlobalGameManager globalGameManager;
    private void Awake()
    {
        if (globalGameManager == null)
            globalGameManager = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        worldScores = new int[3];
        stageScores = new int[10];
        stageBattery = new int[10];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            SetUpScores();
    }

    public void SetUpScores()
    {
        for (int i = 0; i < worldScores.Length; i++)
        {
            worldScores[i] = 0;
        }
        for (int i = 0; i < stageScores.Length; i++)
        {
            if (i < 3)
                worldScores[0] += stageScores[i];
            else if (i < 6)
                worldScores[1] += stageScores[i];
            else
                worldScores[2] += stageScores[i];
        }
    }
}
