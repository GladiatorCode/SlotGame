using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] Slot[] slots;

    public float moveDuration = 1.0f; // Duration of the movement in seconds.
    public float distanceToMove = 55.0f; // The distance to move downward.

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private RectTransform rectTransform;
    
    private Coroutine moveCoroutine;

    public int numberOfMoves = 0;

    public int numberOfMovesToPass = 0;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        targetPosition = startPosition - new Vector3(0, distanceToMove, 0);
    }

    void Update()
    {
        if (startPosition.y == -165f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 165);
            ResetPositions();
        }
    }

    public void StartSpin()
    {   
        System.Random random = new System.Random();
        numberOfMoves = random.Next(5, 10);
        moveDuration = random.Next(2, 5) / 10f;

        Debug.Log("The number of moves : " + numberOfMoves);

        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveMultipleTimes(numberOfMoves));
        }

    }

    public int CheckReelEnd()
    {
        return numberOfMovesToPass;
    }

    void ResetPositions()
    {
        startPosition = GetComponent<RectTransform>().anchoredPosition;
        targetPosition = startPosition - new Vector3(0, distanceToMove, 0);
    }

    IEnumerator MoveMultipleTimes(int numMoves)
    {
        numberOfMovesToPass = numMoves;

        for (int i = 0; i < numMoves; i++)
        {
            yield return MoveOneStep();
        }
        
        moveCoroutine = null; // Reset the coroutine when done.
    }

    IEnumerator MoveOneStep()
    {
        float startTime = Time.time;
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime = Time.time - startTime;
            float t = elapsedTime / moveDuration;
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // Movement is complete.
        rectTransform.anchoredPosition = targetPosition;
        yield return new WaitForSeconds(0.1f); // Pause briefly between movements.
        ResetPositions();
    }
}
