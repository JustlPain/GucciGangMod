//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class BloodSplatterScript : MonoBehaviour
{
    private GameObject[] bloodInstances;
    public int bloodLocalRotationYOffset;
    public Transform bloodPosition;
    public Transform bloodPrefab;
    public Transform bloodRotation;
    public int maxAmountBloodPrefabs = 20;

    public void Main()
    {
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bloodRotation.Rotate(0f, bloodLocalRotationYOffset, 0f);
            var transform = Instantiate(bloodPrefab, bloodPosition.position, bloodRotation.rotation) as Transform;
            bloodInstances = GameObject.FindGameObjectsWithTag("blood");
            if (bloodInstances.Length >= maxAmountBloodPrefabs)
            {
                Destroy(bloodInstances[0]);
            }
        }
    }
}

