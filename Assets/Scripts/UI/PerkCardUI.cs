using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PerkCardUI : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler {
    public static PerkCardUI Create(Transform parent, PerkCardSO perk, PerkCardUI prefab) {
        PerkCardUI ui = GameObject.Instantiate(prefab, parent);
        ui.image = ui.GetComponent<Image>();
        ui.SetPerk(perk);
        return ui;
    }

    [SerializeField] private PerkCardSO perk;
    private Image image;
    
    public void SetPerk(PerkCardSO perk) {
        this.perk = perk;
        if (perk != null) {
            //image.sprite = perk.image.sprite;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        }
    }

    public PerkCardSO GetPerk() {
        return perk;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (perk != null) {
            string text = $"<b>{perk.title}</b>\n{perk.description}";
            TooltipManager.Instance.Show(text, eventData.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (perk != null) {
            TooltipManager.Instance.Hide();
        }
    }
}