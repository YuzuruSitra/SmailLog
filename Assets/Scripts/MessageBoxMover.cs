using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageBoxMover : MonoBehaviour
{
    public RectTransform canvasGameRect;

    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos = ScreenMousePos(Input.mousePosition);
            rectTransform.anchoredPosition = currentMousePos;
            Debug.Log(rectTransform.anchoredPosition.y + " | touch: " + currentMousePos.y);
            if (rectTransform.anchoredPosition.y >= -400) rectTransform.anchoredPosition = new Vector3(0, -400, 0);
            if (rectTransform.anchoredPosition.y <= -1080) rectTransform.anchoredPosition = new Vector3(0, -1080, 0);
        }
    }

    Vector2 ScreenMousePos(Vector3 mousePos)
    {    
        Vector2 position = mousePos;
        Vector2 screenToViewportPoint = Camera.main.ScreenToViewportPoint(position);
        Vector2 worldObjectScreenPosition = new Vector2( rectTransform.anchoredPosition.x,
            ((screenToViewportPoint.y * canvasGameRect.sizeDelta.y) - (canvasGameRect.sizeDelta.y * 0.5f)));
        return worldObjectScreenPosition;
    }
}