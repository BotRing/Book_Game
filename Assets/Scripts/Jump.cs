using UnityEngine;
using System.Collections;

public class FloatRotateLaunch : MonoBehaviour
{
    public Rigidbody rb;
    public float floatUpSpeed = 0.5f;
    public float rotationSpeed = 45f;
    public float launchSpeed = 15f;

    private Coroutine floater;
    private bool isFloating = false;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isFloating && floater == null)
            {
                floater = StartCoroutine(FloatHoverThenReady());
            }
            else
            {
                LaunchForward();
            }
        }

        if (isFloating)
        {
            HandleRotationInput();
        }
    }

    void FixedUpdate()
    {
        if (isFloating)
        {
            //rb.linearVelocity = new Vector3(rb.linearVelocity.x, floatUpSpeed, rb.linearVelocity.z);
        }
    }

    private IEnumerator FloatHoverThenReady()
    {
        isFloating = true;
        rb.useGravity = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, floatUpSpeed, rb.linearVelocity.z);

        yield return new WaitForSeconds(2f);

        rb.linearVelocity = Vector3.zero; 
        yield return new WaitForSeconds(6f);
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
}
