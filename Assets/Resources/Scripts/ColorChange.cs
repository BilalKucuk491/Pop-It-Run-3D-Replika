using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    GameObject _torusObj, _trailObj;
    ParticleSystem _wallParticle;

    private void Start()
    {
        _torusObj = GameObject.FindGameObjectWithTag("Torus").gameObject;
        _trailObj = GameObject.FindGameObjectWithTag("Trail").gameObject;

        var wallParticle = (GameObject) Instantiate(Resources.Load("Prefabs/WallParticle"),transform);

        _wallParticle = wallParticle.GetComponent<ParticleSystem>();

        _wallParticle.transform.position = transform.position;
        _wallParticle.Play();
        Color _wallColor = GetComponent<SpriteRenderer>().color;

        var main = _wallParticle.GetComponent<ParticleSystem>().main;
        main.startColor = new Color(_wallColor.r, _wallColor.g, _wallColor.b, 1);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Color _wallColor = GetComponent<SpriteRenderer>().color;
            _torusObj.GetComponent<Renderer>().material.color = _wallColor;
            _trailObj.GetComponent<Renderer>().material.color = _wallColor;
            Destroy(this.gameObject, 0.2f);
        }
    }
}
