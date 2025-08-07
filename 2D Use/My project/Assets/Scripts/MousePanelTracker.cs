using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MousePanelTracker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    private bool _isPointerOver;
    public TMP_Text coordsText; 

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_isPointerOver)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform,
                Input.mousePosition,
                null,
                out var localPoint
            );
            if (coordsText != null)
                coordsText.text = $"Coordenadas del cursor -> {localPoint}";
        }
        else
        {
            if (coordsText)
                coordsText.text = "";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerOver = false;
    }
}