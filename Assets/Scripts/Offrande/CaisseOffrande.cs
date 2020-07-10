using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaisseOffrande : Interactable
{
    public List<Item> items_offrande;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    new private void Start()
    {
        base.Start();
        if (SceneManager.GetActiveScene().name != "Camp")
        {
            Debug.Log("Awake : false");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Awake : true");
            gameObject.SetActive(true);
        }
    }
    public override void interact()
    {
        ManageOffrande.numberOfOffrandeEmpty++;
        int numberOfItem = items_offrande.Count;
        for (int i = 0; i< numberOfItem; i++)
        {
            if (!Inventory.instance.addItem(items_offrande[0]))
            {
                Debug.Log("trop d'objet dans l'inventaire, vous ne pouvez pas récupérer l'offrande");
                return;
            }
            else
            {
                items_offrande.Remove(items_offrande[0]);
            }
        }
        if (items_offrande.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
