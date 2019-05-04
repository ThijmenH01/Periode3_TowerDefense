using UnityEngine;

public class Selector : MonoBehaviour {
    public Vector2Int position;

    private void Start() => UpdatePosition(Vector2Int.zero);

    private void Update() {
        UpdatePosition((Input.GetKeyDown(KeyCode.W) ? Vector2Int.up : Input.GetKeyDown(KeyCode.S) ? Vector2Int.down : Vector2Int.zero));
        UpdatePosition((Input.GetKeyDown(KeyCode.A) ? Vector2Int.left : Input.GetKeyDown(KeyCode.D) ? Vector2Int.right : Vector2Int.zero));

        if (Input.GetKeyDown(KeyCode.P)) SpawnBuilding(0);
        if (Input.GetKeyDown(KeyCode.O)) SpawnBuilding(1);
        if (Input.GetKeyDown(KeyCode.I)) SpawnBuilding(2);
        if (Input.GetKeyDown(KeyCode.L)) SpawnBuilding(3);
    }

    private void UpdatePosition(Vector2Int dir) {
        position += dir;
        position.x = Mathf.Clamp(position.x, 0, GameManager.Instance.grid.GetLength(1) - 1);
        position.y = Mathf.Clamp(position.y, 0, GameManager.Instance.grid.GetLength(0) - 1);
        transform.position = GameManager.Instance.grid[position.y, position.x].transform.position;
    }

    private void SpawnBuilding(int building) {
        if (System.Array.IndexOf(GameManager.Instance.enemyPath, position) == -1) {
            if (GameManager.Instance.buildings[position.y, position.x] == null && Balance.Instance.balance >= 0 && Balance.Instance.balance >= GameManager.Instance.tower1Price) {
                GameObject newBuilding = Instantiate(GameManager.Instance.buildingPrefabs[building],
                GameManager.Instance.grid[position.y, position.x].transform.position,
                GameManager.Instance.buildingPrefabs[building].transform.rotation);
                GameManager.Instance.buildings[position.y, position.x] = newBuilding;
                Balance.Instance.balance -= GameManager.Instance.tower1Price;
            }
        }
    }
}
