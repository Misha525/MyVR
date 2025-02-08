using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Массив камер для переключения
    private int currentCameraIndex = 0;

    void Start()
    {
        // Проверка на наличие камер
        if (cameras == null || cameras.Length == 0)
        {
            Debug.LogError("No cameras assigned to CameraSwitcher!");
            return;
        }
        // Выключение всех камер кроме первой
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        cameras[0].gameObject.SetActive(true);
    }

    void Update()
    {
        // Переключение камер по нажатию клавиш
        if (Input.GetKeyDown(KeyCode.C)) // Измените KeyCode.C на нужную клавишу
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        // Выключение текущей камеры
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Переключение на следующую камеру
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Включение следующей камеры
        cameras[currentCameraIndex].gameObject.SetActive(true);
    }
}
