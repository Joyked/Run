using UnityEngine;

public class DIContainer : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundDetecter _detecter;
    [SerializeField] private BuoyantForce _buoyantForce;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Ground _groundPrefab;
    [SerializeField] private MoverObject _moverObject;
    [SerializeField] private ScoreText _scoreText;
    [SerializeField] private Counter _counter;
    [SerializeField] private TuchButton _startButton;
    [SerializeField] private TuchButton _nextModelButton;
    [SerializeField] private TuchButton _reverseDirectionButton;
    [SerializeField] private TuchButton _backButton;
    [SerializeField] private CanvasGroup _menuGroup;
    [SerializeField] private CanvasGroup _replayGroup;
    
    private LauncherMenu _launcherMenu;
    private DrawerCanvasBackMenu _drawerCanvasBackMenu;
    private SeterBackMenu _seterBackMenu;

    private void Awake()
    {
        _launcherMenu = GetComponent<LauncherMenu>();
        _drawerCanvasBackMenu = GetComponent<DrawerCanvasBackMenu>();
        _seterBackMenu = GetComponent<SeterBackMenu>();
        
        _launcherMenu.Initialized(_playerMover, _startButton, _menuGroup, _reverseDirectionButton);
        _spawner.Initialized(_groundPrefab);
        _playerMover.Initialize(_detecter, _reverseDirectionButton);
        _moverObject.Initialize(_playerMover);
        _scoreText.Initialized(_counter);
        _drawerCanvasBackMenu.Initialized(_playerMover, _reverseDirectionButton, _replayGroup, _buoyantForce);
        _seterBackMenu.Initialized(_backButton);
        
    }
}
