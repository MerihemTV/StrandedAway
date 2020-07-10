using UnityEngine;

public class Chicken : Ennemy
{
    public int baisseKarma;
    private bool alive = true;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ManageHealth());
        if (health <= 0)
        {
            if (alive)
            {
                SamController.instance.karma -= baisseKarma;
                alive = false;
            }
        }
    }
}
