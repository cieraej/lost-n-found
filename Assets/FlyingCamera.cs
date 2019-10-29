using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public float speed = .1f;

    private float SimulationRate = 60f;
    CharacterController characterController;

    public void ResetPosition()
    {
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
        
    }
    private void Start()
    {
        characterController = this.GetComponent<CharacterController>();
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            characterController.Move(Camera.main.transform.forward.normalized * speed);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }

     
    }

    private void LateUpdate()
    {
        Vector3 euler = transform.rotation.eulerAngles;

        float rotateInfluence = SimulationRate * Time.deltaTime;

        Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        Vector2 altSecondaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (secondaryAxis.sqrMagnitude < altSecondaryAxis.sqrMagnitude)
        {
            secondaryAxis = altSecondaryAxis;
        }

        euler.y += secondaryAxis.x * rotateInfluence;


        transform.rotation = Quaternion.Euler(euler);
    }


}
