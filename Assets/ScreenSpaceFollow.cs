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

    private void Start()
    {
        //assigns the RectTransform component on 'this' to the 'thisObj' variable
        this.thisObj = this.GetComponent<RectTransform>();
    }

    private void Update()
    {
        //finds the screen pos of 'Object To Follow', then sets the position of 'this' to that screen position
        var screenPos = this.mainCamera.WorldToScreenPoint(this.objectToFollow.position);
        screenPos.y += this.offsetY;
        screenPos.x += this.offsetX;
        this.thisObj.position = screenPos;
    }
}
