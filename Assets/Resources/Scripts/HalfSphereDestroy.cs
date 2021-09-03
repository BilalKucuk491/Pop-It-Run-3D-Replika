using UnityEngine;

public class HalfSphereDestroy : MonoBehaviour
{
    UIManager _uiManager;
    SoundManager _soundManager;  
    
    [SerializeField] GameObject _TrailObj;
    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HalfSphere"))
        {
            Destroy(other.gameObject, 0.1f);
            _soundManager.PlayBlobSound();
            UIManager._coinScore += 1;
            //Ball Particle effect
            _uiManager.CreateBallParticle(other);
            _uiManager.CreatePopUpText(transform);

        }
    }
}
