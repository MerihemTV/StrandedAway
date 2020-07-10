using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageOffrande : MonoBehaviour
{
    public List<Item> items_offrande1;
    public List<Item> items_offrande2;
    public List<Item> items_offrande3;
    public List<Item> items_offrande4;

    public GameObject CaisseGO;

    private GameObject caisse1;
    private GameObject caisse2;
    private GameObject caisse3;
    private GameObject caisse4;

    public static bool EnoughKarma1 = false;
    public static bool EnoughKarma2 = false;
    public static bool EnoughKarma3 = false;

    public static float numberOfOffrandeEmpty = 0;

    public enum typeOffrande { boss1, boss2, boss3, boss4, none };
    public static typeOffrande actualOffrande = typeOffrande.none;

    public int minimumKarma = 10;

    public Dialogue premiereOffrande;
    private static bool first = true;

    public static ManageOffrande instance;
    #region singleton
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("plus d'une instance de de manageOffrande trouvé");
            return;
        }
        instance = this;
    }

    #endregion

    private void Start()
    {
        if (SamController.instance.karma >= minimumKarma)
        {
            switch (actualOffrande)
            {
                case typeOffrande.boss1:
                    launchDialogue();
                    instantiateCaisse1();
                    break;
                case typeOffrande.boss2:
                    launchDialogue();
                    instantiateCaisse2();
                    break;
                case typeOffrande.boss3:
                    launchDialogue();
                    instantiateCaisse3();
                    break;
                case typeOffrande.boss4:
                    launchDialogue();
                    instantiateCaisse4();
                    break;
            }
        }
    }

    private void instantiateCaisse1()
    {
        if (numberOfOffrandeEmpty < 1 && EnoughKarma1)
        {
            caisse1 = Instantiate(CaisseGO);
            caisse1.GetComponent<CaisseOffrande>().items_offrande = items_offrande1;
        }
    }

    private void instantiateCaisse2()
    {
        if (numberOfOffrandeEmpty < 2 && EnoughKarma2)
        {
            caisse2 = Instantiate(CaisseGO);
            caisse2.GetComponent<CaisseOffrande>().items_offrande = items_offrande2;
            
        }
        instantiateCaisse1();
    }

    private void instantiateCaisse3()
    {
        if (numberOfOffrandeEmpty < 3 && EnoughKarma3)
        {
            caisse3 = Instantiate(CaisseGO);
            caisse3.GetComponent<CaisseOffrande>().items_offrande = items_offrande3;
        }
        instantiateCaisse2();
    }

    private void instantiateCaisse4()
    {
        if (numberOfOffrandeEmpty < 4)
        {
            caisse4 = Instantiate(CaisseGO);
            caisse4.GetComponent<CaisseOffrande>().items_offrande = items_offrande4;
        }
        instantiateCaisse3();
    }

    private bool isCaisseEmpty(CaisseOffrande caisse)
    {
        if (caisse.items_offrande.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void launchDialogue()
    {
        if (first)
        {
            first = false;
            FindObjectOfType<DialogueManager>().StartDialogue(premiereOffrande);
        }
    }
}
