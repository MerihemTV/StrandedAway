using System.Collections;
using UnityEngine;

public class Follow_Charge : Ennemy
{
    public float speed;
    public float detectingDistance;
    public float chargeEngagedDistance;
    public float chargeSpeed;
    public float chargeDuration;
    public float timeBetweenCharge;
    private Vector3 ChargeDirection;
    private bool isCharging = false;
    private bool canCharge = true;



    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ManageHealth());
        if (health > 0)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            if (distance <= detectingDistance && !isCharging)
            {
                animator.SetBool("start_moving", true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                SpriteAnimation();
            }
            else if (isCharging)
            {
                transform.position = Vector2.MoveTowards(transform.position, ChargeDirection, chargeSpeed * Time.deltaTime);
            }
            if (distance <= chargeEngagedDistance && canCharge)
                StartCoroutine(charge(gameObject));
            if (distance > detectingDistance)
            {
                animator.SetBool("start_moving", false);
            }
        }   
    }

    IEnumerator charge(GameObject go)
    {
        canCharge = false;
        isCharging = true;
        float temp = chargeSpeed;
        chargeSpeed = 0;
        yield return new WaitForSeconds(0.5f);
        chargeSpeed = temp;
        ChargeDirection = target.position;
        yield return new WaitForSeconds(chargeDuration);
        isCharging = false;
        yield return new WaitForSeconds(timeBetweenCharge);
        canCharge = true;
    }

}

