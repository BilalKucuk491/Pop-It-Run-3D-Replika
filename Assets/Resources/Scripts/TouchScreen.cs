using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TouchScreen : MonoBehaviour, IPointerDownHandler
{
    UIManager _uIManager;
    AnimatorManager _animatorManager;
    private void Start()
    {
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _animatorManager = GameObject.Find("GameManager").GetComponent<AnimatorManager>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (UIManager._isNewLevel)
        {
            Destroy(_uIManager._playText, 0.1f);
            UIManager._isNewLevel = false;
            Movement._isMovement = true;
            _animatorManager.PlayRunning();
        }
    }

}
