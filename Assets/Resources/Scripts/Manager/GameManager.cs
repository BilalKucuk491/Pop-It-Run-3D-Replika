using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject _rope23;

    SoundManager _soundManager;
    UIManager _uIManager;
    GameObject _player;
    AnimatorManager _animatorManager;
    LevelManager _levelManager;

    private void Start()
    {
        _uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        _animatorManager = GameObject.Find("GameManager").GetComponent<AnimatorManager>();
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _player = GameObject.Find("Player").gameObject;


        _levelManager.CreateLevel("1");
        
    }

    public void DestroyRope()
    {
        _rope23 = GameObject.FindGameObjectWithTag("Rope23").gameObject;
        Destroy(_rope23.gameObject, 0.25f);
    }

    

    public void FinishPart(Transform _transform)
    {
        _transform.DORotate(new Vector3(0, -180, 0), 1f);
        _uIManager.CreateConfetti(_transform);
        _soundManager.PlayBellSound();
        _uIManager.WowText();

       
        StartCoroutine(_uIManager.ActiveBlueParts());

        //New level created and last level destroyed

        _levelManager.DestroyLastLevel((_uIManager.ReturnTxtLevel()-1).ToString());
        StartCoroutine(NewLevelCreate());
    }

    public IEnumerator NewLevelCreate()
    {
        yield return new WaitForSeconds(7.1f);
        _levelManager.CreateLevel((_uIManager.ReturnTxtLevel() + 1).ToString());
    }
    public void LookAnimation()
    {
        _player.transform.position = new Vector3(0, 0.85f, -20);
        _player.transform.rotation = new Quaternion(0, 0, 0, 0);
        _animatorManager.StopAnimation();
    }
}
