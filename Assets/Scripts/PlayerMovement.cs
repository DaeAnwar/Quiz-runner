using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public bool MoveByTouch, StartTheGame;


    [SerializeField] private float RoadSpeed, SwipeSpeed;
    [SerializeField] private float cameraFollowSpeed;
   [SerializeField] private Animator animator;
    [SerializeField] private float minXPos, maxXPos;
    [SerializeField] private GameObject tapToStartObj;
    [SerializeField] private Button startGameButton;

    private Camera mainCamera;
    private Vector3 _mouseStartPos, PlayerStartPos;

    private bool _isAbleToMove = false;
    private bool _isAbleToFollow = false;
    private bool _isAbleToSwipe = false;

    public static PlayerMovement Instance;

    public static UnityAction OnGameFinish;

    private void OnEnable()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    private void Start()
    {
        Instance = this;
        mainCamera = Camera.main;
        _mouseStartPos = Vector3.zero;
        PlayerStartPos = transform.position;
    }

    public void StartGame()
    {
        tapToStartObj.SetActive(false);
        startGameButton.gameObject.SetActive(false);
        StartTheGame = true;
        _isAbleToMove = true;
        _isAbleToFollow = true;
        _isAbleToSwipe = true;
        animator.SetBool("StartTheGame", true);

    }

    // Update is called once per frame
    void Update()
    {

        if (StartTheGame)
        {
            if (_isAbleToSwipe)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    MoveByTouch = true;

                }

                if (Input.GetMouseButtonUp(0))
                {
                    MoveByTouch = false;
                }

                if (MoveByTouch)
                {
                    var plane = new Plane(Vector3.up, 0f);

                    float distance;

                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (plane.Raycast(ray, out distance))
                    {
                        Vector3 mousePos = ray.GetPoint(distance);
                        Vector3 desirePos = mousePos - _mouseStartPos;
                        Vector3 move = PlayerStartPos + desirePos;

                        move.x = Mathf.Clamp(move.x, minXPos, maxXPos);
                        move.z = -7f;

                        var player = transform.position;

                        player = new Vector3(Mathf.Lerp(player.x, move.x, Time.deltaTime * SwipeSpeed), player.y, player.z);
                        transform.position = player;
                    }
                } 
            }
            if (_isAbleToMove)
                transform.Translate(Vector3.forward * (RoadSpeed * Time.deltaTime));
        }
    }

    private void LateUpdate()
    {
        if (_isAbleToFollow)
        {
            //mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, transform.position.x, (SwipeSpeed - 5f) * Time.deltaTime),
            //mainCamera.transform.position.y, mainCamera.transform.position.z);

            var DesiredPos = transform.position;
            DesiredPos.z -= 3;
            mainCamera.transform.position = new Vector3(Mathf.Lerp(mainCamera.transform.position.x, transform.position.x, (cameraFollowSpeed - 5f) * Time.deltaTime),
                mainCamera.transform.position.y, Mathf.Lerp(mainCamera.transform.position.z, DesiredPos.z, (cameraFollowSpeed - 5f) * Time.deltaTime));
        }
    }

}
