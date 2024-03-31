using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager instance { get; private set; }

    public bool gameFinished { get; private set; }

    [SerializeField] private int timeLimit = 15;
    [SerializeField] private int coinTimeBonus = 5;
    [SerializeField] private int coinsToWin = 10;

    [SerializeField] private TMP_Text timerDisplay;
    [SerializeField] private TMP_Text coinCountDisplay;
    //[SerializeField] private GameObject victoryWindow;
    //[SerializeField] private GameObject failWindow;
    [SerializeField] private TMP_Text _panelText;
    [SerializeField] private GameObject _panelObj;

    private int coinsCount = 0;
    private int timeLeft = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("Game manager already exists!");
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        timeLeft = timeLimit;
        InvokeRepeating("DecreaseTimer", 1f, 1f);
    }

    void DecreaseTimer()
    {
        if (--timeLeft == 0)
        {
            EndGame(false);
        }
        //Debug.Log(timeLeft);
        UpdateTimer();
    }

    public void OnCoinCollected()
    {
        if (++coinsCount == coinsToWin)
        {
            EndGame(true);
        }
        timeLeft = Mathf.Clamp(timeLeft + coinTimeBonus, 0, timeLimit);
        UpdateTimer();
        UpdateCoinCounter();
    }

    void UpdateTimer()
    {
        timerDisplay.text = timeLeft.ToString();
    }

    void UpdateCoinCounter()
    {
        coinCountDisplay.text = coinsCount.ToString();
    }

    /*void EndGame(bool victory)
    {
        Time.timeScale = 0;
        gameFinished = true;
        if (victory)
        {
            victoryWindow.SetActive(true);
        }
        else
        {
            failWindow.SetActive(true);
        }
    }*/

    private void EndGame(bool victory)
    {
        Time.timeScale = 0;
        gameFinished = true;
        if (victory)
        {
            _panelText.text = "Win";
        }
        else
        {
            _panelText.text = "Lose";
        }
        _panelObj.SetActive(true);
    }
}