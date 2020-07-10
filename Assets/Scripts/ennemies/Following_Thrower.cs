using UnityEngine;

public class Following_Thrower : Thrower
{ 
    protected override void IA()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= detectingDistance && canMove)
        {
            animator.SetBool("start_moving", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            SpriteAnimation();
        }
        if (distance <= throwingDistance && canShoot)
        {
            StartCoroutine(shoot(timerShots, timerFreezAfterShot));
        }
        if (distance > detectingDistance)
        {
            animator.SetBool("start_moving", false);
        }
    }
}
