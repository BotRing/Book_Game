using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public float[] position;

    public PlayerData (Player player)
    {
        position = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    public PlayerData()
    {
        position = new float[3];

        position[0] = 45;
        position[1] = 0;
        position[2] = 42;
    }
}
