using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour {
    [SerializeField] private Image ammoImage;
    [SerializeField] private Sprite filledSprite;
    [SerializeField] private Sprite emptySprite;


    public static AmmoUI Create(Transform parent, Sprite filledSprite, Sprite emptySprite) {
        GameObject ammoUIObject = new GameObject("AmmoUI");

        RectTransform rect = ammoUIObject.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(15, 30);

        Image img = ammoUIObject.AddComponent<Image>();

        AmmoUI ammoUI = ammoUIObject.AddComponent<AmmoUI>();
        ammoUI.ammoImage = img;

        if (parent != null)
            ammoUIObject.transform.SetParent(parent, false);

        ammoUI.filledSprite = filledSprite;
        ammoUI.emptySprite = emptySprite;

        img.sprite = filledSprite;
        return ammoUI;
    }

    public void SetFilled(bool isFilled) {
        ammoImage.sprite = isFilled ? filledSprite : emptySprite;
    }

}
