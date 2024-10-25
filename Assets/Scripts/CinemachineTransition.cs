using Cinemachine;
using UnityEngine;

public class CinemachineTransition : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _cinemachineBrain;
    [SerializeField] private CinemachineVirtualCamera _vcam;
    
    [SerializeField] private GameObject _player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.Equals(_player))
            return;

        _cinemachineBrain.ActiveVirtualCamera.Priority = 9;
        _vcam.Priority = 10;
    }
}
