using UnityEngine;

public class BoardManager : MonoBehaviour {

    private float tileSize = 1f;
    private BoardTile[,] tiles = new BoardTile[8, 8];

    void Start() {
        GenerateBoard(tileSize, 8, 8);
    }

    private void GenerateBoard(float tileSize, int tileCountX, int tileCountY) {
        for (int x = 0; x < tileCountX; x++) {
            for (int y = 0; y < tileCountY; y++) {
                tiles[x,y] = BoardTile.Create(tileSize, x, y);
            }
        }
    }
}
