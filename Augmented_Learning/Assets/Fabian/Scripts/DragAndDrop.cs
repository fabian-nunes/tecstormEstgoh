using UnityEngine;
using System.Collections;
 
public class DragAndDrop : MonoBehaviour {
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;
 
    void Update() {
        Vector3 v3;
 
        if (Input.touchCount != 1) {
            dragging = false; 
            return;
        }
 
        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;
 
        if(touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(pos); 
            if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
            {
                this.transform.position = new Vector3(2.39f, 0.12f, 1f);
                Debug.Log("ads");
            }
        }
        
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
            dragging = false;
        }
    }
}