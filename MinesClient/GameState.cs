using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MinesClient
{
    public class GameState
    {
        public int[,] btn_prop = new int[41, 41];
        public int[,] saved_btn_prop = new int[41, 41];
        public int xh, yw;
        public bool isMap;
        public int pl_num, mine;
        public bool isRightClick;


        public GameState(int p, int[,] btnprop, int[,] savedbtnprop, bool is_map, int txh, 
            int tyw, bool isRClick, int m)
        {
            pl_num = p;
            btn_prop = btnprop;
            saved_btn_prop = savedbtnprop;
            isMap = is_map;
            xh = txh;
            yw = tyw;
            isRightClick = isRClick;
            mine = m;
        }
        public GameState()
        {

        }
        public bool isaMap()
        {
            return isMap;
        }

        public bool isaRightClick()
        {
            return isRightClick;
        }

        public static string ObjectToString(GameState obj)
        {
            string output = JsonConvert.SerializeObject(obj);
            return output;
        }

        public static GameState StringToObject(string output)
        {
            GameState deserializedProduct = JsonConvert.DeserializeObject<GameState>(output);
            return deserializedProduct;
        }
    }
}
