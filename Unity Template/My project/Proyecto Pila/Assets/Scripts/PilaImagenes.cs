using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PilaImagenes : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject imagenPrefab;
    public Text textoAccion;
    
    [Header("Configuración")]
    [SerializeField] private float spacing = 50f;
    [SerializeField] private float peekDistance = 30f;
    [SerializeField] private float peekDuration = 0.3f;
    [SerializeField] private int maxElementos = 50;     
    private Stack<GameObject> pilaImagenes = new Stack<GameObject>();
    private Dictionary<GameObject, RectTransform> rectTransformCache = new Dictionary<GameObject, RectTransform>();
    private Queue<GameObject> imagenesPool = new Queue<GameObject>();
    private Coroutine currentPeekAnimation;

    private void Awake() {
        // Validación de referencias
        if (imagenPrefab == null) {
            Debug.LogError("imagenPrefab no está asignado en " + gameObject.name); }
        if (textoAccion == null) {
            Debug.LogError("textoAccion no está asignado en " + gameObject.name); } }
    public void Push() {
        // Verificar límite máximo
        if (pilaImagenes.Count >= maxElementos) {
            UpdateTextoAccion("Push: Límite máximo alcanzado"); return; }
        GameObject nuevaImagen = GetImagenFromPool();
        RectTransform rt = GetOrCacheRectTransform(nuevaImagen);
        ConfigurarImagenEnPila(rt, pilaImagenes.Count);
        pilaImagenes.Push(nuevaImagen);
        UpdateTextoAccion($"Push: Imagen apilada ({pilaImagenes.Count})"); }
    public void Pop() {
        if (pilaImagenes.Count > 0) {
            GameObject img = pilaImagenes.Pop();
            ReturnImagenToPool(img);
            UpdateTextoAccion($"Pop: Imagen desapilada ({pilaImagenes.Count})"); }
        else {
            UpdateTextoAccion("Pop: La pila está vacía"); } }
    public void Peek() {
        if (pilaImagenes.Count > 0) {
            if (currentPeekAnimation != null)
            {
                StopCoroutine(currentPeekAnimation);
            }
            
            GameObject topImg = pilaImagenes.Peek();
            RectTransform rt = GetOrCacheRectTransform(topImg);
            currentPeekAnimation = StartCoroutine(PeekAnimation(rt));
            UpdateTextoAccion("Peek: Imagen movida"); }
        else {
            UpdateTextoAccion("Peek: La pila está vacía"); } }
    public void Clean() {
        if (currentPeekAnimation != null) {
            StopCoroutine(currentPeekAnimation);
            currentPeekAnimation = null; }

        while (pilaImagenes.Count > 0) {
            ReturnImagenToPool(pilaImagenes.Pop()); }
        UpdateTextoAccion("Clean: Pila limpiada"); }
    private GameObject GetImagenFromPool() {
        if (imagenesPool.Count > 0) {
            GameObject pooledImage = imagenesPool.Dequeue();
            pooledImage.SetActive(true);
            return pooledImage; }
        return Instantiate(imagenPrefab, transform); }

    private void ReturnImagenToPool(GameObject imagen) {
        imagen.SetActive(false);
        imagenesPool.Enqueue(imagen); }
    private RectTransform GetOrCacheRectTransform(GameObject imagen) {
        if (!rectTransformCache.TryGetValue(imagen, out RectTransform rt)) {
            rt = imagen.GetComponent<RectTransform>();
            rectTransformCache[imagen] = rt; }
        return rt; }
    private void ConfigurarImagenEnPila(RectTransform rt, int position) {
        rt.anchorMin = new Vector2(1, 0); // Bottom right
        rt.anchorMax = new Vector2(1, 0); // Bottom right
        rt.pivot = new Vector2(1, 0);     // Bottom right
        rt.anchoredPosition = new Vector2(0, position * spacing); }
    private void UpdateTextoAccion(string mensaje) {
        if (textoAccion != null) {
            textoAccion.text = mensaje; } }
    private IEnumerator PeekAnimation(RectTransform rt) {
        Vector2 originalPos = rt.anchoredPosition;
        Vector2 peekPos = originalPos + new Vector2(-peekDistance, 0);
        rt.anchoredPosition = peekPos;
        yield return new WaitForSeconds(peekDuration);
        rt.anchoredPosition = originalPos;
        currentPeekAnimation = null; }
    public int GetCount() {
        return pilaImagenes.Count; }
    public bool IsEmpty() {
        return pilaImagenes.Count == 0; }
    public bool IsFull() {
        return pilaImagenes.Count >= maxElementos; }
    private void OnDestroy() {
        if (currentPeekAnimation != null) {
            StopCoroutine(currentPeekAnimation); }
        rectTransformCache.Clear(); }
}