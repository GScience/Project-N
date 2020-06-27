using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityController))]
public class PlayerController : MonoBehaviour
{
    private EntityController _entityController;

    void Awake()
    {
        _entityController = GetComponent<EntityController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _entityController.Move(Vector3.up);
    }
}
