using System;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class Break : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject rope;
    public GameObject rope2;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        {
            
        }
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(rope);
            Destroy(rope2);
            Debug.Log("Break activated: Object destroyed on collision with Player.");
        }
    }
}
