using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Movement : MonoBehaviour
{

    [SerializeField] float _speed = 1;
    public static bool _isMovement = true;
    SoundManager _soundManager;
    UIManager _uIManager;
    GameManager _gameManager;
    AnimatorManager _animatorManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _animatorManager = GameObject.Find("GameManager").GetComponent<AnimatorManager>();
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    void Update()
    {
        if (_isMovement)
        {
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _isMovement = false;
            _gameManager.DestroyRope();
            
            StartCoroutine(StoppingRun());
            
            var _oldPos = transform.position;
            var _newPos = _oldPos-transform.position;

            transform.DOMove(new Vector3(_newPos.x, _newPos.y + 0.85f, _newPos.z + 178), 0.8f).OnStepComplete
                (() => _gameManager.FinishPart(transform)).OnComplete
                (() => _animatorManager.DancingAnimation());
        }
    }

   
    
   
    IEnumerator StoppingRun()
    {
        yield return new WaitForSeconds(0.2f);
        _animatorManager.StopAnimation();
    }
}
