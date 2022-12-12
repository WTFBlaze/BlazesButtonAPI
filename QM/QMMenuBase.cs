using TMPro;
using UnityEngine;
using VRC.UI.Elements;

namespace ApolloCore.API.QM
{
    public class QMMenuBase
    {
        protected string btnQMLoc;
        protected GameObject MenuObject;
        protected TextMeshProUGUI MenuTitleText;
        protected UIPage MenuPage;
        protected string MenuName;

        public string GetMenuName() => MenuName;

        public UIPage GetMenuPage() => MenuPage;

        public GameObject GetMenuObject() => MenuObject;

        public void SetMenuTitle(string newTitle) => MenuObject.GetComponentInChildren<TextMeshProUGUI>(true).text = newTitle;

        public void ClearChildren()
        {
            for (int i = 0; i < MenuObject.transform.childCount; i++)
            {
                if (MenuObject.transform.GetChild(i).name != "Header_H1" && MenuObject.transform.GetChild(i).name != "ScrollRect")
                {
                    Object.Destroy(MenuObject.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
