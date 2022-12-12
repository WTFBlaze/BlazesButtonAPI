using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using static VRC.UI.Elements.UIPage;

namespace ApolloCore.API.QM
{
    public class QMNestedButton : QMMenuBase
    {
        protected bool IsMenuRoot;
        protected GameObject BackButton;
        protected QMSingleButton MainButton;

        public QMNestedButton(QMTabMenu location, float posX, float posY, string btnText, string toolTipText, string menuTitle, bool halfButton = false)
        {
            btnQMLoc = location.GetMenuName();
            Initialize(false, btnText, posX, posY, toolTipText, menuTitle, halfButton);
        }

        private void Initialize(bool isRoot, string btnText, float btnPosX, float btnPosY, string btnToolTipText, string menuTitle, bool halfButton)
        {
            MenuName = $"{APIUtils.Identifier}-Menu-{APIUtils.RandomNumbers()}";
            MenuObject = Object.Instantiate(APIUtils.GetQMMenuTemplate(), APIUtils.GetQMMenuTemplate().transform.parent);
            MenuObject.name = MenuName;
            MenuObject.SetActive(false);
            Object.DestroyImmediate(MenuObject.GetComponent<LaunchPadMenuQM>());
            MenuPage = MenuObject.AddComponent<UIPage>();
            MenuPage.field_Public_String_0 = MenuName;
            MenuPage.field_Protected_MenuStateController_0 = APIUtils.MenuStateControllerInstance;
            MenuPage.field_Private_List_1_UIPage_0 = new();
            MenuPage.field_Private_List_1_UIPage_0.Add(MenuPage);
            APIUtils.MenuStateControllerInstance.field_Private_Dictionary_2_String_UIPage_0.Add(MenuName, MenuPage);

            IsMenuRoot = isRoot;

            if (IsMenuRoot)
            {
                var list = APIUtils.MenuStateControllerInstance.field_Public_ArrayOf_UIPage_0.ToList();
                list.Add(MenuPage);
                APIUtils.MenuStateControllerInstance.field_Public_ArrayOf_UIPage_0 = list.ToArray();
            }

            MenuObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup").DestroyChildren();
            MenuTitleText = MenuObject.GetComponentInChildren<TextMeshProUGUI>(true);
            SetMenuTitle(menuTitle);
            BackButton = MenuObject.transform.GetChild(0).Find("LeftItemContainer/Button_Back").gameObject;
            BackButton.SetActive(true);
            BackButton.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            BackButton.GetComponentInChildren<Button>().onClick.AddListener(new System.Action(() =>
            {
                if (isRoot)
                {
                    if (btnQMLoc.StartsWith("Menu_"))
                    {
                        APIUtils.MenuStateControllerInstance.Method_Public_Void_String_Boolean_Boolean_0("QuickMenu" + btnQMLoc.Remove(0, 5));
                        return;
                    }
                    APIUtils.MenuStateControllerInstance.Method_Public_Void_String_Boolean_Boolean_0(btnQMLoc);
                    return;
                }
                MenuPage.Method_Protected_Virtual_New_Void_0();
            }));
            MenuObject.transform.GetChild(0).Find("RightItemContainer/Button_QM_Expand").gameObject.SetActive(false);
            MainButton = new QMSingleButton(btnQMLoc, btnPosX, btnPosY, btnText, OpenMe, btnToolTipText, halfButton);

            ClearChildren();
            MenuObject.transform.Find("ScrollRect").GetComponent<ScrollRect>().enabled = false;
        }

        public void OpenMe()
        {
            MenuObject.SetActive(true);
            APIUtils.MenuStateControllerInstance.Method_Public_Void_String_UIContext_Boolean_EnumNPublicSealedvaNoLeRiBoIn6vUnique_0(MenuPage.field_Public_String_0, null, false, EnumNPublicSealedvaNoLeRiBoIn6vUnique.Left);
        }

        public void CloseMe()
        {
            MenuPage.Method_Public_Virtual_New_Void_0();
        }

        public QMSingleButton GetMainButton() => MainButton;

        public GameObject GetBackButton() => BackButton;
    }
}
