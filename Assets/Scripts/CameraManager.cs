using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

   public static bool map = false;

    public Camera cam = null;
    public Camera mapCam = null;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Spaceship" || SceneManager.GetActiveScene().name != "SpaceShipSpace")
        {
            if (cam != null && mapCam != null)
            {
                cam.enabled = true;
                mapCam.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "SpaceShip" || SceneManager.GetActiveScene().name != "SpaceShipSpace")
        {
            if (Input.GetButtonDown("Map"))
            {
                cam.enabled = !cam.enabled;
                mapCam.enabled = !mapCam.enabled;
                map = !map;
            }

            if (Input.GetButtonDown("Close") && map == true)
            {
                cam.enabled = !cam.enabled;
                mapCam.enabled = !mapCam.enabled;
                map = !map;
            }
        }
    }
}
