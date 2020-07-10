using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGolem : Following_Thrower
{
    public GameObject littleGolem;
    public GameObject drop;
    protected override void IA()
    {
        base.IA();
        if (health <= 0)
        {
            GameObject golem1 = Instantiate(littleGolem, transform.position, transform.rotation);
            GameObject golem2 = Instantiate(littleGolem, transform.position, transform.rotation);
            golem1.GetComponent<SummonedGolem>().startInvulnerability();
            golem2.GetComponent<SummonedGolem>().startInvulnerability();
            golem1.GetComponent<SummonedGolem>().drop = drop;
            golem2.GetComponent<SummonedGolem>().drop = drop;

        }
    }

}
