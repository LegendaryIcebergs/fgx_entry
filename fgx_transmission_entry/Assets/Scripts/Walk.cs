using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    public int actionNumber = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    public bool allowMove;
    public bool readyForNext;
    private Animator anim;
    public int curState;

    private IEnumerator idleRoutine;
    private IEnumerator talkRoutine;
    private IEnumerator fightRoutine;
    private IEnumerator victimRoutine;

    // Use this for initialization
    void Start() {
        curState = 0;
        allowMove = true;
        anim = GetComponent<Animator>();
        readyForNext = false;
        talkRoutine = Talk(3.0f);
        fightRoutine = Fight(3.0f);
        victimRoutine = Victim(3.0f);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (readyForNext)
        {
            NextWaypoint();
        }
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length) {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            if (allowMove)
            {
                // rotate towards the target
                transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, 10 * Time.deltaTime, 0.0f);

                // move towards the target
                transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
            }
        }

        if (transform.position == targetWayPoint.position)
        {
            allowMove = false;
            if (actionNumber == 0) StartCoroutine(idleRoutine);
            if (actionNumber == 1) StartCoroutine(talkRoutine);
            if (actionNumber == 2) StartCoroutine(fightRoutine);
            if (actionNumber == 3) StartCoroutine(victimRoutine);
            /*if (actionNumber == 4) StartCoroutine(talkRoutine);
            if (actionNumber == 5) StartCoroutine(talkRoutine);
            if (actionNumber == 6) StartCoroutine(talkRoutine);
            if (actionNumber == 7) StartCoroutine(talkRoutine);*/
        }

        switch (curState)
        {
            case 1:
                anim.SetBool("idle", true);
                break;

            case 2:
                anim.SetBool("left", true);
                break;


            case 3:
                anim.SetBool("right", true);
                break;


            case 4:
                anim.SetBool("shoot", true);
                break;


            case 5:
                anim.SetBool("dead", true);
                break;

        }
    }

    public void NextWaypoint()
    {
        readyForNext = false;
        currentWayPoint++;
        targetWayPoint = wayPointList[currentWayPoint];
        allowMove = true;
        actionNumber++;
    }

    IEnumerator Idle(float seconds)
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetBool("talk", false);
        anim.CrossFade("Armature|idle", 1f);
        yield return new WaitForSeconds(seconds);
        readyForNext = true;
    }
    IEnumerator Talk(float seconds)
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetBool("talk", true);
        anim.CrossFade("Armature|idleTalk", 1f);
        yield return new WaitForSeconds(seconds);
        readyForNext = true;
    }

    IEnumerator Fight(float seconds)
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetBool("talk", false);
        anim.SetTrigger("punch");
        yield return new WaitForSeconds(seconds);
        readyForNext = true;
    }

    IEnumerator Victim(float seconds)
    {
        anim.SetFloat("randomNumber", Random.value);
        anim.SetBool("talk", false);
        anim.CrossFade("Armature|dropDown", 1f);
        yield return new WaitForSeconds(seconds);
        readyForNext = true;
    }
}
