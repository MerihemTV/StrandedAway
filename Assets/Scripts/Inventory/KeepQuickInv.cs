using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepQuickInv : MonoBehaviour
{
    #region singleton
    public static KeepQuickInv instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("more than 1 instance of QuickInventory");
            return;

        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion
}
