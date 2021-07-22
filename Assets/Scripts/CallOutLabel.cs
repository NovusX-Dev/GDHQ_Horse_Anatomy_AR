using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallOutLabel : MonoBehaviour
{
    public GameObject targetObj;

    LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        _lineRenderer.startWidth = 0.01f;
        _lineRenderer.endWidth = 0.01f;
        _lineRenderer.enabled = false;
    }

    void Update()
    {
       if(UIManager.Instance.currentAnim >  0)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, this.transform.position);
            _lineRenderer.SetPosition(1, targetObj.transform.position);
        }
    }
}
