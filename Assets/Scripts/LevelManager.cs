using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform level;
    [SerializeField] NavMeshAgent playerPrefab;
    [SerializeField] Piece[] pieces;
    int counter=0;

    [SerializeField] [Range(3, 100)] int targetPieces = 3;

    int halfTargetPieces;

    [SerializeField] int activePiece;
    
    const int PieceSize = 10;

    NavMeshSurface surface;

    readonly Dictionary<int, Piece> activePieces = new Dictionary<int, Piece>();

    ///timer
    public float time;
    public bool strt, stp, rst;

    void Awake()
    {
        surface = level.GetComponent<NavMeshSurface>();
        
        if (level == null ||  surface == null)
        {
            Debug.LogError("Level of LevelManager must be assigned and must have at least one NavMeshSurface");
            gameObject.SetActive(false);
        }
    }

    void Start()
    {

        halfTargetPieces = targetPieces / 2;
        for (int i = -1 * halfTargetPieces; i < halfTargetPieces + 1; i++)
        {
            SpawnPiece(i == halfTargetPieces, i);
        }

        SpawnPlayer();
        //timer
        time = 0;
        strt = true;
        stp = false;
        rst = false;
    }

    void SpawnPiece(bool bakeNavMesh, int pieceIndex)
    {
        if (activePieces.ContainsKey(pieceIndex))
        {
            return;
        }

        int index = Random.Range(0, pieces.Length-1);

        //After 10 pieces it will always spawn the last piece (Which could be endzone)
        if(counter >= 15)
        {
            index = pieces.Length-1;
        }
        counter++;



        Piece spawnedObject = Instantiate(pieces[index]);

        if (spawnedObject != null)
        {
            activePieces.Add(pieceIndex, spawnedObject);
            spawnedObject.transform.position = new Vector3(PieceSize * pieceIndex, 0, 0);
            spawnedObject.OnReachStart += HandleReachStart;
            spawnedObject.OnReachEnd += HandleReachEnd;
            spawnedObject.index = pieceIndex;
            spawnedObject.transform.SetParent(level, true);

            if (bakeNavMesh)
            {
                surface.BuildNavMesh();
            }
        }
    }

    void HandleReachEnd(Piece piece)
    {
        if (piece.index == activePiece)
        {
            SpawnPiece(true, activePiece + halfTargetPieces + 1);
        }
        else if (piece.index < activePiece)
        {
            TrimPieces();
            SpawnPiece(true, activePiece - halfTargetPieces - 1);
            activePiece = piece.index;
        }
    }
    
    void HandleReachStart(Piece piece)
    {
        if (piece.index > activePiece)
        {
            activePiece = piece.index;
            TrimPieces();
        }
    }

    void TrimPieces()
    {
        foreach (int key in activePieces.Keys)
        {
            if (key > halfTargetPieces + activePiece || key < activePiece - halfTargetPieces)
            {
                activePieces[key].gameObject.SetActive(false);
                Destroy(activePieces[key].gameObject); // should pool
                activePieces.Remove(key);
                return;
            }
        }
    }

    void SpawnPlayer()
    {
        NavMeshAgent agent = Instantiate(playerPrefab);
    }
}