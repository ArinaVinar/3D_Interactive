using Assets.Scripts;
using Assets.Scripts.Entities.Add_Info;
using Assets.Scripts.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private readonly IFloorRepository _floorRepository;
    private Floor floor;
    [SerializeField]
    private Dictionary<Coordinate, PointGameObject> points = new();
    private List<Coordinate> activePath = new();

    public LineRenderer lineRenderer;
    public GameObject point_prefabs;

    public MapManager()
    {
        _floorRepository = new DebugFloorRepository();
    }

    // Start is called before the first frame update
    void Start()
    {
        floor = _floorRepository.Get(16);
        
        // UIManager.Init();

        SetPoints();
        var from = points.ToList()[0].Value.PointData;
        var to = points.ToList()[^1].Value.PointData;

        CreatePath(from, to);
    }

    public void CreatePath(Point from, Point to)
    {
        activePath = floor.Graph.FindPath(from.Coordinate, to.Coordinate);
        DrawPath();
    }

    public void ClearPath()
    {
        lineRenderer.positionCount = 0;
        activePath = null;
    }

    private void SetPoints()
    {
        for (int i = 0; i < floor.Graph.points.Count; i++)
        {
            GameObject newPoint = Instantiate(point_prefabs,
                new Vector3((float)floor.Graph.points[i].X, 0, (float)floor.Graph.points[i].Y),
                Quaternion.identity);

            Coordinate pointCoordinate = new Coordinate(floor.Graph.points[i].X,
                                                        floor.Graph.points[i].Y);

            var pointGO = newPoint.AddComponent<PointGameObject>();
            pointGO.PointData = new(pointCoordinate, true, "point");

            if(!points.TryAdd(pointCoordinate, pointGO))
                Debug.Log($"{pointGO.PointData.Coordinate} collision detected");
        }
    }

    private void DrawPath()
    {
        lineRenderer.positionCount = activePath.Count;
        for (int i = 0; i < activePath.Count; i++)
        {
            lineRenderer.SetPosition(i,
                new Vector3((float)activePath[i].X, 0, (float)activePath[i].Y));
        }
    }

}
