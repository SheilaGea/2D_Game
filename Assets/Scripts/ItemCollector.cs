using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    // Remove the private int apples = 0; as it's not needed here.
    [SerializeField] private TextMeshProUGUI applesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            // Update the GameData.apples directly.
            GameData.apples++;
            applesText.text = " Apples: " + GameData.apples;
        }
    }

    // Use the Start method to initialize the applesText.
    private void Start()
    {
        applesText.text = " Apples: " + GameData.apples;
    }
}

