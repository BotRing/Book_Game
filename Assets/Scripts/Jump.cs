using System;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class FloatRotateLaunch : MonoBehaviour
{
    public Rigidbody rb;
    public float floatUpSpeed = 0.5f;
    public float rotationSpeed = 45f;
    public float launchSpeed = 15f;

    private Coroutine floater;
    private bool isFloating = false;
    private bool coolDown = false;



    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !coolDown)
        {
            
            if (!isFloating && floater == null)
            {
                floater = StartCoroutine(FloatHoverThenReady());
            }
            else
            {
                LaunchForward();
                coolDown = true;
                Invoke("CoolDown", 4f);
            }
        }

        if (isFloating)
        {
            HandleRotationInput();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bridge"))
        {
            CoolDown();
            Debug.Log("Cooldown deactivated.");
        }
    }



    private IEnumerator FloatHoverThenReady()
    {
        isFloating = true;
        rb.useGravity = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, floatUpSpeed, rb.linearVelocity.z);

        yield return new WaitForSeconds(2f);

        rb.linearVelocity = Vector3.zero; 
        yield return new WaitForSeconds(10f);
        isFloating = false;
        rb.useGravity = true;
        floater = null;
    }

    private void HandleRotationInput()
    {
        // Rotate the object based on player input (A/D keys)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime, Space.Self);
        }
    }

    private void LaunchForward()
    {
        isFloating = false;
        rb.useGravity = true;
        StopCoroutine(floater);
        floater = null;

        Vector3 launchDirection = transform.up;

        rb.linearVelocity = launchDirection * launchSpeed;
    }
   
    void CoolDown()
    {
        coolDown = false;
        isFloating = false;
        rb.useGravity = true;
        StopCoroutine(FloatHoverThenReady());
    }
}
