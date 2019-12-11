using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary> Класс менеджера камеры. </summary>
    public class CameraManager : MonoBehaviour
    {
        private Camera mainCamera;

        private float sizeSpeed = 3f;

        private void Start()
        {
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        private void Update()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            if (scrollInput != 0f)
            {
                mainCamera.orthographicSize -= scrollInput * sizeSpeed;
            }
        }
    }
}
