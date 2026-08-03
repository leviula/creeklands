using UnityEngine;
using UnityEngine.InputSystem;

public class ARTouchManager : MonoBehaviour
{
    public PageManager pageManager;

    void Update()
    {
#if UNITY_EDITOR

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Mouse.current.position.ReadValue()
            );

            CheckRaycast(ray);
        }

#else

        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Touchscreen.current.primaryTouch.position.ReadValue()
            );

            CheckRaycast(ray);
        }

#endif
    }

    void CheckRaycast(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Hit: " + hit.collider.name);

            ARInteractable interactable =
                hit.collider.GetComponent<ARInteractable>();

            if (interactable != null)
            {
                Debug.Log("Story object clicked!");

                pageManager.NextPage();
            }
        }
    }
}