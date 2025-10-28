using UnityEngine;

public class ArrowIndicator : MonoBehaviour {
    [SerializeField] private SpriteRenderer arrowSprite;

    private void Start() {
        Hide();
    }

    public void Show(Vector3 from, Vector3 to) {
        if (arrowSprite == null)
            arrowSprite = GetComponent<SpriteRenderer>();

        Vector3 direction = to - from;

        transform.position = to;
        transform.right = direction.normalized; // Rotate arrow to face target

        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
