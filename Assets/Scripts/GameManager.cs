using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 이 변수를 통해서만 GameManager에 접근이 가능
    public static GameManager Instance { get; private set; }

    // 점수 저장 변수
    private int score = 0;

    // 점수 표시 텍스트
    public Text scoreText;

    // 플레이어 오브젝트
    public Player player;
    // 시작 깃발
    public Start startFlag;

    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 이동해도 유지
        }
        else
        {
            Destroy(gameObject); // 두번째 생성된 GameManager는 삭제
        }
    }

    private void Start()
    {
        // 최초 시작 시 플레이어와 깃발이 정상적으로 변수로 설정되어있을 경우
        if (player != null && startFlag != null)
        {
            // 플레이어의 위치를 깃발의 위치로 이동시킴
            player.transform.position = startFlag.transform.position;
        }
    }

    // 점수 증가 함수
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    // UI 업데이트
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score : {score}";
    }
}
