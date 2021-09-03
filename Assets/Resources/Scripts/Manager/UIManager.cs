using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _txtCoinScore;
    [SerializeField] Text _txtLevel;
    [SerializeField] GameObject _popUpTextPrefab;
    [SerializeField] ParticleSystem _ballParticle;
    [SerializeField] GameObject _confettiPrefab;
    [SerializeField] Material _diamondBallMat;
    Text _wowText;
    public Text _playText;
    Image _part1, _part2, _part3;

    public static int _coinScore = 0;
    public static int _levelNum = 1;
    public static bool _isNewLevel = false;
    GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        _txtCoinScore.text = ReturnCointScore() + "";
    }

   
    public void CreatePopUpText(Transform _transform)
    {
        GameObject tmp = Instantiate(_popUpTextPrefab, _transform.position + (Vector3.right * 2f), Quaternion.identity, _transform);
        Destroy(tmp, 0.1f);

    } // CreatePopUpText

    public void CreateConfetti(Transform _transform)
    {
        var oldPos = _transform.position;
        var newPos = oldPos - _transform.position;
        GameObject _confettiParticle = Instantiate(_confettiPrefab, new Vector3(oldPos.x, oldPos.y + 6, oldPos.z), Quaternion.identity);
        Destroy(_confettiParticle, 5f);
    }//Create Confetti

    public void CreateBallParticle(Collider other)
    {
        _ballParticle.transform.position = other.transform.position;
        _diamondBallMat.color = other.GetComponent<Renderer>().material.color;
        _ballParticle.gameObject.SetActive(true);
        _ballParticle.Play();

    }//Ball Particul effect

    public void WowText()
    {
        var wowText = (GameObject)Instantiate(Resources.Load("Prefabs/wowTxt"));

        _wowText = wowText.GetComponent<Text>();
        _wowText.transform.DOScale(1.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);
        _wowText.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        Destroy(wowText, 2.5f);
    }

    public void TapToPlayText()
    {
        var playText = (GameObject)Instantiate(Resources.Load("Prefabs/PlayText"));

        _playText = playText.GetComponent<Text>();
        _playText.transform.DOScale(1.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);
        _playText.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        _playText.gameObject.tag = "TapPlay";
    }

    public IEnumerator ActiveBlueParts()
    {
        yield return new WaitForSeconds(3.5f);
        var parca1 = (GameObject)Instantiate(Resources.Load("Prefabs/part1"), GameObject.FindGameObjectWithTag("Canvas").transform);
        _part1 = parca1.GetComponent<Image>();
        _part1.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        var parca2 = (GameObject)Instantiate(Resources.Load("Prefabs/part2"), GameObject.FindGameObjectWithTag("Canvas").transform);
        _part2 = parca2.GetComponent<Image>();
        _part2.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        var parca3 = (GameObject)Instantiate(Resources.Load("Prefabs/part3"), GameObject.FindGameObjectWithTag("Canvas").transform);
        _part3 = parca3.GetComponent<Image>();

        _part3.gameObject.SetActive(true);
        _gameManager.LookAnimation();
        yield return new WaitForSeconds(0.5f);
        Destroy(parca3, 1);
         yield return new WaitForSeconds(0.5f);
        Destroy(parca2, 1);
         yield return new WaitForSeconds(0.5f);
        Destroy(parca1, 1);
        yield return new WaitForSeconds(0.8f);
        TapToPlayText();
        yield return new WaitForSeconds(0.01f);
        //Yeni levelde level numarasýný ve level skorlarýný yeni deðerler atadýk.
        _coinScore = 0;
        _levelNum += 1;
        _txtLevel.text = "LVL " + ReturnTxtLevel().ToString();
        _isNewLevel = true;
    }

    public int ReturnCointScore()
    {
        return _coinScore;
    } 
    
    public int ReturnTxtLevel()
    {
        return _levelNum;
    }
}
