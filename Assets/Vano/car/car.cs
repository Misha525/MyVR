using UnityEngine;

public class SimpleCar : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public Transform cameraTransform;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        if (GlobalVariables.yprav == 2) 
        {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime * -1;
        transform.Translate(0, 0, move);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) 
        {
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime * -5;
        transform.Rotate(0, turn, 0);
        }

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseXCamera = Input.GetAxis("Mouse X") * mouseSensitivity; 
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -45f, 90f);
        rotationY += mouseXCamera;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);
        }
    }
}