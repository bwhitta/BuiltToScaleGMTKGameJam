using UnityEngine;

public class AdaptAttributes : MonoBehaviour
{
    [SerializeField] private float gravityPower = 1;

    private Rigidbody2D usedRigidbody;
    [SerializeField] bool onEnemy;
    private CharacterControls characterControls;
    private EnemyLogic enemyLogic;

    private void Start()
    {
        usedRigidbody = GetComponent<Rigidbody2D>();
        if(onEnemy)
            enemyLogic = GetComponent<EnemyLogic>();
        else
            characterControls = GetComponent<CharacterControls>();
    }
    void Update()
    {
        usedRigidbody.gravityScale = (ResolutionManager.height / Screen.height) * gravityPower;
        if(onEnemy)
            enemyLogic.speed = enemyLogic.baseSpeed * (ResolutionManager.height / Screen.height);
        else
            characterControls.speed = characterControls.baseSpeed * (ResolutionManager.height / Screen.height);
    }
}
