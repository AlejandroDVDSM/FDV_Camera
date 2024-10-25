using UnityEngine;

public class CinemachineBulletTime : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private bool _bulletTime;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.Equals(_player)) 
            return;

        Time.timeScale = _bulletTime ? .5f : 2.0f;
    }
}
