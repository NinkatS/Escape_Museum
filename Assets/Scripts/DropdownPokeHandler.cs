using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownPokeHandler : MonoBehaviour, IPointerClickHandler
{
    private Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (dropdown != null)
        {
            dropdown.Show(); // This should open the dropdown options
        }
    }
}
