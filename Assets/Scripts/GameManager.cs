using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState
{
    Intro,
    Playing,
    Dead,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state = GameState.Intro;

    public GameObject IntroUI;
    public GameObject DeadUI;
    public GameObject[] Spawners;

    public int Lives = 3;

    public float PlayStartTime;

    public TMP_Text scoreText;

    public Player player;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    void Start()
    {
        IntroUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.Playing)
        {
            scoreText.text = "Score : " + Mathf.FloorToInt(CalcScore());
        } else if(state == GameState.Dead)
        {
            scoreText.text = "High Score : " + GetHighScore();
        }

        if(state == GameState.Intro && Input.GetKeyUp(KeyCode.Space))
        {
            state = GameState.Playing;
            IntroUI.SetActive(false);
            DeadUI.SetActive(false);
            for(int i = 0; i < Spawners.Length; i++)
            {
                Spawners[i].SetActive(true);  
            }
            PlayStartTime = Time.time;  
        }

        if(state == GameState.Playing && Lives == 0)
        {
            player.KillPlayer();
            DeadUI.SetActive(true);
            for (int i = 0; i < Spawners.Length; i++)
            {
                Spawners[i].SetActive(false);
            }
            state = GameState.Dead;
        }

        if(state == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }

    float CalcScore()
    {
        return Time.time - PlayStartTime;
    }

    void SaveHighScore()
    {
        int score = Mathf.FloorToInt(CalcScore());
        int curHighScore = PlayerPrefs.GetInt("highScore");
        if(score > curHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public float CalcGameSpeed()
    {
        if(state != GameState.Playing)
        {
            return 5f;
        }
        float speed = 8f + (0.5f * Mathf.Floor(CalcScore() / 10f));
        return Mathf.Min(speed, 15f);
    }
}
