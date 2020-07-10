using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LezardMan : Thrower
{
    public float TimerSummon;
    protected bool CanSum = false;
    public GameObject summonedLezard;
    private Transform[] spawnPointsTransform = new Transform[4];
    private SpawnPoint[] spawnPoints = new SpawnPoint[4];
    protected bool firstMeet = true;


    private void Awake()
    {
        spawnPoints = gameObject.GetComponentsInChildren<SpawnPoint>();
        spawnPointsTransform = gameObject.GetComponentsInChildren<Transform>();
    }


    protected override void IA()
    {
        base.IA();
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= detectingDistance && !CanSum && firstMeet)
        {
            StartCoroutine(WaitToSum());
            firstMeet = false;
        }
        if (CanSum && distance <= detectingDistance)
        {
            summon();
            StartCoroutine(WaitToSum());
        }
    }

    protected void summon()
    {
        for (int i = 0; i<4; i++)
        {
            if (!spawnPoints[i].isInCollision)
            {
                GameObject lezard = Instantiate(summonedLezard,spawnPointsTransform[i].position, spawnPointsTransform[i].rotation);
                lezard.layer = 4;
                return;
            }
        }
    }

    protected IEnumerator WaitToSum()
    {
        CanSum = false;
        yield return new WaitForSeconds(TimerSummon);
        CanSum = true;
    }
}
