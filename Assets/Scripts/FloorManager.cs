using Assets.Scripts.Entities.Add_Info;
using Assets.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private readonly IFloorRepository floorRepository;

    private Floor Floor;

    public FloorManager()
    {
        floorRepository = new DebugFloorRepository();
        MapManager a = new();
    }

    // Start is called before the first frame update
    void Start()
    {
        Floor = floorRepository.Get(16);
        Debug.Log(Floor.Graph.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
