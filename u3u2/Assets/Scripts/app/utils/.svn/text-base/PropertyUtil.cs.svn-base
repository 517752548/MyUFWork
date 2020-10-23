
using System.Collections.Generic;
using UnityEngine;

namespace app.utils
{
    public class PropertyUtil
    {
        public static bool IsLegalID(int id)
        {
            return id > 0;
        }

        public static bool IsLegalID(long id)
        {
            return id > 0;
        }

        public static bool IsLegalID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return id != "0";
            }
            return false;
        }

        public static Vector3 StringToVector3(string str)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            if (str != null && str != "" && str.Contains(","))
            {
                string[] arr = str.Split(new char[1] { ',' });
                if (arr != null && arr.Length >= 3)
                {
                    float.TryParse(arr[0], out x);
                    float.TryParse(arr[1], out y);
                    float.TryParse(arr[2], out z);
                }
            }

            return new Vector3(x, y, z);
        }

        public static List<int> StringToIntList(string str)
        {
            List<int> _res = null;

            if (str != null && str != "")
            {
                _res = new List<int>();
                if (str.Contains(","))
                {
                    string[] arr = str.Split(new char[1] { ',' });
                    if (arr != null)
                    {
                        int _len = arr.Length;
                        for (int _i = 0; _i < _len; _i++)
                        {
                            _res.Add(int.Parse(arr[_i]));
                        }
                    }
                }
                else
                {
                    _res.Add(int.Parse(str));
                }

            }

            return _res;
        }

        /**
         * 根据参数获得战斗唯一id
         * @param position
         * @param index
         * @param isAttacker
         * @return
         */
        public static string GenFighterId(PositionType position, int teamIndex, int index, bool isAttacker)
        {
            string id = (isAttacker ? "a" : "d") + ((int)position * 100 + teamIndex * 10 + index);
            return id;
        }
    }
}
