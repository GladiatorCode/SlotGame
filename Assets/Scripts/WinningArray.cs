using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinningArray : MonoBehaviour
{
    public int[][] winsArray = new int[18][];

    void Awake()
    {
        winsArray[0] = new int[] { 5, 5, 5 };
        winsArray[1] = new int[] { 6, 6, 6 };
        winsArray[2] = new int[] { 7, 7, 7 };
        winsArray[3] = new int[] { 8, 8, 8 };
        winsArray[4] = new int[] { 9, 9, 9 }; 
        winsArray[5] = new int[] { 10, 10, 10 }; 
        winsArray[6] = new int[] { 5, 5, 8 };
        winsArray[7] = new int[] { 5, 8, 8 };
        winsArray[8] = new int[] { 5, 8, 5 };
        winsArray[9] = new int[] { 6, 6, 9 };
        winsArray[10] = new int[] { 6, 9, 6 };
        winsArray[11] = new int[] { 7, 7, 10 };
        winsArray[12] = new int[] { 7, 10, 7 };
        winsArray[13] = new int[] { 8, 8, 5 };
        winsArray[14] = new int[] { 8, 5, 8 };
        winsArray[15] = new int[] { 9, 9, 6 };
        winsArray[16] = new int[] { 10, 10, 7 };
        winsArray[17] = new int[] { 10, 7, 7 };

        Debug.Log(winsArray[8]);
    }

    public bool IsRowInMatrix(int[] targetRow)
    {
        foreach (int[] row in winsArray)
        {
            if (row.SequenceEqual(targetRow))
            {
                return true; // The target row exists in the matrix.
            }
        }
        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            bool result = IsRowInMatrix(new int[] { 5, 8, 5 });
            if (result)
            {
                Debug.Log("It's a WIN!");
            }
            else
            {
                Debug.Log("It's a LOSE!");
            }
        }
    }
}
