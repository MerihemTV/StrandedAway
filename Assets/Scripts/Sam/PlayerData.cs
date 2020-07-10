using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{

    public string zone;
    public float[] position;
    public int karma;
    public int health;

    public PlayerData (SamController Sam)
    {
        karma = Sam.karma;
        health = Sam.hp;

        position = new float[3];
        position[0] = Sam.transform.position.x;
        position[1] = Sam.transform.position.y;
        position[2] = Sam.transform.position.z;

        zone = SceneManager.GetActiveScene().name;




    }
}
