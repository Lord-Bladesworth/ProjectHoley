using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    int Timer;
    [SerializeField]
    Text TimerText;
    [SerializeField]
    Slider VolumeSlider;
    public GameStageData StageData;
    SpectrumEngine spectrumEngine;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
        }
        if(GetComponent<SpectrumEngine>() ==null)
        {
            gameObject.AddComponent<SpectrumEngine>();
        }
        audioSource = GetComponent<AudioSource>();
        spectrumEngine = GetComponent<SpectrumEngine>();

       
        ReinitializeCanvas();

    }

    //called by the gamemanager
    public void ReinitializeCanvas()
    {
        GamePause();
        GameManager.PauseOrder();
        StopCoroutine("TimerCountdown");
        audioSource.clip = StageData.Audio;
        audioSource.time = 0;
        Timer = (int)audioSource.clip.length;
        spectrumEngine.setModifier(StageData.SpectrumEngineModifier);
        StartCoroutine("GameStartCountdown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        GameManager.ResumeOrder();
        StartCoroutine("TimerCountdown");
        audioSource.Play();
    }
    public void GameRestart()
    {
   
        GameManager.RestartGame();
    }
      
    public void GamePause()
    {
        audioSource.Pause();
        GameManager.PauseOrder();

    }

    public void ResumeGame()
    {
        audioSource.UnPause();
        GameManager.ResumeOrder();
    }
    public void VolumeChange(float value)
    {
        audioSource.volume = value;
    }

    IEnumerator TimerCountdown()
    {
        while(Timer > 0)
        {
            if(GameManager.GameState == GameStateEnum.Running)
            Timer--;
            TimerText.text = Timer.ToString();
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    IEnumerator GameStartCountdown()
    {
        GameManager.PauseOrder();
        int x = 5;

        while(x > 0)
        {
            x--;
            TimerText.text = x.ToString();
            yield return new WaitForSeconds(1);
        }
        GameStart();
        
        

    }
}
[System.Serializable]
public class GameStageData
{
    public AudioClip Audio;
    public float SpectrumEngineModifier;
}

