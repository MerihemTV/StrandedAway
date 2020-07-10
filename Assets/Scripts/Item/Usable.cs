using UnityEngine;

[CreateAssetMenu(fileName = "New usable", menuName = "Inventory/item/usable")]
public class Usable : Item
{
    private Dialogue premierePage = new Dialogue();

    public override void use()
    {
        base.use();
        premierePage.name = "Le Karma pour les nuls";
        premierePage.portrait = icon;
        premierePage.sentences = new string[] { "\"Le Karma pour les nuls, de Jean - Michel Ying et Patrique Yang\""};
        FindObjectOfType<DialogueManager>().StartDialogue(premierePage);
    }
}