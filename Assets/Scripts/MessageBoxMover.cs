using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MessageBoxMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 2. クリック座標の取得
            Vector2 clickPosition = Input.mousePosition;

            // 3. スクリーン座標をUI座標に変換
            RectTransform uiRoot = GetCanvasRectTransform();
            Vector2 uiPosition;

            if (uiRoot != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(uiRoot, clickPosition, null, out uiPosition))
            {
                // ここでuiPositionを使用して処理を行います
                Debug.Log("UI座標: " + uiPosition);

                if (this.transform.position.y >= -1100 && this.transform.position.y <= -400)
                {
                    Vector3 newPosition = this.transform.position;
                    newPosition.y = uiPosition.y + 1200.0f;
                    this.transform.position = newPosition;
                }
            }
            else
            {
                // 変換に失敗した場合の処理
                Debug.Log("UI座標の変換に失敗しました。");
            }
        }
    }

    RectTransform GetCanvasRectTransform()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            return canvas.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Canvasが見つかりませんでした。Canvasを作成するか、既存のCanvasにアタッチしてください。");
            return null;
        }
    }
}
