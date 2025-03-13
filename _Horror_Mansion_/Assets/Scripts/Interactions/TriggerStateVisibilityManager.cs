using UnityEngine;
using UnityEngine.UI;

public class TriggerStateVisibilityManager : MonoBehaviour
{
    private GameObject[] triggerBoxes;
    private bool isVisible = false;

    [SerializeField] private Button toggleButton;
    [SerializeField] private Image toggleIcon;
    [SerializeField] private Sprite tickSprite;
    [SerializeField] private Sprite crossSprite;

    void Start()
    {
        triggerBoxes = GameObject.FindGameObjectsWithTag("LocationStateTrigger");
        UpdateButtonAppearance();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleTriggerVisibility();
        }
    }

    public void ToggleTriggerVisibility()
    {
        isVisible = !isVisible;
        foreach (GameObject triggerBox in triggerBoxes)
        {
            MeshRenderer renderer = triggerBox.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = isVisible;
            }
        }

        Debug.Log($"Trigger visibility toggled to {isVisible}");
        SoundManager.instance.PlayVisibilityToggleSound(isVisible);

        UpdateButtonAppearance();
    }

    private void UpdateButtonAppearance()
    {
        if (toggleIcon != null)
        {
            toggleIcon.sprite = isVisible ? tickSprite : crossSprite;
            toggleIcon.color = isVisible ? Color.white : new Color(1, 1, 1, 0.5f);
            //Debug.Log($"Button appearance updated. Visible: {isVisible}. Sprite: {toggleIcon.sprite.name}");
        }
        else
        {
            Debug.LogError("Toggle Icon is not assigned in the inspector!");
        }
    }
}