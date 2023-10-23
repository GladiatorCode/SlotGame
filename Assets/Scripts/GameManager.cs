using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int coins = 1000;
    [SerializeField] Reel[] reels;
    [SerializeField] WinningArray winningArray;
    [SerializeField] TextMeshProUGUI coinsText;
    IEnumerator StartSpin()
    {
        foreach (Reel reel in reels)
        {
            reel.StartSpin();
        }
        yield return new WaitForSeconds(5.1f);
        CheckWinnings();
    }

    void CheckWinnings()
    {
        int firstReelResults = reels[0].CheckReelEnd();
        int secondReelResults = reels[1].CheckReelEnd();
        int thirdReelResults = reels[2].CheckReelEnd();

        int[] result = new int[] { firstReelResults, secondReelResults, thirdReelResults };

        if(winningArray.IsRowInMatrix(result))
        {
            coins += 200;
            coinsText.text = coins.ToString();
        }
    }

    public void StartSpinButton()
    {
        if(coins > 50)
        {
            StartCoroutine(StartSpin());
            coins -= 50;
            coinsText.text = coins.ToString();
        }
    }
}
