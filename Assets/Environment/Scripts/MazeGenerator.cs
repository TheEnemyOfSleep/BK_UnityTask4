using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private MazeNode _nodePrefub;
    [SerializeField] private Vector2Int _mazeSize;
    [SerializeField] float _nodeSize = 1f;
    [SerializeField] Transform _playerPosition;
    [SerializeField] Transform _interactionCylinderPosition;

    public MazeNode NodePrefub
    {
        get => _nodePrefub;
        set => _nodePrefub = value;
    }

    public Vector2Int MazeSize
    {
        get => _mazeSize;
        set => _mazeSize = value;
    }

    public float NodeSize
    {
        get => _nodeSize;
        set => _nodeSize = value;
    }

    public Transform PlayerPosition
    {
        get => _playerPosition;
        set => _playerPosition = value;
    }

    public Transform InteractionCylinderPosition
    {
        get => _interactionCylinderPosition;
        set => _interactionCylinderPosition = value;
    }

    private void Start()
    {
        _mazeSize = new Vector2Int(ApplicationModel.MazeTiles, ApplicationModel.MazeTiles);
        GenerateMazeInstant(_mazeSize);
    }

    private void GenerateMazeInstant(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();
        _nodePrefub.transform.localScale = new Vector3(_nodeSize, _nodeSize, _nodeSize);
        // Create nodes
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 nodePosition = new Vector3(_nodeSize * x - (size.x / 2f), _nodeSize / 2f, _nodeSize * y - (size.y / 2f));
                if (x == 0 && y == 0)
                    _playerPosition.localPosition = nodePosition + new Vector3(0, 0, _nodeSize / 2f);
                else if (x == size.x - 1 && y == size.y - 1)
                {
                    nodePosition.ToString();
                    _interactionCylinderPosition.localPosition = nodePosition + new Vector3(0, 0, _nodeSize / 2f);
                }
                MazeNode newNode = Instantiate(_nodePrefub, nodePosition, Quaternion.identity, transform);
                nodes.Add(newNode);
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        // Choose starting node
        currentPath.Add(nodes[UnityEngine.Random.Range(0, nodes.Count)]);

        while (completedNodes.Count < nodes.Count)
        {
            // Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1)
            {
                // Check node to the right of the current node
                if(!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                   !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                // Check node to the left of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                // Check node to the above of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                // Check node to the below of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                { 
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            // Choose next node
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = UnityEngine.Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
            }
            else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

}
