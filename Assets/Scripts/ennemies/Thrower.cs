using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : Ennemy
{
    public GameObject projectile;

    public float speed;
    public float detectingDistance;
    public float throwingDistance;

    public float timerShots;
    public float timerFreezAfterShot;
    protected bool canShoot = true;
    protected bool canMove = true;

    void Update()
    {
        IA();
        StartCoroutine(ManageHealth());
    }

    protected virtual void IA()
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
    }

    protected IEnumerator shoot(float timeShoot, float timeMove)
    {
        canShoot = false;
        canMove = false;
        animator.speed = 0;
        yield return new WaitForSeconds(0.5f);
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject instantiatedProjectile = 
            Instantiate(projectile, transform.position + (target.position - transform.position).normalized*1.9f, transform.rotation);
        instantiatedProjectile.GetComponent<ProjectileBehaviour>().direction = direction;
        instantiatedProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        yield return new WaitForSeconds(timeMove);
        animator.speed = 1;
        canMove = true;
        yield return new WaitForSeconds(timeShoot - timeMove);
        canShoot = true;
    }
}
