using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour {
    public Transform[] wayPoints;
    public Transform target;
    public Transform movingTo;
    public int curPos;
    public int goTo;
    public bool isMoving;
    public float speed;

	private Animator myAnim;

	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	
	void Update () {
		myAnim.SetBool ("Walking", isMoving);

        float step = speed * Time.deltaTime;
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (wayPoints[i] == target)
                goTo = i;
            if (transform.position == wayPoints[i].position && isMoving)
            {
                curPos = i;
                isMoving = false;
            }
        }
        if (!isMoving)
        {
            if (curPos < goTo)
            {
                //curPos++;
                movingTo = wayPoints[curPos+1];
                isMoving = true;
            }
            else if (curPos > goTo)
            {
                //curPos--;
                movingTo = wayPoints[curPos-1];
                isMoving = true;
            }
        }
        if (isMoving)
            transform.position = Vector3.MoveTowards(transform.position, movingTo.position, step);

    }
}
