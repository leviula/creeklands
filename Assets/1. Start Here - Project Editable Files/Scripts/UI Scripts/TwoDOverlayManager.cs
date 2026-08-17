using UnityEngine;
using UnityEngine.UI;

public class TwoDOverlayManager : MonoBehaviour
{
    public Image backgroundImage;
    public Button moveButton;

    private RectTransform backgroundRect;

    private float originalX;
    private float currentX;

    private bool initialized = false;

    void Awake()
    {
        if (backgroundImage != null)
        {
            backgroundRect = backgroundImage.GetComponent<RectTransform>();
        }
    }

    public void ShowOverlay(Sprite sprite, bool showButton)
    {
        if (backgroundImage == null)
            return;

        backgroundImage.gameObject.SetActive(true);
        backgroundImage.sprite = sprite;

        if (moveButton != null)
        {
            moveButton.gameObject.SetActive(showButton);
        }

        // Remember the starting position only once
        if (!initialized)
        {
            originalX = backgroundRect.anchoredPosition.x;
            currentX = originalX;
            initialized = true;
        }

        backgroundRect.anchoredPosition = new Vector2(
            currentX,
            backgroundRect.anchoredPosition.y
        );
    }

    public void HideOverlay()
    {
        if (backgroundImage != null)
        {
            backgroundImage.gameObject.SetActive(false);
        }

        if (moveButton != null)
        {
            moveButton.gameObject.SetActive(false);
        }
    }

    public void MoveRight(float amount)
    {
        if (backgroundRect == null)
            return;

        currentX += amount;

        backgroundRect.anchoredPosition = new Vector2(
            currentX,
            backgroundRect.anchoredPosition.y
        );

        Debug.Log("2D background moved to X: " + currentX);
    }

    public void ResetPosition()
    {
        if (backgroundRect == null)
            return;

        currentX = originalX;

        backgroundRect.anchoredPosition = new Vector2(
            currentX,
            backgroundRect.anchoredPosition.y
        );
    }
}