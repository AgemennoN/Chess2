using System;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private BoardInputBroadcaster boardInputBroadcaster;
    //[SerializeField] private AimIndicator aimIndicator;
    [SerializeField] private ArrowIndicator aimIndicator;

    protected override void Start() {
        base.Start();

        boardInputBroadcaster.OnTileHovered += HandleTileHover;
        boardInputBroadcaster.OnTileClicked += HandleTileClick;

    }

    private void HandleTileClick(BoardTile tile) {
        if (tile.pieceOnIt != null) {

        }
    }

    private void HandleTileHover(BoardTile tile) {
        throw new NotImplementedException();
    }

    protected override void Shoot() {
        throw new System.NotImplementedException();
    }

    public override void Aim(bool enable) {
        if (enable) {
            aimIndicator.Show(new Vector3(),new Vector3());
        } else {
            aimIndicator.Hide();
        }
    }


    protected override void Reload() {
        throw new System.NotImplementedException();
    }
}
