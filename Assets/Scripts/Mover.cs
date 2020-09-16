using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 toPos;
    public Vector3 dir;
    public float moveTime;
    [Range(1.0f, 5.0f)]
    public float moveSpeed = 4.0f;
    public bool backMove = false;

    void Start()
    {
        toPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessKeyInputs();
        ProcessMouseInputs();

        if(moveTime > 0)
        {
            Vector3 pos = transform.position;
            pos += dir * moveSpeed * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -4, 4);
            pos.z = Mathf.Clamp(pos.z, -4, 4);
            transform.position = pos;

            moveTime -= Time.deltaTime;
            transform.forward = Vector3.Lerp(transform.forward, backMove ? -dir : dir, Time.deltaTime * 6.5f);
        }
    }

    void ProcessKeyInputs()
    {
        if(Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            moveTime = 0;
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
            moveTime = 0;
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
            moveTime = 0;
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
            moveTime = 0;
        }
    }

    void ProcessMouseInputs()
    {
        if(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject != null)
            return;

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, 10000)) {
                if(hitInfo.collider.name.Equals("Ground")) {
                    Vector3 pos = hitInfo.point;
                    dir = (pos - transform.position);
                    moveTime = dir.magnitude / 4.0f;
                    dir = dir.normalized;
                    if(Input.GetMouseButtonDown(1)) {
                        dir = -dir;
                        backMove = true;
                    }
                    else {
                        backMove = false;
                    }
                }
            }
        }
    }
}
