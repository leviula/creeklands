using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LayoutGroupVisualizer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        LayoutGroup layout = GetComponent<LayoutGroup>();
        if (layout == null) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform child = transform.GetChild(i) as RectTransform;
            if (child == null || !child.gameObject.activeSelf)
                continue;

            DrawRect(child, GetColor(i));
        }
    }

    private void DrawRect(RectTransform rect, Color color)
    {
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        Gizmos.color = color;

        Gizmos.DrawLine(corners[0], corners[1]);
        Gizmos.DrawLine(corners[1], corners[2]);
        Gizmos.DrawLine(corners[2], corners[3]);
        Gizmos.DrawLine(corners[3], corners[0]);
    }

    private Color GetColor(int index)
    {
        Color[] colors =
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            Color.cyan,
            Color.magenta,
            new Color(1f, 0.5f, 0f),
            Color.white
        };

        return colors[index % colors.Length];
    }
}