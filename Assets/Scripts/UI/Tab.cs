using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Project: JumpyStreet
/// Name: Jacob Frigon
/// Section: SGD 285.4171
/// Instructor: Aurore Locklear
/// Date: 02/25/2024
/// </summary>
[RequireComponent(typeof(Image))]
public class Tab : MonoBehaviour, 
    IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    private TabGroup tabGroup;

    [SerializeField]
    private Image background;

    private void Start()
    {
        background = GetComponent<Image>();
        tabGroup.AddTab(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void SetBackground(Color newColor) 
    { 
        this.background.color = newColor;
    }
}
