using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseMaster : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject planetPrefab;
    public GameObject moonPrefab;

    public float gravitationalConstant = 500f;
    public float timestep = 0.01f;
    public List<GameObject> celestialBodies;

    private void Awake()
    {
        Time.fixedDeltaTime = timestep;
        foreach (CelestialBody celestialBody in FindObjectsOfType<CelestialBody>())
        {
            celestialBodies.Add(celestialBody.gameObject);
        }
    }

    private void Start()
    {
        ResetUniverse();
    }

    private void FixedUpdate()
    {
        foreach (GameObject celestialObject in celestialBodies)
        {
            celestialObject.GetComponent<CelestialBody>().FixedTick();
        }
    }

    public void ResetUniverse()
    {
        GameObject star = Instantiate(starPrefab, Vector3.right * 20, new Quaternion(0, 0, 0, 0));
        celestialBodies.Add(star);
        GameObject planet = Instantiate(planetPrefab, Vector3.right * 10, new Quaternion(0, 0, 0, 0), star.transform);
        celestialBodies.Add(planet);
        CelestialBody planetBody = planet.GetComponent<CelestialBody>();
        planetBody.universe = gameObject;
        planetBody.host = star;
    }
}

