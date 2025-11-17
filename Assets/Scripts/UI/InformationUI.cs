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
        if (fadingPanel == null)
            fadingPanel = GetComponent<FadingPanel>();


        enemyInformationUI.gameObject.SetActive(false);
        playerInformationUI.gameObject.SetActive(false);
        topSideInformationUI.gameObject.SetActive(false);

        enemyInformationUI.Initialize();

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
        yield return fadingPanel.FadeIn(1f);
    }

    public IEnumerator OnPlayerWin() {
        yield return fadingPanel.FadeOut();
        playerInformationUI.Hide();
        enemyInformationUI.Hide();

        topSideInformationUI.OnPlayerWin();
    }

    private void OnEnable() {
        boardInputBroadcaster.OnTileHovered += CheckEnemyOnTile;
    }

    private void OnDisable() {
        boardInputBroadcaster.OnTileHovered -= CheckEnemyOnTile;
    }

}
