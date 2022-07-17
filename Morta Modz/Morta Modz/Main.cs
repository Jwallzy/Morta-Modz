using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Morta_Modz
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class Main : BaseUnityPlugin
    {
        #region[Declarations]

        public const string
            MODNAME = "Morta_Modz",
            AUTHOR = "",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = "1.0.0.0";

        internal readonly ManualLogSource log;
        internal readonly Harmony harmony;
        internal readonly Assembly assembly;
        public readonly string modFolder;

        #endregion
        #region[Player]

        #endregion

        private static CheatMenu _cheatMenu;
        private static GameObject _cheat;

        public Main()
        {
            log = Logger;
            harmony = new Harmony(GUID);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);

        }
        public void Start()
        {
            harmony.PatchAll(assembly);
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Keypad0))
            {
                _cheatMenu = FindObjectOfType<CheatMenu>();
                _cheat = _cheatMenu.gameObject;
                _cheat.SetActive(true);
                Debug.LogWarning("Enabled CheatMenu GameObject!");
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                _cheat.GetComponent<CheatMenu>().Show();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                _cheat.GetComponent <CheatMenu>().Hide();
            }
        }
    }
}
