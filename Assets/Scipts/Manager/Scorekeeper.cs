using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI remainingText;
    private int score;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    
    public void UpdateScore(int changeInScore)
    {
        score += changeInScore;  //Adds the change in score to the current score
        if (scoreText != null)
        {
            //Converts the score from an int to a string then saves it to the UI.
            scoreText.text = "Score: " + score.ToString();  
        }
    

    }

    public void UpdateRemaining(int animalsRemaining)
    {
    
        if (remainingText != null)
        {
            //Converts the score from an int to a string then saves it to the UI.
            remainingText.text = "Num Animals Remaining: " + animalsRemaining.ToString();  
        }
    }



}
