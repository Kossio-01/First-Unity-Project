using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class CoordList
{
    public List<Vector2> coords = new List<Vector2>();
}

public class MousePanelTracker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    private bool _isPointerOver;
    public TMP_Text coordsText;
    private CoordList _coordList = new CoordList();
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_isPointerOver && Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _rectTransform,
                Input.mousePosition,
                null,
                out var localPoint
            );
            _coordList.coords.Add(localPoint);
            if (coordsText != null)
                coordsText.text = $"Coordenadas guardadas: {localPoint}";
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

    // Call this from your UI Button
    public void SaveCoordsToJson()
    {
        string json = JsonUtility.ToJson(_coordList, true);
        string path = Path.Combine(Application.persistentDataPath, "coords.json");
        File.WriteAllText(path, json);
        if (coordsText != null)
            coordsText.text = $"Coordenadas guardadas en: {path}";
    }
}