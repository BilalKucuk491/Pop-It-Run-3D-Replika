using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;

    [SerializeField] AudioClip _blobAudio;
    [SerializeField] AudioClip _bellAudio;
    [SerializeField] AudioSource _audioSource;

    [SerializeField] public bool _isGameSoundState = true;
  
   
    public void PlayBlobSound()
    {
        _audioSource.PlayOneShot(_blobAudio, 0.2f);
    }

    public void PlayBellSound()
    {
        _audioSource.PlayOneShot(_bellAudio, 0.2f);
    }


}
