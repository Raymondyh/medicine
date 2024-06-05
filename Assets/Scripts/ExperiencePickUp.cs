using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickUp : MonoBehaviour
{
    [SerializeField] int experience_reward = 400;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();

        if (c != null)
        {
            c.AddExperience(experience_reward);
            Destroy(gameObject);
        }
    }
}
