using Game;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    [SerializeField]
    private float motorSpeed;
    [SerializeField]
    private float forwardWheelMultiplier;
    public float tiltTorque = 500f;

    [SerializeField]
    private WheelJoint2D backWheel;
    [SerializeField]
    private WheelJoint2D forwardWheel;
    private Rigidbody2D rb;

    // input
    private Vector2 verticalInput;
    private Vector2 horizontalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float accelerationInput = InputManager.Instance.verticalAxis;

        if (accelerationInput != 0)
        {
            JointMotor2D motor = new JointMotor2D()
            {
                motorSpeed = motorSpeed * -accelerationInput,
                maxMotorTorque = 10000
            };
            backWheel.motor = motor;

            //motor.motorSpeed *= forwardWheelMultiplier;
            //forwardWheel.motor = motor;
        }
        else
        {
            backWheel.useMotor = false;
            forwardWheel.useMotor = false;
        }

        // Управление наклоном
        float tilt = -InputManager.Instance.horizontalAxis;
        rb.AddTorque(tilt * tiltTorque * Time.deltaTime);
    }
}
