using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Default
{
    internal sealed class PlayerData : MonoBehaviour
    {
        public static PlayerData CurrentData
        {
            get
            {
                if (_currData == null)
                {
                    Debug.LogError("Accesing empty save data.");
                    LoadData();
                }
                return _currData;
            }
        }

        static PlayerData _currData;
        private const string key = "playerdata";
        private static bool _canSave = true;

        //[Space]




        public static void LoadData()
        {
            //var str = PlayerPrefs.GetString(key);
            //if (str != null && str.Length > 0)
            //{
            //    var json = JsonConvert.DeserializeObject<PlayerData>(str);

            //    if (json == null)
            //    {

            //        _currData = new PlayerData();
            //        _currData.SaveData();
            //    }
            //    else
            //    {
            //        _currData = (json);
            //    }
            //}
            //else
            //{
                _currData = new PlayerData();
            //    _currData.SaveData();
            //}
            //PlayerData._canSave = true;
        }


        public void SaveData()
        {
            //if (!_canSave) return;

            //if (_currData != null)
            //{
            //    string json = JsonConvert.SerializeObject(_currData);
            //    PlayerPrefs.SetString(key, json);
            //    PlayerPrefs.Save();
            //}
        }


    }
}
