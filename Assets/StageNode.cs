using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageNode : MonoBehaviour {

    public GlobalGameManager gManager;
    public StageSelecter stageSelecter;
    public int stage;
    public float curTransform;
    public bool selected;
    public StageConfirm PopUp;
    public int whereTo;
    public bool isFirst;
	public Vector2 goButtonPosition;
	public GoScript goButton;
    private void Awake()
    {
        PopUp = FindObjectOfType<StageConfirm>();
    }
    void Start () {
		goButton = FindObjectOfType<GoScript> ();
        stageSelecter = FindObjectOfType<StageSelecter>();
        gManager = FindObjectOfType<GlobalGameManager>();
        if (isFirst)
        {
            stageSelecter.target = this.transform;
            stageSelecter.movingTo = this.transform;
        }
        curTransform = this.transform.localScale.x;
	}
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            selected = true;
        }
        else if (selected)
        {
			gManager.curStar = stage;
			goButton.visible.color = new Color (1, 1, 1, 1);
			goButton.transform.position = goButtonPosition;
			goButton.whereTo = whereTo;
            if (stageSelecter.target != transform)
            {
                stageSelecter.target = this.transform;
                selected = false;
            }
        }
        //SceneManager.LoadScene(stage + 3);
    }
    private void OnMouseExit()
    {
        selected = false;   
    }
    void Update () {
        if (selected)
            transform.localScale = new Vector3(curTransform * 1.3f, curTransform * 1.3f, 1);
        else
            transform.localScale = new Vector3(curTransform, curTransform, 1);
        if (stageSelecter.target == this.transform && stageSelecter.target != null && !stageSelecter.isMoving)
        {
            PopUp.stageName.text = "Stage: " + stage;
            PopUp.score.text = "x" + gManager.stageScores[stage - 1];
            PopUp.battery.text = "x" + gManager.stageBattery[stage - 1];
        }
    }
}
