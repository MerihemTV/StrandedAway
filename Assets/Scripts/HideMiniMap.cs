using UnityEngine;
using UnityEngine.SceneManagement;

public class HideMiniMap : MonoBehaviour
{
    private void Start()
    {
        GameObject Minimap = GameObject.Find("Minimap");
        if (SceneManager.GetActiveScene().name == "Spaceship" || SceneManager.GetActiveScene().name == "SpaceShipSpace")
        {
            Minimap.SetActive(false);
        }
        else
        {
            Minimap.SetActive(true);
        }
    }
}
