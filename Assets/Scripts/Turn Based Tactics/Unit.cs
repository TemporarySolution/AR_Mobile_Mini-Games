using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public string NAME = "Копейщик";
    public float HP = 10;
    public float DMG = 2;
    public float ATTACK_RANGE = 2;
    public int TEAM = 0;
    public bool SELECTED = false;
    public GameObject StatHud = null;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        UpdHud();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool TryAttack(GameObject Target)
    {
        print("Пробуем атаковать");
        float distance = Vector3.Distance(Target.transform.position, gameObject.transform.position);
        if (distance > ATTACK_RANGE*gameObject.transform.localScale.x + 0.4f)
        {
            print("Вне радиуса аттаки");
            return false;
        }
        
        if (!SELECTED)
        {
            print("Юнит не выбран");
            return false;
        }
        //if (!TEAM_TURN)
        //{
        //    print("Сейчас не ваш ход!");
        //    return;
        //}
        if (Target.GetComponent<Unit>().TEAM == TEAM)
        {
            print("Цель в вашей команде!");
            return false;
        }
        print("Атака прошла!");
        Attack(Target);
        return true;
    }
    public void Attack(GameObject Target)
    {
        //PlayAnim - Attack
        StartCoroutine(AttackAnim());
        Target.GetComponent<Unit>().GetDamaged(gameObject);
    }
    IEnumerator AttackAnim()
    {
        //PlayAnim - Attack
        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(1);
        //PlayAnim - Idle
        anim.SetBool("isAttacking", false);
    }
    public void GetDamaged(GameObject Attacker)
    {
        print("Цель получила урон!");
        //PlayAnim - TakeDamage
        
        HP = HP - Attacker.GetComponent<Unit>().DMG;
        UpdHud();
        StartCoroutine(GetDamagedAnim(HP));
    }
    IEnumerator GetDamagedAnim(float HP)
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("isTakingDamage", true);
        //PlayAnim - Attack
        if (HP > 0)
        {
            yield return new WaitForSeconds(0.4f);
            anim.SetBool("isTakingDamage", false);
        }
        else
        {
            StartCoroutine(Die());
        }
    }
        IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        //PlayAnim - Die
        anim.SetBool("IsDying1", true);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    
    public void SetSelected()
    {
        UpdHud();
        SELECTED = true;
        gameObject.GetComponent<Outline>().OutlineColor = Color.green;
        ShowHud();
    }
    public void SetSelectedAsEnemy()
    {
        UpdHud();
        SELECTED = true;
        gameObject.GetComponent<Outline>().OutlineColor = Color.red;
        ShowHud();
    }
    public void SetDeselected()
    {
        UpdHud();
        SELECTED = false;
        gameObject.GetComponent<Outline>().OutlineColor = Color.clear;
        HideHud();
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        print(collision.gameObject.layer);
        if (collision.gameObject.layer != TEAM+10)
        {
            anim.SetBool("isInBattle", true);
        }
        print("Вступаю в бой!");
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer != TEAM + 10)
        {
            anim.SetBool("isInBattle", false);
        }
        print("Выхожу из боя!");
    }
    public void ShowHud() { StatHud.SetActive(true); }
    public void HideHud() { StatHud.SetActive(false); }
    public void UpdHud() 
    { 
        gameObject.GetComponent<SphereCollider>().radius = ATTACK_RANGE;
        StatHud.transform.Find("StatHud/Body/HP/HP(Text)").gameObject.GetComponent<TextMeshProUGUI>().text = "" + HP;
        StatHud.transform.Find("StatHud/Body/DMG/DMG(Text)").GetComponent<TextMeshProUGUI>().text = "" + DMG; ;
        StatHud.transform.Find("StatHud/Body/Name/Name(Text)").GetComponent<TextMeshProUGUI>().text = "" + NAME; ;
        StatHud.transform.Find("AttackRadius/AttackRange").transform.localScale = new Vector3(ATTACK_RANGE, ATTACK_RANGE, ATTACK_RANGE);
    }



}
