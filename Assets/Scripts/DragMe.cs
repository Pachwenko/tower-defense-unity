using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public bool dragOnSurfaces = true;

    public GameObject prefab;
    private RectTransform m_DraggingPlane;

    public void OnBeginDrag(PointerEventData eventData) {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        Debug.Log("OnBeginDrag");
        Instantiate(prefab);
        prefab.SetActive(true);

        //SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData data) {
        //Debug.Log("OnDrag");
        if (prefab != null) {

        }
        //SetDraggedPosition(data);
        // Becomes UNMOVEABLE after instantiation, but is on screen prefab.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Becomes UNMOVEABLE after instantiation, but is on screen prefab.transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //CLOSEST ONE SO FAR: prefab.transform.position = Camera.main.ViewportToScreenPoint(Input.mousePosition);
        // WAYYYYYYY OFF: prefab.transform.position = Camera.main.ViewportToWorldPoint(Input.mousePosition);
        //Didn't work Ray ray = Camera.main.ViewportPointToRay(Input.mousePosition);
        //Didn't work Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        prefab.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        prefab.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        //if (m_DraggingIcon != null)
        //    Destroy(m_DraggingIcon);
        prefab.SetActive(true);
    }

    static public T FindInParents<T>(GameObject go) where T : Component {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null) {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}