using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public float speed = .1f;
    Rigidbody rb;
    CharacterController characterController; 
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        characterController = this.GetComponent<CharacterController>(); 
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            // rb.AddForce(Camera.main.transform.forward.normalized * speed);
            characterController.Move(Camera.main.transform.forward.normalized * speed);
        }
        else 
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

}
