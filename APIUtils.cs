using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace ApolloCore.API
{
    public static class APIUtils
    {
        internal const string Identifier = "BlazeVR";
        private static readonly System.Random rnd = new();
        private static QuickMenu _quickMenu;
        private static MenuStateController _menuStateController;
        private static Sprite _onSprite;
        private static Sprite _offSprite;
        private static GameObject _userInterface;
        private static GameObject _qmButtonTemplate;
        private static GameObject _qmMenuTemplate;
        private static GameObject _qmTabTemplate;

        internal static QuickMenu QuickMenuInstance
        {
            get
            {
                if (_quickMenu == null)
                    _quickMenu = Resources.FindObjectsOfTypeAll<QuickMenu>()[0];
                return _quickMenu;
            }
        }

        internal static MenuStateController MenuStateControllerInstance
        {
            get
            {
                if (_menuStateController == null)
                    _menuStateController = QuickMenuInstance.GetComponent<MenuStateController>();
                return _menuStateController;
            }
        }

        public static GameObject GetUserInterface()
        {
            if (_userInterface == null)
                _userInterface = QuickMenuInstance.transform.parent.gameObject;
            return _userInterface;
        }

        internal static GameObject GetQMButtonTemplate()
        {
            if (_qmButtonTemplate == null)
                _qmButtonTemplate = QuickMenuInstance.transform.Find("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Worlds").gameObject;
            return _qmButtonTemplate;
        }

        internal static GameObject GetQMMenuTemplate()
        {
            if (_qmMenuTemplate == null)
                _qmMenuTemplate = QuickMenuInstance.transform.Find("CanvasGroup/Container/Window/QMParent/Menu_Dashboard").gameObject;
            return _qmMenuTemplate;
        }

        internal static GameObject GetQMTabButtonTemplate()
        {
            if (_qmTabTemplate == null)
                _qmTabTemplate = QuickMenuInstance.transform.Find("CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").gameObject;
            return _qmTabTemplate;
        }

        internal static Sprite OnIconSprite()
        {
            if (_onSprite == null)
                _onSprite = QuickMenuInstance.transform.Find("CanvasGroup/Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").GetComponent<Image>().sprite;
            return _onSprite;
        }

        internal static Sprite OffIconSprite()
        {
            if (_offSprite == null)
                _offSprite = QuickMenuInstance.transform.Find("CanvasGroup/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo/Icon_Off").GetComponent<Image>().sprite;
            return _offSprite;
        }

        public static int RandomNumbers()
        {
            return rnd.Next(100000, 999999);
        }

        public static void DestroyChildren(this Transform transform)
        {
            transform.DestroyChildren(null);
        }

        public static void DestroyChildren(this Transform transform, Func<Transform, bool> exclude)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                if (exclude == null || exclude(transform.GetChild(i)))
                {
                    UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
