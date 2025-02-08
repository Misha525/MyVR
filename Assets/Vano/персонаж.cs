using UnityEngine;

public class CharacterControllerWithCamera3D : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform; // Присвойте ваш объект камеры здесь в инспекторе
    private CharacterController controller;
    private Vector3 moveDirection;
    private float rotationX = 0f;
    private float rotationY = 0f;
    private Rigidbody rb;


    void Start()
    {
         rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("CharacterController not found!");
        }
        if (cameraTransform == null)
        {
            Debug.LogError("Camera transform not assigned!");
        }
        Cursor.lockState = CursorLockMode.Locked; // Блокируем курсор
    }

    void Update()
    {
        if (GlobalVariables.yprav == 1) 
        {
            rb.isKinematic = false;
        // Поворот персонажа с помощью мыши (только по вертикали, чтобы избежать эффекта "кувырка")
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0);


        // Движение персонажа
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime * -1);


        // Поворот камеры с помощью мыши (во всех трёх плоскостях)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseXCamera = Input.GetAxis("Mouse X") * mouseSensitivity; // Добавили поворот по горизонтали для камеры


        rotationX += mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ограничиваем поворот камеры по вертикали

        rotationY += mouseXCamera;


        cameraTransform.localEulerAngles = new Vector3(rotationX, rotationY, 0f); // Теперь используем rotationX и rotationY
        }
        else 
        {
            rb.isKinematic = true;
        }
    }
}
