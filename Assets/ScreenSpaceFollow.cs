using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

public class ScreenSpaceFollow : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow; 
    [SerializeField]
    private Camera mainCamera;
    private RectTransform thisObj;
    [SerializeField]
    private float offsetX;
    [SerializeField]
    private float offsetY;
    void Start()
    {
        //assigns the RectTransform component on 'this' to the 'thisObj' variable
        thisObj = GetComponent<RectTransform>();
        Debug.Log(thisObj);

    }
    void Update()
    {
        //finds the screen pos of 'Object To Follow', then sets the position of 'this' to that screen position
        UnityEngine.Vector3 screenPos = mainCamera.WorldToScreenPoint(objectToFollow.position);
        screenPos.y += offsetY;
        screenPos.x += offsetX;
        thisObj.position = screenPos;
    }

}
