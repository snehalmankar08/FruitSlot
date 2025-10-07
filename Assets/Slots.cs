using System.Collections;
using UnityEngine;
using TMPro;  // for text display

public class Slots : MonoBehaviour
{
    public Reel[] reel;              // 3 Reels
    public TextMeshProUGUI scoreText; // UI text reference
    private bool startSpin;
    private int score = 0;

    void Start()
    {
        startSpin = false;
        UpdateScoreUI();
    }

    // Called by button click
    public void StartSpin()
    {
        if (!startSpin)
        {
            startSpin = true;
            StartCoroutine(Spinning());
        }
    }

    IEnumerator Spinning()
    {
        // Start all reels spinning
        foreach (Reel spinner in reel)
        {
            spinner.spin = true;
        }

        // Stop sequentially (left → middle → right)
        for (int i = 0; i < reel.Length; i++)
        {
            yield return new WaitForSeconds(0.8f);  // delay between stops
            reel[i].spin = false;
            reel[i].RandomPosition();
        }

        // Wait a short moment for visuals to settle
        yield return new WaitForSeconds(0.5f);

        // Calculate score
        CalculateScore();

        // Allow spinning again
        startSpin = false;
    }

    void CalculateScore()
    {
        // Compare middle fruit of each reel (position roughly Y=0)
        string fruit1 = GetMiddleFruit(reel[0]);
        string fruit2 = GetMiddleFruit(reel[1]);
        string fruit3 = GetMiddleFruit(reel[2]);

        Debug.Log($"Result: {fruit1}, {fruit2}, {fruit3}");

        if (fruit1 == fruit2 && fruit2 == fruit3)
        {
            score += 100;  // All match = big reward
        }
        else if (fruit1 == fruit2 || fruit2 == fruit3 || fruit1 == fruit3)
        {
            score += 30;   // Two match = small reward
        }
        else
        {
            score -= 10;   // None match = lose small points
        }

        UpdateScoreUI();
    }

    string GetMiddleFruit(Reel reelObj)
    {
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (Transform fruit in reelObj.transform)
        {
            float dist = Mathf.Abs(fruit.transform.localPosition.y);
            if (dist < minDist)
            {
                minDist = dist;
                closest = fruit;
            }
        }

        return closest != null ? closest.name : "None";
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
