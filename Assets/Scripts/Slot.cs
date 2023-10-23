using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public SymbolScriptableObject slot;
    [SerializeField] private Image symbolIngameImage;

    public void Init()
    {
        symbolIngameImage.sprite = slot.image;
    }

}
