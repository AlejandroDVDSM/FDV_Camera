using Cinemachine;
using UnityEngine;

public class CinemachineCameraShaker : MonoBehaviour
{
    private CinemachineImpulseSource _impulseSource;

    private void Start()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        Invoke(nameof(ShakeCam), 1);
    }

    private void ShakeCam()
    {
        _impulseSource.GenerateImpulse();
    }
}
