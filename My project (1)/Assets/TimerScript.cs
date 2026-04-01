using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for Legacy Text
using TMPro; // Use TMPro for TextMeshPro
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 30f; // Set the starting time in the Inspector
    // Use this if you have a TextMeshPro UI element
    [SerializeField] private GameObject Character;
    public TextMeshProUGUI countdownText; 
    public GameObject winScreen;
    
    [Header("UI objects")]
    public GameObject PressAnyKeyImage;


    [Header("Post processing")]
    [SerializeField] private ColorGrading _cameraColorGrading;
    [SerializeField] private Shader _deathRendererShader;

    [Header("Values")]
    [SerializeField] private float PressKeyDelay = 1;//Time after which you can restart the game
    private float _seconds;
    
    // Or use this if you have a Legacy Text UI element
    // public Text countdownText; 

    private bool timerActive = true;

    void Update()
    {
        
        if (timerActive)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime;
                UpdateTimerDisplay();
                winScreen.SetActive(false);
            }
            else
            {
                countdownTime = 0;
                timerActive = false;
                UpdateTimerDisplay();
                // Add actions to perform when the timer finishes (e.g., game over, load scene)
                Debug.Log("Countdown Finished!");
                Character.SetActive(false);
                winScreen.SetActive(true);
                _cameraColorGrading.SetRendererShader(_deathRendererShader);

                _seconds += Time.deltaTime;
                if (_seconds > PressKeyDelay)
                {
                    PressAnyKeyImage.SetActive(true);
                    if (Input.anyKeyDown)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
            }
        }
    }

    void UpdateTimerDisplay()
    {
        // Format the time to display minutes and seconds (e.g., "01:30")
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
