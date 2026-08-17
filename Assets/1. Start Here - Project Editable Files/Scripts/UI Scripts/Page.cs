using UnityEngine;

public enum PageType
{
    StoryLayoutText,
    CardLayout,
    StoryLayoutImage,
    Blank
}

[System.Serializable]
public class ARObjectData
{
    public GameObject prefab;

    [Header("Transform")]
    public Vector3 localPosition;
    public Vector3 localRotation;
    public Vector3 localScale = Vector3.one;
}

[System.Serializable]
public class Page
{
    [Header("Page Information")]
    public int chapterNumber = 0;

    public PageType pageType;

    [Header("Content")]
    public string title;

    [TextArea(3, 10)]
    public string description;

    [Header("Optional Content")]
    public Sprite image;

    public bool hideButton;

    [Header("Card Layout")]
    public string label1;
    public string label2;

    [Header("AR Objects")]
    public ARObjectData[] objectsToSpawn;

    [Header("2D Overlay")]
    public bool use2DOverlay;
    public Sprite twoDBackground;
    public float twoDMoveAmount = 500f;
    public bool show2DButton;

    [Header("Trout")]
    public bool showTrout = true;
    public Vector2 troutPosition;
    public float troutRotation;
    public bool flipTrout;
    }