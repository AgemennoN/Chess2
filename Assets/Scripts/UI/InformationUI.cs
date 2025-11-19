using System.Collections;
using UnityEngine;

public class InformationUI : MonoBehaviour {

    public static InformationUI Instance { get; private set; }


    [Header("BoardInputBroadcaster")]
    [SerializeField] private BoardInputBroadcaster boardInputBroadcaster;

    [Header("Child UI Objects")]
    [SerializeField] private EnemyInformationUI enemyInformationUI;
    [SerializeField] private PlayerInformationUI playerInformationUI;
    [SerializeField] private TopSideInformationUI topSideInformationUI;
    [SerializeField] private PerkInformationUI perkInformationUI;

    [Header("Self Components")]
    [SerializeField] private FadingPanel fadingPanel;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Initialize() {
        if (enemyInformationUI == null)
            enemyInformationUI = GetComponentInChildren<EnemyInformationUI>();
        if (playerInformationUI == null)
            playerInformationUI = GetComponentInChildren<PlayerInformationUI>();
        if (topSideInformationUI == null)
            topSideInformationUI = GetComponentInChildren<TopSideInformationUI>();
        if (perkInformationUI == null)
            perkInformationUI = GetComponentInChildren<PerkInformationUI>();
        if (fadingPanel == null)
            fadingPanel = GetComponent<FadingPanel>();


        enemyInformationUI.gameObject.SetActive(false);
        playerInformationUI.gameObject.SetActive(false);
        topSideInformationUI.gameObject.SetActive(false);
        perkInformationUI.gameObject.SetActive(false);

        enemyInformationUI.Initialize();
        perkInformationUI.Initialize();

    }

    private void CheckEnemyOnTile(BoardTile tile) {
        EnemyPiece enemy = tile?.GetPiece() as EnemyPiece;
        if (enemy != null) {
            playerInformationUI.Hide();
            enemyInformationUI.ShowEnemy(enemy);
        } else {
            enemyInformationUI.Hide();
            playerInformationUI.Show();
        }
    }

    public IEnumerator NewFloorPreparation() {
        yield return StartCoroutine(playerInformationUI.NewFloorPreperation());
        playerInformationUI.Show();
        topSideInformationUI.NewFloorPreperation();
        perkInformationUI.NewFloorPreperation();

        yield return this.fadingPanel.FadeIn(1f);
    }

    public IEnumerator OnPlayerWin() {
        yield return fadingPanel.FadeOut();
        playerInformationUI.Hide();
        enemyInformationUI.Hide();

        topSideInformationUI.OnPlayerWin();
        perkInformationUI.OnPlayerWin();
    }

    private void OnEnable() {
        boardInputBroadcaster.OnTileHovered += CheckEnemyOnTile;
    }

    private void OnDisable() {
        boardInputBroadcaster.OnTileHovered -= CheckEnemyOnTile;
    }

}
