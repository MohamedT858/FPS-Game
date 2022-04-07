using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Vector3 OriginalPosition;
    public Vector3 ADSPosition;
    public int Damage = 10;
    public int BulletsPerMag = 30;
    public int BulletsLeft;
    public float FireRate = .1f;
    public float WeaponRange = 100;
    float FireTimer;
    public Camera FpsCam;
    float yRotation = -45f;
    public float ImpactForce = 20f;
    public GameObject HitParticles;
    public GameObject BulletImpact;
    public GameObject decal;
    public GameObject MuzzleFlash;
    public Transform ShootungPoint;
    public float ADSSpeed = 7f;
    private Vector3 initialPosition;



    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
        if (FireTimer < FireRate)
            FireTimer += Time.deltaTime;

        ADS();



    }

    private void Fire()
    {
        if (FireTimer < FireRate) return;

        FireTimer = 0.0f;

        RaycastHit hit;

        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, WeaponRange))
        {
            Targets target = hit.transform.GetComponent<Targets>();
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
            if (target != null)
            {
                target.TakenDamage(Damage);
            }

            GameObject Dust = Instantiate(HitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            GameObject Decal = Instantiate(decal, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            GameObject ImpactDebris = Instantiate(BulletImpact, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));


        }


    }


    private void ADS()
    {

        if (Input.GetButton("Fire2"))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, ADSPosition, Time.deltaTime * ADSSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime * ADSSpeed);
        }
    }


    }

