using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PerkCardSO", menuName = "Scriptable Objects/PerkCardSO")]
public class PerkCardSO : ScriptableObject
{
    public string title;
    public string description;
    public Sprite sprite;

    [SerializeReference]
    public List<PerkEffect> perkEffectList = new List<PerkEffect>();

    public bool reSelectable;

}
