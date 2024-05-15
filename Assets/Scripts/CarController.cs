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


//using UnityEngine;

//public class CarController : MonoBehaviour
//{
//    public float maxSpeed = 20f; // Maximum speed of the car
//    public float acceleration = 5f; // Acceleration rate
//    public float deceleration = 10f; // Deceleration rate

//    public float rotationSpeed = 100f;

//    private Rigidbody rb;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
//    }

//    void FixedUpdate()
//    {
//        float moveHorizontal = Input.GetAxis("Horizontal");
//        float moveVertical = Input.GetAxis("Vertical");

//        // Accelerate forward when "W" is pressed
//        if (moveVertical > 0)
//        {
//            rb.velocity += transform.forward * acceleration * Time.fixedDeltaTime;
//            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
//        }
//        // Brake when "S" is pressed
//        else if (moveVertical < 0)
//        {
//            rb.velocity -= rb.velocity * deceleration * Time.fixedDeltaTime;
//        }

//        // Calculate rotation based on input and rotation speed
//        Quaternion rotation = Quaternion.Euler(0.0f, moveHorizontal * rotationSpeed * Time.deltaTime, 0.0f);

//        // Apply rotation
//        rb.MoveRotation(rb.rotation * rotation);
//    }
//}

