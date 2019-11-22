using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonComponent<LevelController>
{
    [SerializeField] private Camera _mainCamera;
    
    private Transform _cameraTransform;
    public EntitiesCollection EntitiesCollection { get; private set; }

    private ScoreController ScoreController = new ScoreController();
    public IScoreOutput ScoreOutput { get; private set; }
    public Camera MainCamera => _mainCamera;

    public Transform CameraTransform => _cameraTransform == null ? _cameraTransform = _mainCamera.transform : _cameraTransform;
    protected override LevelController _instance => this;

    protected override void Awake()
    {
        base.Awake();
        
        Init();
    }

    private List<IDisposable> _disposables = new List<IDisposable>();
    
    private void Init()
    {
        EntitiesCollection = new EntitiesCollection();
        
        ScoreOutput = ScoreController;
        
        _disposables.Add(ScoreController);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
