using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TooltipManager : MonoBehaviour {
    public static TooltipManager Instance;

    [SerializeField] public GameObject tooltipPanel;
    [SerializeField] private TMP_Text tooltipText;

    [SerializeField] private Canvas canvas;
    private RectTransform canvasRect;
    private RectTransform tooltipRect;


    private void Awake() {
        Instance = this;
        tooltipPanel.SetActive(false);

        canvasRect = canvas.GetComponent<RectTransform>();
        tooltipRect = tooltipPanel.GetComponent<RectTransform>();
        tooltipRect.pivot = new Vector2(0f, 0f);

    }

    private void Update() {
        if (tooltipPanel.gameObject.activeSelf) {
            UpdatePosition(Input.mousePosition);
        }
    }

    public void Show(string text, Vector2 screenPos) {
        tooltipPanel.SetActive(true);
        tooltipPanel.transform.position = screenPos;
        tooltipText.text = text;
    }

    public void Hide() {
        tooltipPanel.SetActive(false);
    }

    private void UpdatePosition(Vector2 screenPos) {
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect, screenPos, canvas.worldCamera, out anchoredPos);

        float padding = 10f;

        float left = canvasRect.rect.xMin + padding;
        float right = canvasRect.rect.xMax - tooltipRect.rect.width - padding;
        float bottom = canvasRect.rect.yMin + padding;
        float top = canvasRect.rect.yMax - tooltipRect.rect.height - padding;

        float clampedX = Mathf.Clamp(anchoredPos.x, left, right);
        float clampedY = Mathf.Clamp(anchoredPos.y, bottom, top);

        tooltipRect.anchoredPosition = new Vector2(clampedX, clampedY);
    }
}