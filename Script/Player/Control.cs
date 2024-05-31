using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Control : Singleton<Control>
{
    float x = 0;
    float z = 0;
    private float y = 0;
    public Vector3 vec = Vector3.zero;
    [Header("MoveSpeed")]
    [SerializeField]
    public float speed = 3.0f;
    [Header("JumpPower")]
    [SerializeField]
    public float jumpPower = 8;
    private Rigidbody rigid;
    public GameObject GameOverUi;
    public GameObject GameOverBackGround;
    public GameObject RePlayButton;
    
    //시작 세이브 포인트
    public Vector3 StartPointVec;
    public Vector3 StartPointObject = new Vector3(16,-4.9f,-332); 
    
    //LV2로 이동하는 포인트
    public Transform LV2StartPoint;
    
    public int JumpCount = 0;
    public GameObject STOPBackGround;
    public GameObject STOPButton;
    public GameObject StartButton;
    
    private Transform cameraTransform;
    public GameObject SpeedUpBackGround;
    public GameObject JumpSpeedUpBackGround;
    public GameObject LifeUpBackGround;
    public Animator anim;
    public Camera camera;
    
    public GameObject WarringBackGround;
    
    public GameObject[] lifeList ;
    private int lifeCount = 0;
    
    // 소지금
    public int MyMoney = 0;
    public Text MyMoney_String;

    public GameObject NotBuyBackGround;
    
    // 점수
    public int Score = 0;
    public Text Score_String;
    
    //쿹타임
    private bool canUseSkill = true;
    
    // 죽은 숫자
    public Text DieCountText;
    public int DieCountInt;
    
    //스킬 사용시 발사되는 구체
    public GameObject SkillPrefab;
    private List<GameObject> SkillObjectPool = new List<GameObject>();
    private GameObject obj = null;
    public Transform Target;
    
    //일시적 움직임 차단
    public bool isMove = true;
    
    //일반 공격시 형성되는 것
    public GameObject AttackPrefab;
    private List<GameObject> AttackObjectPool = new List<GameObject>();
    private GameObject AttackObj = null; // 공격시 형성되는 작은 오브젝트( 검기 )
    public Transform NomalAttackTarget;
    
    //오디오 소드
    private AudioSource As;
    
    //이미 채력이 풀일떄 경고창
    public GameObject FullWarrning;
    
    [Header("Sound")]
    // 물에 빠져서 사망했을때의 물에 빠지는 소리
    public AudioClip GameOverWaterClip;
    // private AudioSource GameOverWaterSource;
    
    // 52_Dive_02
    public AudioClip SkillSoundClip;
    //private AudioSource SkillSoundSource;
    
    // 61_Hit
    public AudioClip NomalAttackSoundClip;
    //private AudioSource NomalAttackSoundSource;
    
    // 46_Postion
    public AudioClip LifeUpSoundClip;
    //private AudioSource LifeUpSoundSource;
    
    //30_Jump
    public AudioClip JumpSoundClip;
    //private AudioSource JumpSoundSource;
    
    //88_Teleport
    public AudioClip InPotalClip;
    //private AudioSource InPotalSource;
    
    //08_Step
    public AudioClip MoveSoundClip;
    //private AudioSource MoveSoundSource;
    
    public AudioClip CountUpClip;
    //private AudioSource CountUpSource;
    
    public AudioClip PowerUpClip;
    //private AudioSource PowerUpSource;

    public AudioClip SpeedUpClip;
    //private AudioSource SpeedUpSource;

    public AudioClip AddItemClip;
    //private AudioSource AddItemSource;

    public AudioClip BeHitClip;
    //private AudioSource BeHitSource;
    
    
    //점프
    private bool isJump = false;
    //죽음
    private bool isDie = false;

    public AudioClip DieSound;
    //private AudioSource DieSource;
    
    
    
    
    
    
    
    public void StartInit()
    {
        rigid = GetComponent<Rigidbody>();
        GameOverUi.SetActive(false);
        GameOverBackGround.SetActive(false);
        RePlayButton.SetActive(false);
        transform.position = StartPointObject; // 플레이어 위치 배정
        StartPointVec = StartPointObject;
        StartButton.SetActive(false);
        STOPButton.SetActive(true);
        STOPBackGround.SetActive(false);
        // SpeedUpBackGround.SetActive(false);
        //JumpSpeedUpBackGround.SetActive(false);
        //LifeUpBackGround.SetActive(false);
        WarringBackGround.SetActive(true);
        NotBuyBackGround.SetActive(false);
        
        // 생명 포인트 변수
        lifeCount = lifeList.Length;
        
        // 점수 및 데스 카운트 초가화
        Score = 0;
        DieCountInt = 0;
        
        //채력 초기화
        lifeList[0].SetActive(true);
        lifeList[1].SetActive(true);
        lifeList[2].SetActive(true);
        lifeList[3].SetActive(true);
        lifeList[4].SetActive(true);
        
        //사운드
        As = gameObject.GetComponent<AudioSource>();

    }
    
    // 싱글톤 수정
    public void Fun()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void LateUpdate()
    {
        // 마우스 위치에 따른 플레이어 이동
        transform.rotation = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
    }

    private void Update()
    {
        //UI
        MyMoney_String.text = MyMoney.ToString();
        Score_String.text = Score.ToString();
        DieCountText.text = DieCountInt.ToString();
        if (isMove == true)
        {
            vec.x = Input.GetAxis("Horizontal");
            vec.z = Input.GetAxis("Vertical");
            if ((vec.x != 0 || vec.z != 0) && !As.isPlaying)
            {
                As.PlayOneShot(MoveSoundClip);
            }
        }
        else if(isMove == false)
        {
            vec = Vector3.zero;
        }
        
        

        if (vec.x > 0)
        {
            anim.SetBool("RightMove",true);
            //MoveSoundSource.PlayOneShot(MoveSoundClip);
            transform.Translate(vec.normalized * Time.deltaTime * speed);
        }
        else
        {
            anim.SetBool("RightMove",false);
            //MoveSoundSource.PlayOneShot(MoveSoundClip);
            transform.Translate(vec.normalized * Time.deltaTime * speed);
        }
        if (vec.x < 0)
        {
            anim.SetBool("LeftMove",true);
            //MoveSoundSource.PlayOneShot(MoveSoundClip);
            transform.Translate(vec.normalized * Time.deltaTime * speed);
        }
        else
        {
            anim.SetBool("LeftMove",false);
            //MoveSoundSource.PlayOneShot(MoveSoundClip);
            transform.Translate(vec.normalized * Time.deltaTime * speed);
        }
        if (vec.z > 0)
        {
            anim.SetBool("Run", true);
            anim.SetBool("BackRun", false);
            //MoveSoundSource.PlayOneShot(MoveSoundClip);
            transform.Translate(vec.normalized * Time.deltaTime * speed);
        }
        else if (vec.z < 0)
        {
            anim.SetBool("Run", false);
            anim.SetBool("BackRun", true);
            //MoveSoundSource.PlayOneShot(MoveSoundClip);
            transform.Translate(vec.normalized * Time.deltaTime * speed);
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("BackRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpCount += 1;
            anim.SetBool("Jump",true);
            As.PlayOneShot(JumpSoundClip);
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else if (JumpCount == 1)
        {
            jumpPower = 0;
        }
        else
        {
            anim.SetBool("Jump",false);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Score += 1;
            anim.SetBool("Roll",true);
            As.PlayOneShot(JumpSoundClip);
            rigid.AddForce(transform.forward * 5,ForceMode.Impulse);
            Invoke("NoRoll",2f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            anim.SetBool("NomalAttack", true);
        }

        // 단독함수
        WarringBackGroundOpen();
        
        //스킬
        if (Input.GetKeyDown(KeyCode.Alpha1) && canUseSkill)
        {
            
            Score += 10;
            anim.SetBool("Skill", true);
            Invoke("NoSkill",1f);
            StartCoroutine(StartSkillCooldown(2f));
        }
        
        // 공격
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            As.PlayOneShot(NomalAttackSoundClip);
            Score += 5;
            anim.SetBool("NomalAttack",true);
            Invoke("NoNomalAttack",1f);
            if (AttackObj == null)
            {
                    AttackObj = Instantiate(AttackPrefab, NomalAttackTarget.position, NomalAttackTarget.rotation);
                    
            }
            else
            { 
                AttackObj.transform.position = Target.transform.position;
                AttackObj.transform.rotation = Target.transform.rotation;
                AttackObj.SetActive(true);
            }
        }
    }
    
    
    // 아이템 및 외부코드로 부터 아이템이 사용된 경우의 함수
    
    // 회복아이템 사용
    public void LifeUp()
    {
        if (lifeCount < lifeList.Length)
        {
            lifeList[lifeCount].SetActive(true);
            As.PlayOneShot(LifeUpSoundClip);
            lifeCount += 1;
            Score += 10;
        }
        else
        {
            FullWarrning.SetActive(true);
            Invoke("isFullWarrning", 2f); 
        }
    }
    
    //점프 파워증가 아이템 사용
    public void Player_JumpPowerUp_UseItem()
    {
        jumpPower += 5;
        As.PlayOneShot(PowerUpClip); 
    }
    //점프 횟수 증가 아이템 사용
    public void Player_JumpCountUp_UseItem()
    {
        JumpCount -= 1;
        As.PlayOneShot(CountUpClip);
    }
    
    // 모든 아이템 습득 소리
    public void Player_AddItem()
    {
        As.PlayOneShot(AddItemClip); 
    }
    
    // 스피드 증가 아이템 사용
    public void Player_SpeedUp_UseItem()
    {
        speed += 3;
        As.PlayOneShot(SpeedUpClip);
        Invoke("SpeedIUpnit",2f);
    }

    public void SpeedIUpnit()
    {
        speed -= 3;
    }

    public void BeHitSound()
    {
        As.PlayOneShot(BeHitClip);
    }

    public void isFullWarrning()
    {
        FullWarrning.SetActive(false);
    }
    
    IEnumerator StartSkillCooldown(float cooldownTime)
    {
        canUseSkill = false;
        if (obj == null)
        {
            obj = Instantiate(SkillPrefab, Target.transform.position, camera.transform.rotation);
            As.PlayOneShot(SkillSoundClip);
        }
        else
        {
            obj.transform.position = Target.transform.position;
            obj.transform.rotation = camera.transform.rotation;
            obj.SetActive(true);
            As.PlayOneShot(SkillSoundClip);
        }

        yield return new WaitForSeconds(4f);
        obj.SetActive(false);
        // 기술 사용 후 대기 시간
        yield return new WaitForSeconds(cooldownTime);
        canUseSkill = true;
    }
    void NoRoll()
    {
        anim.SetBool("Roll",false);
    }

    void NoNomalAttack()
    {
        anim.SetBool("NomalAttack",false);
        AttackObj.SetActive(false);
    }

    void NoSkill()
    {
        anim.SetBool("Skill",false);
    }
    
    public void WarringBackGroundOpen()
    {
        Invoke("InvokeWarringBackGroundOpen",5f);
    }

    public void InvokeWarringBackGroundOpen()
    {
        WarringBackGround.SetActive(false);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GameOverGround"))
        {
            As.PlayOneShot(GameOverWaterClip);
            DieCountInt += 1;
            gameObject.SetActive(true);
            GameOverUi.SetActive(true);
            GameOverBackGround.SetActive(true);
            StartCoroutine(OpenRestartButtonAfterDelay(2f));
        }

        else if (other.gameObject.CompareTag("legs"))
        {
            transform.SetParent(other.transform);
            JumpCount = 0;
            jumpPower = 8;
            Score += 20;
        }
        
        else if (other.gameObject.CompareTag("RotateGround"))
        {
            transform.SetParent(other.transform);
            JumpCount = 0;
            jumpPower = 8;
            Score += 30;
        }

        else if (other.gameObject.CompareTag("Ground"))
        {
            JumpCount = 0;
            jumpPower = 8;
            Score += 10;
        }
        
        
        else if (other.gameObject.CompareTag("InLv2Potal"))
        {
            As.PlayOneShot(InPotalClip);
            Score += 100;
            transform.position = LV2StartPoint.transform.position; 
        }
        
        else if (other.gameObject.CompareTag("Trap1"))
        {
            JumpCount = 0;
            jumpPower = 8;
        }
        
        

        // 대포 맞으면 플레이어 채력 깍음
        else if (other.gameObject.CompareTag("Bullet"))
        {
            HitST(other);
        }
        else if (other.gameObject.CompareTag("Rock"))
        {
            HitST(other); 
        }

        else if(other.gameObject.CompareTag("SISOAttack"))
        {
            HitST(other);
        }
        
        else if(other.gameObject.CompareTag("BackTrap"))
        {
            HitST(other);
        }
        
        else if(other.gameObject.CompareTag("PunchTrap"))
        {
            HitST(other);
        }



        
        //아이템과 부딪혀서 습득을 하다.
        else if (other.gameObject.CompareTag("Item"))
        {
            Player_AddItem();
            other.gameObject.SetActive(false);
            PickUp(other);
            StartCoroutine(ReItem(other));
        }
        /*
         * public void PickUp(Collision other)
           {
           // Debug.Log("아이템을 주움");
           Item itemComponent = other.gameObject.GetComponent<Item>();
           Inventory.instance.Registration(itemComponent);
           }
         */
        
        
        
        else if (other.gameObject.CompareTag("MiddleSave1"))
        {
            StartPointVec = other.transform.position;
            As.PlayOneShot(InPotalClip);
        }
        
        else if (other.gameObject.CompareTag("MiddleSave2"))
        {
            StartPointVec = other.transform.position;
            As.PlayOneShot(InPotalClip);
        }
        
        else if (other.gameObject.CompareTag("RotateRock"))
        {
            HitST(other);
        }
        
        else if (other.gameObject.CompareTag("circularSword"))
        {
            HitST(other);
        }
        
        else if (other.gameObject.CompareTag("Enemy"))
        {
            HitST(other);
        }
        else if (other.gameObject.CompareTag("EnemyAttackObject"))
        {
            HitST(other);
        }
    }

    IEnumerator ReItem(Collision other)
    {
        yield return new WaitForSeconds(10f);
        other.gameObject.SetActive(true);
    }

    public void HitST(Collision other)
    {
        BeHitSound();
        ImHit(other);
        Dying();
    }

    public void ImHit(Collision other)
    {
        anim.SetBool("Body_Hit",true);
        Invoke("TimeHitOut",1f);
        if (other.gameObject.CompareTag("BackTrap"))
        {
            other.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("RotateRock"))
        {
            other.gameObject.SetActive(true);   
        }
        else if (other.gameObject.CompareTag("circularSword"))
        {
            other.gameObject.SetActive(true);   
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(true);   
        }
        else if (other.gameObject.CompareTag("SISOAttack"))
        {
            other.gameObject.SetActive(true);   
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(true);   
        }
        else
        {
            other.gameObject.SetActive(false); 
        }
        
        lifeList[lifeCount - 1].SetActive(false);
    }

    public void SpeedInit()
    {
        speed -= 2;
    }

    IEnumerator ResponSpeedUPItem(Collision other)
    {
        yield return new WaitForSeconds(2f);
        other.gameObject.SetActive(true);   
    }

    IEnumerator ResponJumpUPItem(Collision other)
    {
        yield return new WaitForSeconds(2f);
        other.gameObject.SetActive(true); 
    }

    IEnumerator ResponLifeUpItem(Collision other)
    {
        yield return new WaitForSeconds(2f);
        other.gameObject.SetActive(true);   
    }
    
    IEnumerator ResponGetGoldItem(Collision other)
    {
        yield return new WaitForSeconds(2f);
        other.gameObject.SetActive(true);   
    }

    IEnumerator ResponJumpCountUPItem(Collision other)
    {
        yield return new WaitForSeconds(2f);
        other.gameObject.SetActive(true); 
    }

    // 아이템을 주운후에 인벤토리에 보내기 위한 수단.
    public void PickUp(Collision other)
    {
        // Debug.Log("아이템을 주움");
        Item itemComponent = other.gameObject.GetComponent<Item>();
        Inventory.instance.Registration(itemComponent);
    }

    
    

    void TimeGameOverUi()
    {
        GameOverUi.SetActive(true);
        GameOverBackGround.SetActive(true);
        RePlayButton.SetActive(true);
    }

    void TimeHitOut()
    {
        anim.SetBool("Body_Hit",false);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("legs"))
        {
            transform.parent = null;
        }
        
        else if (other.gameObject.CompareTag("RotateGround"))
        {
            transform.parent = null;
        }
    }

    public void Dying()
    {
        if (lifeCount == 1)
        {
            if (isDie == false)
            {
                isDie = true;
                speed = 0;
                DieCountInt += 1;
                lifeList[lifeCount - 1].SetActive(false);
                anim.SetBool("Dying",true);
                isMove = false;
                As.PlayOneShot(DieSound);
                Invoke("TimeGameOverUi",4f);
            }
        }
        else
        {
            lifeCount--; 
        }
    }

    private IEnumerator OpenRestartButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RePlayButton.SetActive(true);
        Time.timeScale = 0f;
    }



    public void ReStart()
    {
        isDie = false;
        anim.SetBool("Dying",false);
        speed = 0;
        Time.timeScale = 1f;
        GameOverUi.SetActive(false);
        GameOverBackGround.SetActive(false);
        RePlayButton.SetActive(false);
        LifeCountInit(lifeCount);
        transform.position = StartPointVec;
        Invoke("MoveTrue",1f);
    }

    public void MoveTrue()
    {
        
        isMove = true;
        speed = 3;
    }
    
    //남은 채력을 다시 5로 채워주기 위한 함수
    public void LifeCountInit(int LifeCount)
    {
        for (int i = 0; i < 5 - LifeCount; i++)
        {
            lifeList[lifeCount].SetActive(true);
            lifeCount++;
        }
        lifeList[0].SetActive(true);
    }




    public void OnStop()
    {
        Time.timeScale = 0f;
        STOPBackGround.SetActive(true);
        STOPButton.SetActive(false);
        StartButton.SetActive(true);
    }

    public void OffStop()
    {
        Time.timeScale = 1f;
        STOPBackGround.SetActive(false);
        STOPButton.SetActive(true); 
        StartButton.SetActive(false);
    }

    public void BuyBtnFunSion()
    {
        if (MyMoney < 20)
        {
            NotBuyBackGround.SetActive(true);
            Invoke("NotButBackGroundAutoFalse",2f);
        }
        else
        {
            LifeUp();
            MyMoney -= 20;
        }
    }

    public void NotButBackGroundAutoFalse()
    {
        NotBuyBackGround.SetActive(false);
    }
    
}

