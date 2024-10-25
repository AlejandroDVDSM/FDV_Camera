using Cinemachine;
using UnityEngine;

public class CinemachineSwitchVCams : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    
    [SerializeField] private CinemachineVirtualCamera _vcam1;
    [SerializeField] private CinemachineVirtualCamera _vcam2;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !_vcam1.gameObject.activeSelf)
        {
            _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _vcam1.gameObject.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha2) && !_vcam2.gameObject.activeSelf)
        {
            _cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
            _vcam2.gameObject.SetActive(true);            
        }
    }
}