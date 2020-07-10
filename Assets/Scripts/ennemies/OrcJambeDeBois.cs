using UnityEngine;



public class OrcJambeDeBois : Thrower
{
    public GameObject jambeDeBois;
    private bool dropped = false;
    private void Update()
    {
        StartCoroutine(ManageHealth());
        IA();
        if (health <= 0 && !dropped)
        {
            dropped = true;
            Vector3 pos = transform.position;
            Quaternion rotation = transform.rotation;
            jambeDeBois = Instantiate(jambeDeBois, pos, rotation);
        }
    }
}
