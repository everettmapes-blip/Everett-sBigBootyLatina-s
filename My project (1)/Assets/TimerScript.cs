using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for Legacy Text
using TMPro; // Use TMPro for TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 30f; // Set the starting time in the Inspector
    // Use this if you have a TextMeshPro UI element
    [SerializeField] private GameObject Character;
    public TextMeshProUGUI countdownText; 
    public TextMeshProUGUI winScreen; 
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
                
            }
            else
            {
                countdownTime = 0;
                timerActive = false;
                UpdateTimerDisplay();
                // Add actions to perform when the timer finishes (e.g., game over, load scene)
                Debug.Log("Countdown Finished!");
                Character.SetActive(false);

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
