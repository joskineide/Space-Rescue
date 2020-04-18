using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRandomizer : MonoBehaviour {

	public int currentStage;
	public int curThreatDebug;
	public int loopFailSafe = 0;
	public GameObject[] threats;
	public int[] qtdThreat;
	public int[] maxThreat;
	public int[] threatWeight;
	public int[] threatSizex;
	public int[] threatSizey;
	public bool[,] posOc;
	public int curPosxDebug;
	public int curPosyDebug;
	public bool allGood = false;
	public OverallGameManager goshujin;
	public bool runBitch;
	void Start () 
	{
		posOc = new bool[10,5];
		goshujin = FindObjectOfType<OverallGameManager> ();
		//currentStage = goshujin.stage;
		curThreatDebug = currentStage;
		Debug.Log ("is even running?");
	}

	void Update()
	{
		if (!runBitch)
			setUp ();
		runBitch = true;
	}

	void setUp()
	{
		for (int step = 0; step <= 6; step++) 
		{
			Debug.Log ("situação 1");
			if (curThreatDebug > 0 && step < 6 && (currentStage-3)/5 >= step) 
			{
				setThreatQtd (step, maxThreat [step], threatWeight [step]);
				placeThreat (step,threatSizex[step],threatSizey[step]);
				Debug.Log ("who am I?1");
			} 
			else if (step == 6) 
			{
				qtdThreat [0] += curThreatDebug;
				placeThreat (0,threatSizex[0],threatSizey[0]);
				Debug.Log ("who am I?2");
			} 
			else 
			{
				step = 6;
				placeThreat (0,threatSizex[0],threatSizey[0]);
				Debug.Log ("who am I?3");
			}
		}
	}
	void resetBoys()
	{
	}
	void setThreatQtd(int pos, float maxQtd, int weight)
	{
		if (curThreatDebug >= maxQtd * weight) 
		{
			qtdThreat[pos] = Mathf.RoundToInt(Random.Range (-0.49f, maxQtd)/weight);
			Debug.Log ("Situação 4: qtdThreat ="+qtdThreat[pos].ToString());
		}
		else
		{
			qtdThreat[pos] = Mathf.RoundToInt(Random.Range (-0.49f, curThreatDebug)/weight);
			Debug.Log ("Situação 5: qtdThreat ="+qtdThreat[pos].ToString());
		}
		Debug.Log(pos.ToString() + " before: "+ curThreatDebug.ToString());
		curThreatDebug -= qtdThreat [pos] * weight;
		Debug.Log(pos.ToString() + " after: "+ curThreatDebug.ToString()+ "  Qtd"+qtdThreat[pos].ToString());
	}
	void placeThreat(int pos, int objSizex, int objSizey)
	{
		while (qtdThreat [pos] > 0) 
		{
			do 
			{
				Debug.Log ("situação 2");
				curPosxDebug = Mathf.RoundToInt(Random.Range (0, 10));
				curPosyDebug = Mathf.RoundToInt(Random.Range (0, 5));
				loopFailSafe++;
				if(loopFailSafe>=100)
				{
					Debug.Log("qtdTreat "+ qtdThreat [pos].ToString());
				}
			} while (posOc [curPosxDebug,curPosyDebug]);
			loopFailSafe = 0;
			for (int pX = curPosxDebug - objSizex; pX >= objSizex; pX++)
			{
				Debug.Log ("situação 3");
				if (pX >= 0 && pX<=19) 
				{
					for (int pY = curPosyDebug - objSizey; pY >= objSizey; pY++) 
					{
						if (pY >= 0 && pY <= 9) 
						{
							Debug.Log ("X:"+pX.ToString () + "   Y:" + pY.ToString ());
							posOc [pX, pY] = true;
						}
					}
				}
			}
			Debug.Log (pos.ToString () + " em X: "+curPosxDebug.ToString()+" em Y:"+curPosyDebug.ToString());
			Instantiate (threats [pos], new Vector2 (this.transform.position.x+curPosxDebug*2, this.transform.position.y+curPosyDebug*2),Quaternion.identity);
			qtdThreat[pos] --;
		}
	}
}
