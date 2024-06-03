using Cinemachine;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private Camera cameraSecond;

    private int onOff;
    private void Start()
    {
        onOff = 0;
        Switch();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onOff = 1 - onOff;

            Switch();
        }
    }
    private void Switch()
    {
        if (onOff == 0)
        {
            TurnOffCamera(cameraSecond.gameObject);
        }
        else
        {
            TurnOnCamera(cameraSecond.gameObject);
        }
    }
    private void TurnOnCamera(GameObject camera)
    {
        camera.SetActive(true);
    }
    private void TurnOffCamera(GameObject camera)
    {
        camera.SetActive(false);
    }
}
