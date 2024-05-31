using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //AI
    private NavMeshAgent nav;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float DetectionRange = 20f;
    [SerializeField] private float SkillAttackDetectionRange = 25;
    
    //플레이어를 감지
    public Transform PlayerFind;
    
    //발사체
    public GameObject EnemyAttackPrefab;
    public Transform SkillAttackTarget;
    private GameObject Obj = null;
    private Coroutine AttackColl = null; // 코루틴 변수

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float dinstanceToPlayer = Vector3.Distance(gameObject.transform.position, PlayerFind.gameObject.transform.position);

        if (dinstanceToPlayer < DetectionRange)
        {
            // Debug.Log("근접");
                nav.isStopped = false;
                nav.SetDestination(PlayerFind.gameObject.transform.position);
        }
        else if(dinstanceToPlayer < SkillAttackDetectionRange)
        {
            // Debug.Log("멀리");
            transform.LookAt(PlayerFind);
            if (AttackColl == null)
            {
                AttackColl = StartCoroutine(Attack()); 
            }
        }
        else
        {
            nav.SetDestination(gameObject.transform.position);
        }
    }

    IEnumerator Attack()
    {
        if (Obj == null)
        {
            Obj = Instantiate(EnemyAttackPrefab, SkillAttackTarget.position,
                SkillAttackTarget.rotation);
        }
        else
        {
            Obj.gameObject.transform.position = SkillAttackTarget.position;
            Obj.gameObject.transform.rotation = SkillAttackTarget.rotation;
            Obj.SetActive(true);
        }
        nav.isStopped = true;
        yield return new WaitForSeconds(8f);
        Obj.SetActive(false);
        AttackColl = null;
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody Player = other.rigidbody;
        if (other.gameObject.CompareTag("Player"))
        {
            Player.AddForce(10,0,0,ForceMode.Impulse); 
        }
    }
}

