using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class ParticlesControl : MonoBehaviour
{
    public ParticleSystem loseEffect;
    public ParticleSystem winEffect1;
    public ParticleSystem winEffect2;

    public AudioSource bgMusic;

    public AudioSource winFireworks;
    public AudioSource winSound;
    public AudioSource loseRain;
    public AudioSource loseThunder;
    public AudioSource loseSound;

    public LightControl pointLightController;

    void Start()
    {
        if (bgMusic != null && !bgMusic.isPlaying)
        {
            bgMusic.Play();
        }

        loseEffect.Stop();
        winEffect1.Stop();
        winEffect2.Stop();

    }

    public void PlayLoseEffect()
    {
        loseEffect.Play();

        loseRain.Play();
        loseThunder.Play();
        loseSound.Play();

        pointLightController.DarkenLight(targetIntensity: 0.1f, targetColor: Color.red, duration: 4f);
    }
    public void PlayWinEffect()
    {
        winEffect1.Play();
        winEffect2.Play();

        winFireworks.Play();
        winSound.Play();
    }



    public void StopLoseEffect()
    {
        loseEffect.Stop();

        loseRain.Stop();
        loseSound.Stop();
        loseThunder.Stop();
        pointLightController.ResetLight();

    }
    
    public void StopWinEffect()
    {
        winEffect1.Stop();
        winEffect2.Stop();

        winFireworks.Stop();
        winSound.Stop();

    }
}
