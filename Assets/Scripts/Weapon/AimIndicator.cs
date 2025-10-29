using UnityEngine;

public class AimIndicator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer aimSprite;
    private WeaponDataSO weaponData;

    private void Start() {
        Hide();
    }

    private void Update() {
        if (gameObject.activeSelf) {
            ReSize();
        }
    }

    private void ReSize() {

    }

    public void Show() {
        if (aimSprite == null)
            aimSprite = GetComponent<SpriteRenderer>();
        
        ReSize();
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
