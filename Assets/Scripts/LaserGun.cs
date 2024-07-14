using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;

    private AudioSource laserAudioSource;
    private RaycastHit hit;

    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    public void LaserGunFired()
    {
        //animate
        laserAnimator.SetTrigger("Fire");

        //Play Laser SFX
        laserAudioSource.PlayOneShot(laserSFX);

        //Raycast
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800f))
        {
            if (hit.transform.GetComponent<Asteroidhit>() != null)
            {
                hit.transform.GetComponent<Asteroidhit>().AsteroidDestroyed();
            }
        }
    }
}
