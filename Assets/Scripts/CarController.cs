using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical * speed);
        Quaternion rotation = Quaternion.Euler(0.0f, moveHorizontal * rotationSpeed * Time.deltaTime, 0.0f);

        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);
    }
}
