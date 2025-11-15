using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoulSlot : Selectable, IPointerClickHandler {
    public EnemyTypeSO soul { get; private set; }
    public PlayerSoulController playerSoulController { get; set; }

    [SerializeField] private Image icon;
    [SerializeField] private GameObject highlight;

    protected override void Awake() {
        base.Awake();
        if (icon != null)
            icon.enabled = false;

        if (highlight != null)
            highlight.SetActive(false);
    }

    public void SetSoul(EnemyTypeSO soul) {
        this.soul = soul;

        if (soul != null) {
            icon.sprite = soul.sprite;
            icon.enabled = true;
        } else {
            icon.sprite = null;
            icon.enabled = false;
        }

        highlight.SetActive(false);
    }

    public void SetSelected(bool selected) {
        highlight.SetActive(selected);
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            if (soul != null)
                playerSoulController.OnSlotClicked(this);
        }
    }
}
