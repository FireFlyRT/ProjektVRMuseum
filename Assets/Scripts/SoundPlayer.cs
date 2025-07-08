using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource[] soundsList = new AudioSource[2];
    [SerializeField] private float soundTimer = 1.0f;
    [SerializeField] private float quitPercent = 0.5f;
    private int rndIndex = 0;
    private float rndSound;
    private float soundLength;

    private void OnEnable()
    {
        StartCoroutine(RandomBackgroundSound());
    }

    private void OnDisable()
    {
        StopCoroutine(RandomBackgroundSound());
    }

    public IEnumerator RandomBackgroundSound()
    {
        rndIndex = Random.Range(0,soundsList.Length -1);
        soundTimer = Random.Range(1.0f, 15.0f);
        rndSound = Random.Range(0.0f, 1.0f);
        soundLength = 0.0f;
        if (rndSound > quitPercent)
        {
            soundsList[rndIndex].Play();
            soundLength = soundsList[rndIndex].time;
        }
        yield return new WaitForSeconds(soundTimer + soundLength);
    }
}
