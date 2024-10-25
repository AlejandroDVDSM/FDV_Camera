using Cinemachine;
using UnityEngine;

public class CinemachineZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] private float _zoom;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
            _vcam.m_Lens.OrthographicSize += _zoom;
        else if (Input.GetKey(KeyCode.W))
        {
            if (_vcam.m_Lens.OrthographicSize - _zoom > 0.0)
                _vcam.m_Lens.OrthographicSize -= _zoom;
        }
    }
}
