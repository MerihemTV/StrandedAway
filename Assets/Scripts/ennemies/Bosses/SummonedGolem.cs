using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedGolem : Following_Thrower
{
    static int deathcount = 0;
    public GameObject drop;

    protected override void IA()
    {
        base.IA();
        if (health <= 0)
        {
            Debug.Log("deathcount : " + deathcount);
            deathcount++;
            if (deathcount == 2)
            {
                deathcount = 0;
                Instantiate(drop, transform.position, transform.rotation);
                ManageOffrande.actualOffrande = ManageOffrande.typeOffrande.boss3;
                if (SamController.instance.karma >= ManageOffrande.instance.minimumKarma)
                    ManageOffrande.EnoughKarma3 = true;
            }
        }
    }


}
