using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public bool spin;
    public float speed;

    private float[] snapSlots = { 30f, 20f, 10f, 0f, -10f, -20f }; // Y positions for snapping

    private Coroutine spinRoutine;

     //  Start spinning (Coroutine Stop)
    public void StartSpinning()
    {
        spin = true;

        // If a coroutine is already running, stop it first
        if (spinRoutine != null)
            StopCoroutine(spinRoutine);

        spinRoutine = StartCoroutine(SpinReel());
    }

    
    //  Stop spinning (Coroutine Stop)
    
    public void StopSpinning()
    {
        spin = false;

        if (spinRoutine != null)
            StopCoroutine(spinRoutine);

        spinRoutine = null;
    }

    //     SPINNING COROUTINE
    
    private IEnumerator SpinReel()
    {
        while (spin)
        {
            foreach (Transform symbol in transform)
            {
                symbol.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

                if (symbol.position.y <= -30f) // If symbol goes off-screen below, send back to top
                {
                    symbol.position = new Vector3(symbol.position.x, 30f, symbol.position.z);
                }
            }

            yield return null; // wait for next frame (same as Update)
        }
    }

    // //    SNAP METHOD (unchanged)
    
    public void SnapToNearestSlot()
    {
        List<float> slotPool = new List<float>(snapSlots);

        foreach (Transform symbol in transform)
        {
            int index = Random.Range(0, slotPool.Count);
            symbol.localPosition = new Vector3(symbol.localPosition.x, slotPool[index], symbol.localPosition.z);
            slotPool.RemoveAt(index);
        }
    }

    //   GET MIDDLE SPRITE 
    
    public Sprite GetMiddleSymbol()
    {
    float centerY = 0f; // middle row Y position
    float closestDist = Mathf.Infinity;
    Sprite closestSprite = null;

    foreach (Transform symbol in transform)   // your vertical list
     {
        float dy = Mathf.Abs(symbol.localPosition.y - centerY);

        if (dy < closestDist)
        {
            closestDist = dy;
            closestSprite = symbol.GetComponent<SpriteRenderer>().sprite;
        }
     }

    return closestSprite;
    }

   

}

