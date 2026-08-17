using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    public ARObjectManager arObjectManager;
    public ImageTrackingManager imageTrackingManager;

    [Header("2D Overlay")]
    public TwoDOverlayManager twoDOverlayManager;

    [Header("Trout")]
    public RectTransform troutTransform;
    public GameObject troutObject;

    [Header("Story Layout Text")]
    public TMP_Text storyTextTitle;
    public TMP_Text storyTextDescription;
    public Image storyTextImage;
    public Button storyTextButton;

    [Header("Card Layout")]
    public TMP_Text cardTitle;
    public TMP_Text cardDescription;
    public Image cardImage;
    public Button cardButton;
    public TMP_Text cardLabel1;
    public TMP_Text cardLabel2;

    [Header("Story Layout Image")]
    public TMP_Text storyImageTitle;
    public TMP_Text storyImageDescription;
    public Image storyImage;
    public Button storyImageButton;

    [Header("Blank")]

    [Header("Page Data")]
    public Page[] pages;

    private int currentPage = 0;

    [Header("Page Layouts")]
    public GameObject storyLayoutText;
    public GameObject cardLayout;
    public GameObject storyLayoutImage;

    [Header("Testing")]
    public bool useTestSpawnPoint = true;
    public Transform testSpawnPoint;


    void Start()
    {
        UpdateUI();
    }


    public void UpdateUI()
    {
        Page page = pages[currentPage];

        troutObject.SetActive(page.showTrout);

        if (page.showTrout)
        {
            troutTransform.anchoredPosition = page.troutPosition;
            troutTransform.localRotation = Quaternion.Euler(0, 0, page.troutRotation);

            Vector3 scale = troutTransform.localScale;
            scale.x = page.flipTrout ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            troutTransform.localScale = scale;
        }

        // =========================================================
        // NORMAL UI
        // =========================================================

        // Hide all layouts
        storyLayoutText.SetActive(false);
        cardLayout.SetActive(false);
        storyLayoutImage.SetActive(false);


        switch (page.pageType)
        {
            case PageType.StoryLayoutText:

                storyLayoutText.SetActive(true);

                storyTextTitle.text = page.title;
                storyTextDescription.text = page.description;

                storyTextImage.gameObject.SetActive(page.image != null);

                if (page.image != null)
                {
                    storyTextImage.sprite = page.image;
                }

                storyTextButton.gameObject.SetActive(!page.hideButton);

                break;


            case PageType.CardLayout:

                cardLayout.SetActive(true);

                cardTitle.text = page.title;
                cardDescription.text = page.description;

                cardLabel1.text = page.label1;
                cardLabel2.text = page.label2;

                cardImage.gameObject.SetActive(page.image != null);

                if (page.image != null)
                {
                    cardImage.sprite = page.image;
                }

                cardButton.gameObject.SetActive(!page.hideButton);

                break;


            case PageType.StoryLayoutImage:

                storyLayoutImage.SetActive(true);

                storyImageTitle.text = page.title;
                storyImageDescription.text = page.description;

                storyImage.gameObject.SetActive(page.image != null);

                if (page.image != null)
                {
                    storyImage.sprite = page.image;
                }

                storyImageButton.gameObject.SetActive(!page.hideButton);

                break;


            case PageType.Blank:

                break;
        }


        // =========================================================
        // 2D OVERLAY
        // =========================================================

        if (twoDOverlayManager != null)
        {
            if (page.use2DOverlay && page.twoDBackground != null)
            {
                twoDOverlayManager.ShowOverlay(
                    page.twoDBackground,
                    page.show2DButton
                );
            }
            else
            {
                twoDOverlayManager.HideOverlay();
            }
        }


        // =========================================================
        // AR OBJECTS
        // =========================================================

        Transform spawnPoint = imageTrackingManager.CurrentTrackedImage;

        if (spawnPoint == null && useTestSpawnPoint)
        {
            spawnPoint = testSpawnPoint;
        }

        if (spawnPoint != null)
        {
            arObjectManager.ShowPrefabs(
                page.objectsToSpawn,
                spawnPoint
            );
        }
        else
        {
            arObjectManager.HidePrefabs();
        }
    }


    // =============================================================
    // NORMAL PAGE BUTTON
    // =============================================================

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;

            UpdateUI();
        }
    }


    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;

            UpdateUI();
        }
    }


    // =============================================================
    // 2D OVERLAY BUTTON
    // =============================================================

    public void Move2DBackground()
    {
        if (twoDOverlayManager == null)
            return;

        Page page = pages[currentPage];

        twoDOverlayManager.MoveRight(page.twoDMoveAmount);
    }
}