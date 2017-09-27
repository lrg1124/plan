using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler {

    [SerializeField]
    bool canDrag;
    [SerializeField]
    Image icon;
    [SerializeField]
    GameObject dragPanel;
    [SerializeField]
    Canvas canvas;

    public static bool DRAG = false;
    public static float FACTOR = 0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnDrag(PointerEventData eventData) {
        if (DRAG) {
            icon.rectTransform.localPosition += (Vector3)(eventData.delta * FACTOR);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (icon != null && !DRAG) {
            var scaler = canvas.GetComponent<CanvasScaler>();
            if (scaler.uiScaleMode == CanvasScaler.ScaleMode.ScaleWithScreenSize) {
                FACTOR = scaler.referenceResolution.x / Screen.width;
            }
            icon.rectTransform.parent = dragPanel.transform;
            DRAG = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (DRAG) {
            //icon.rectTransform.parent = bg.transform;
            //icon.AddGOTo(bg.gameObject);
            //icon.GetRectTrans().localPosition = Vector2.zero;
            DRAG = false;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        if (DRAG) {
            //var dragObj = eventData.pointerDrag;
            //var exchangedObj = gameObject.GetChildAt(0);
        }
    }

}
