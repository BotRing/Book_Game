using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.tag == "Tower")
        {
            Debug.Log("You won!");
            
            SceneManager.LoadScene(3);
        }
    }
}
