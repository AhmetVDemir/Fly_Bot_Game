using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rectTransform;
    Rect safeArea;
    Vector2 minAnch;
    Vector2 maxAnch;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;
        minAnch = safeArea.position;
        maxAnch = minAnch + safeArea.size;

        minAnch.x /= Screen.width;
        minAnch.y /= Screen.height;
        maxAnch.x /= Screen.width;
        maxAnch.y /= Screen.height;

        rectTransform.anchorMin = minAnch;
        rectTransform.anchorMax = maxAnch;
        
    }
}
