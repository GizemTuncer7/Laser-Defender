using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damagingClip;
    [SerializeField] [Range(0f, 1f)] float damagingVolume = 1f;
     static AudioPlayer instance;
    
    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        
        if(instance!=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }
    public void PlayDamagingClip()
    {
       PlayClip(damagingClip, damagingVolume);
    }
    void PlayClip(AudioClip clip,float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
