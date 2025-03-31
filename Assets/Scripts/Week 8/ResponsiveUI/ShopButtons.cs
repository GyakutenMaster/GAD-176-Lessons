using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SAE.GAD176.Tutorials.ResponsiveUI
{
    public class ShopButtons : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public Transform shopParent;

        public List<Button> allButtonsSpawned = new List<Button>();
        public List<Weapon> allItems = new List<Weapon>();
        public int playerWallet = 100;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                Weapon currentWeapon = allItems[i];
                GameObject clone = Instantiate(buttonPrefab, shopParent);
                Button currentButton = clone.GetComponent<Button>();

                //if (clone.GetComponent<Button>())
                //{
                //    allButtonsSpawned.Add(clone.GetComponent<Button>());
                //}

                if (currentButton != null)
                {
                    allButtonsSpawned.Add(currentButton);
                    currentButton.transform.name = allItems[i].weaponName + " button";
                    currentButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy " + allItems[i].weaponName;
                    currentButton.onClick.RemoveAllListeners(); // just removing all functions
                    currentButton.onClick.AddListener( ()=> { currentWeapon.Buy(ref playerWallet);  });
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
