using System.Collections;
using UnityEngine;

public class BossLezardMan : LezardMan
{
    public Transform CenterWind;
    public float TimeWind;
    public float durationWind;
    private bool CanWind;
    private bool inWindAttack = false;
    private bool inPosition = false;
    public float WindForce;
    private Vector2 prevDirection = new Vector2(0,0);
    public GameObject drop;
    public bool one = true;

    protected override void IA()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (!inWindAttack)
        {
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
            if (distance <= detectingDistance && !CanSum && !CanWind && firstMeet)
            {
                StartCoroutine(WaitToSum());
                StartCoroutine(WaitToWind());
                firstMeet = false;
            }
            if (CanSum && distance <= detectingDistance)
            {
                summon();
                StartCoroutine(WaitToSum());
            }
            if (CanWind && distance <= detectingDistance)
            {
                inWindAttack = true;
                StartCoroutine(WaitToWind());
            }
        }
        else if (!inPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, CenterWind.position, speed * Time.deltaTime);
            if (transform.position == CenterWind.position)
            {
                Debug.Log("in position");
                inPosition = true;
                animator.SetBool("start_moving", false);
                StartCoroutine(makeWind());
            }
        }
        if (health <= 0)
        {
            if (one)
            {
                one = false;
                Instantiate(drop, transform.position, transform.rotation);
            }
            ManageOffrande.actualOffrande = ManageOffrande.typeOffrande.boss4;
        }
    }

    private void FixedUpdate()
    {
        if (inWindAttack && inPosition)
        {
            GameObject Sam = GameObject.Find("Sam");
            Transform SamTransform = Sam.GetComponent<Transform>();
            Vector2 direction;
            direction.x = SamTransform.position.x - CenterWind.position.x;
            direction.y = SamTransform.position.y - CenterWind.position.y;
            direction = direction.normalized;
            
            Sam.GetComponent<Rigidbody2D>().AddForce(direction * WindForce, ForceMode2D.Force);
            Sam.GetComponent<Rigidbody2D>().AddForce(-prevDirection * WindForce, ForceMode2D.Force);
            prevDirection = direction;
        }
    }

    IEnumerator makeWind()
    {
        yield return new WaitForSeconds(durationWind);
        GameObject.Find("Sam").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        inWindAttack = false;
        inPosition = false; ;
    }

    IEnumerator WaitToWind()
    {
        CanWind = false;
        yield return new WaitForSeconds(TimeWind);
        CanWind = true;
    }


}
