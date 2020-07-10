using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnnemy : Ennemy
{
    public float speed;
    public float detectingDistance;

    void Update()
    {
        StartCoroutine(ManageHealth());
        if (health>0)
        {
            IA();
        }
    }

    protected virtual void IA()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= detectingDistance)
        {
            animator.SetBool("start_moving", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            SpriteAnimation();
        }
        else
        {
            animator.SetBool("start_moving", false);
        }
    }
}
