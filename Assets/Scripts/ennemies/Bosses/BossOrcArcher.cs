using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOrcArcher : Thrower
{
    public GameObject summonedOrc;
    public List<Transform> positionsSum;
    public int numberOfSum = 2;
    public float timerSum = 20;
    private bool canSum = false;
    private List<Transform> positionsSumSaved;
    private bool firstmeet = true;
    public GameObject drop;

    private void Awake()
    {
        positionsSumSaved = positionsSum;
    }

    void Update()
    {
        IA();
        StartCoroutine(ManageHealth());
        Summon();
    }

    protected override void IA()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= detectingDistance && distance > throwingDistance && canMove)
        {
            animator.SetBool("start_moving", true);
            animator.speed = 1;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            SpriteAnimation();
        }
        if (distance <= throwingDistance && canShoot)
        {
            StartCoroutine(shoot(timerShots, timerFreezAfterShot));
            animator.speed = 0;

        }
        if (distance > detectingDistance)
        {
            animator.SetBool("start_moving", false);
        }
        if (health <= 0)
        {
            Instantiate(drop, transform.position, transform.rotation);
            ManageOffrande.actualOffrande = ManageOffrande.typeOffrande.boss1;
            if (SamController.instance.karma >= ManageOffrande.instance.minimumKarma)
                ManageOffrande.EnoughKarma1 = true;
        }
    }

    private void Summon()
    {
        if (animator.GetBool("start_moving") && !canSum && firstmeet)
        {
            StartCoroutine(waitToSum());
            firstmeet = false;
        }
        if (canSum && animator.GetBool("start_moving"))
        {
            for (int i = 0; i < numberOfSum; i++)
            {
                int index = Random.Range(0, positionsSumSaved.Count);
                if (checkSpace(index))
                {
                    GameObject orc = Instantiate(summonedOrc, positionsSumSaved[index].position, positionsSumSaved[index].rotation);
                    orc.layer = 2;
                }
            }
            StartCoroutine(waitToSum());
        }
    }

    //verifier que le joueur ne soit pas sur la case au moment de l'invocation => à faire s'il y a le temps
    private bool checkSpace(int index)
    {
        return true;
    }

    protected IEnumerator waitToSum()
    {
        canSum = false;
        yield return new WaitForSeconds(timerSum);
        canSum = true;
    }
}
