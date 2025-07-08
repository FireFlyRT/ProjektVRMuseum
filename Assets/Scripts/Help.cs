using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Help : MonoBehaviour
{
    [SerializeField] private VideoPlayer vidPlayer;
    [SerializeField] private VideoClip vidClip;
    [SerializeField] private SoundPlayer sound;
    [SerializeField] private AudioSource ambientSound;

    #region ButtonFunctions
    public void PlayVideo()
    {
        StopCoroutine(sound.RandomBackgroundSound());
        ambientSound.mute = true;
        StartCoroutine(PlayCo());       
    }
    public void Skip()
    {
        StopCoroutine(PlayCo());
        ReactivateSound();
    }
    #endregion

    private IEnumerator PlayCo()
    {
        vidPlayer.Play();
        Time.timeScale = 0.0f;
        yield return new WaitForSeconds((float)vidClip.length);
        ReactivateSound();
    }
    private void ReactivateSound()
    {
        vidPlayer.Stop();
        Time.timeScale = 1.0f;
        StartCoroutine(sound.RandomBackgroundSound());
        ambientSound.mute = false;
    }
}
