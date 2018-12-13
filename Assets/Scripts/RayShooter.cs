//Game Programming HW1 
//====================================================================================================================
// Name        : Rayshooter.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to Camera(PLayer is parent) and allows player to shoot IFF they are not dead.
//====================================================================================================================

using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;


    //Sound Source
    [SerializeField] private AudioSource soundSource; //player object
    [SerializeField] private AudioClip bulletSound; //audio clip
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject fireballPrefabWeapon2;

    private GameObject _fireball;
    private GameObject _fireball2;





    //To attach bullet picture to hitpoint
    public GameObject Shotgun_bullet_hole;
    public GameObject AK47_bullet_hole;
    private int damage = 1;


    void Start()
    {
        _camera = GetComponent<Camera>();
        lockCurser();
    }

    public static void lockCurser()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void unlockCurser()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Player").GetComponent<PlayerCharacter>()._health > 0)
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            soundSource.PlayOneShot(bulletSound);




            // if (Physics.Raycast(ray, out hit))
            // {
            //     GameObject hitObject = hit.transform.gameObject;
            //     ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

            //     if (target != null)
            //     {
            //target.ReactToHit(damage);
            //     }
            //     else
            //     {
            //StartCoroutine(SphereIndicator(hit.point));

            //         Debug.Log(WeaponToggleScript.currentWeapon);


            if (WeaponToggleScript.currentWeapon == 0)
            {
                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position = transform.TransformPoint(-0.3f, 0.15f, 1 * 1.5f);
                _fireball.transform.rotation = transform.rotation;

                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position = transform.TransformPoint(0.3f, 0.15f, 1 * 1.5f);
                _fireball.transform.rotation = transform.rotation;

                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position = transform.TransformPoint(0, -0.4f, 1 * 1.5f);
                _fireball.transform.rotation = transform.rotation;
            }

            else
            {
                _fireball2 = Instantiate(fireballPrefabWeapon2) as GameObject;
                _fireball2.transform.position = transform.TransformPoint(0, 0.15f, 1 * 1.5f);
                _fireball2.transform.rotation = transform.rotation;
            }
        }
    }
}


//    private IEnumerator SphereIndicator(Vector3 pos) {
//        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        sphere.transform.position = pos;

//        yield return new WaitForSeconds(1);

//        Destroy(sphere);
//    }
//}