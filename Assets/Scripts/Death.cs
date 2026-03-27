using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public static bool hasDieded = false;

    private void Start()
    {
        Debug.Log("Death script initialized. hasDieded: " + hasDieded);
        if (hasDieded)
        {
            hasDieded = false;
            transform.localPosition = new Vector3(47, 5, 41);
            Player.instance.position = new float[] { 47, 5, 41 };
            SaveSystem.SavePlayer(Player.instance);
        }
    }

    private void Update()
    {
        if (transform.position.y < -60f)
        {
            Debug.Log("Object fell below threshold, resetting position.");
            hasDieded = true;
            Player.instance.position = new float[] { 47, 5, 41 };
            SaveSystem.SavePlayer(Player.instance);
            if (TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            SceneManager.LoadScene(2);
        }
    }

}
