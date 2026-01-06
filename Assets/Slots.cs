
using System.Collections;
using UnityEngine;
using TMPro;

public class Slots : MonoBehaviour
{
    public Reel[] reels;                 // All reel scripts
    public TextMeshProUGUI scoreText;    // UI score text
    
    private bool isSpinning = false;
    private int score = 0;

    
    public void StartSpin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinReels());
        }
    }

    IEnumerator SpinReels()
    {
        isSpinning = true;

        // Start all reels using the coroutine StartSpinning()
        foreach (var r in reels)
            r.StartSpinning();

        // Stop each reel with delay
        for (int i = 0; i < reels.Length; i++)
        {
            yield return new WaitForSeconds(0.7f);

            reels[i].StopSpinning();
            reels[i].SnapToNearestSlot();
        }

        // wait a bit so symbols settle
        yield return new WaitForSeconds(0.4f);

        CalculateScore();
        isSpinning = false;
    } 

    void CalculateScore()
    {
    Sprite r1 = reels[0].GetMiddleSymbol();
    Sprite r2 = reels[1].GetMiddleSymbol();
    Sprite r3 = reels[2].GetMiddleSymbol();
    Sprite r4 = reels[3].GetMiddleSymbol();
    Sprite r5 = reels[4].GetMiddleSymbol();

    if (r1 == r2 && r2 == r3 && r3 == r4 && r4 == r5) 
        {
            score += 100;
        }
        else if (r1 == r2 || r2 == r3 || r3 == r4 || r4 == r5 || r5 == r1)
        {
            score += 30;
        }
        else
        {
            score -= 10;
        }

        UpdateScoreUI();
    }
    
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "SCORE:"+ score.ToString();
    }

}
