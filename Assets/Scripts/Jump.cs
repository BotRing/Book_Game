using System;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

public class FloatRotateLaunch : MonoBehaviour
{
    public Rigidbody rb;
    public float floatUpSpeed = 0.5f;
    public float rotationSpeed = 45f;
    public float launchSpeed = 15f;

    private Coroutine floater;
    private bool isFloating = false;
    private bool coolDown = false;

    private bool hasJumpeded = false;
    private bool hasLefted = false;
    private bool hasRighted = false;


    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        floater = null;
    }

    void Update()
    {
        if (hasJumpeded && !coolDown)
        {
            hasJumpeded = false;
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
        if (hasLefted)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
        }
        else if (hasRighted)
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

    public void NotTheOtherTwo(InputAction.CallbackContext context)
    {
        hasJumpeded = context.ReadValueAsButton();
    }

    public void Left(InputAction.CallbackContext context)
    {
        hasLefted = context.ReadValueAsButton();
    }

    public void Rightinator(InputAction.CallbackContext context)
    {
        hasRighted = context.ReadValueAsButton();
    }
}
