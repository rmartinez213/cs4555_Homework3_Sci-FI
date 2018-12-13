using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReactiveTarget : MonoBehaviour
{
    private Animator _animator;


    public int EnemyHealth = 2;

    public void ReactToHit(int damage)
    {
        _animator = GetComponent<Animator>();
        WanderingAnim aliveanim = GetComponent<WanderingAnim>(); // for enemy1 anim
        WanderingAI behavior = GetComponent<WanderingAI>();
        HidingAI hiding = GetComponent<HidingAI>();
        RunAwayAI running = GetComponent<RunAwayAI>();
        BossAI boss = GetComponent<BossAI>();
        //        SceneController enemies = GetComponent<SceneController>();
        //        if (enemies == null) {
        //            Debug.LogError("Cant find SceneController ");
        //        }
        EnemyHealth = EnemyHealth - damage;
        Debug.Log("Someone got hit");

        if (EnemyHealth <= 50)
        {
            _animator.SetBool("isLess50", true);
        }

        if (EnemyHealth == 0)
        {

            if (behavior != null)
            {
                behavior.SetAlive(false);
                StartCoroutine(Die());
            }
            if (aliveanim != null)
            {
                aliveanim.SetAlive(false);
                StartCoroutine(Die());
            }
            if (boss != null)
            {
                boss.SetAlive(false);
                StartCoroutine(DieBoss());
            }
        }
        if (hiding != null)
        {
            hiding.SetAlive(false);
            StartCoroutine(Die());
        }
        if (running != null)
        {
            running.SetAlive(false);
            StartCoroutine(Die());
        }





    }

    private IEnumerator Die()
    {

        //this.transform.Rotate(-90, 0, 0);
        //What I added
        //Vector3 pos = transform.position;
        //pos.y = -1.25f;
        //this.transform.position = pos;

        //     _animator.SetBool("isDead", true);


        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }

    private IEnumerator DieBoss()
    {

        //this.transform.Rotate(-90, 0, 0);
        //What I added
        //Vector3 pos = transform.position;
        //pos.y = -1.25f;
        //this.transform.position = pos;

        //     _animator.SetBool("isDead", true);


        yield return new WaitForSeconds(4.5f);
        Destroy(this.gameObject);

        var go = new GameObject("Sacrificial Lamb");
        DontDestroyOnLoad(go);

        foreach (var root in go.scene.GetRootGameObjects())
            Destroy(root);
        SceneManager.UnloadSceneAsync("Scene4");
        SceneManager.LoadScene("EndingCutscene");

    }


}