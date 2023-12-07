using UnityEngine;

public static class Extensions
{
    /// <summary>
    /// ī�޶� ����� �´� ���� �ݶ��̴� �ٿ�� ����
    /// </summary>
    /// <param name="screenEdge">���� �ݶ��̴�</param>
    public static void GenerateCameraBounds(this EdgeCollider2D screenEdge)
    {
        var halfScreenHeight = Camera.main.orthographicSize;
        var halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        
        var bounds = new Vector2[4];
        bounds[0] = new Vector2(-halfScreenWidth, -halfScreenHeight);
        bounds[1] = new Vector2(-halfScreenWidth, halfScreenHeight);
        bounds[2] = new Vector2(halfScreenWidth, halfScreenHeight);
        bounds[3] = new Vector2(halfScreenWidth, -halfScreenHeight);

        screenEdge.points = bounds;
    }
}
