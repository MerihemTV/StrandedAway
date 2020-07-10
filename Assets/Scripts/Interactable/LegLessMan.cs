using UnityEngine;

public class LegLessMan : Interactable
{
    public int gainKarma;
    public Sprite SpriteWithLeg;
    private static bool hasLeg = false;

    private void Awake()
    {
       if (hasLeg)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteWithLeg;
        }
    }


    public override void interact()
    {
        if (!hasLeg)
        {
            if (Inventory.instance.hasInInventory("jambe de bois", 1))
            {
                SamController.instance.karma += gainKarma;
                Debug.Log("sam's karma : " + SamController.instance.karma);
                Inventory.instance.removeItem("jambe de bois");
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteWithLeg;
                hasLeg = true;
            }
            else
                Debug.Log("you don't have the wooden leg");
        }
        else
        {
            Debug.Log("I can finally walk with this wooden leg, thank you very much !");
        }
    }
}
