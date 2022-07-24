using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// fivem imports
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;


namespace zServer
{
    internal class characterDress : BaseScript
    {
        DataBase database_conection = new DataBase();

        public characterDress() { 
            EventHandlers["get_nose"] += new Action<int, string>(get_nose);
            EventHandlers["update_nose"] += new Action<string, int, int, int, int, int, int>(update_nose);
            
        }


        private void update_nose(string username,
            int nose_width,
            int nose_peak,
            int nose_length,
            int nose_bone,
            int nose_tip,
            int nose_bone_twist
            )
        {
            Dictionary<int, string[]> id = database_conection.directQuery(
              $"SELECT id FROM users WHERE username = '{username}';");

            string query = $"UPDATE `character` " +
                $" SET nose_width = {nose_width}," +
                $" nose_peak = {nose_peak}," +
                $" nose_length = {nose_length}," +
                $" nose_bone = {nose_bone}," +
                $" nose_tip = {nose_tip}," +
                $" nose_bone_twist = {nose_bone_twist}" +
                $" WHERE user = {id[0][0]}";

            database_conection.insert(query);
        }

        private void get_nose(int ped, string username)
        {

            Dictionary<int, string[]> id = database_conection.directQuery(
              $"SELECT id FROM users WHERE username = '{username}';");

            Dictionary<int, string[]> data = database_conection.directQuery(
               $"SELECT nose_width," +
               $" nose_peak," +
               $" nose_length," +
               $" nose_bone," +
               $" nose_tip," +
               $" nose_bone_twist  FROM `character` WHERE user = '{id[0][0]}';");


            int nose_width_int = Int32.Parse(data[0][0].ToString());
            float nose_width_f = (float)nose_width_int / 100;

            int nose_peak_int = Int32.Parse(data[0][1].ToString());
            float nose_peak_f = (float)nose_peak_int / 100;

            int nose_length_int = Int32.Parse(data[0][2].ToString());
            float nose_length_f = (float)nose_length_int / 100;

            int nose_bone_int = Int32.Parse(data[0][3].ToString());
            float nose_bone_f = (float)nose_bone_int / 100;

            int nose_tip_int = Int32.Parse(data[0][4].ToString());
            float nose_tip_f = (float)nose_tip_int / 100;

            int nose_bone_twist_int = Int32.Parse(data[0][4].ToString());
            float nose_bone_twist_f = (float)nose_bone_twist_int / 100;

            SetPedFaceFeature(ped, 0, nose_width_f);
            SetPedFaceFeature(ped, 1, nose_peak_f);
            SetPedFaceFeature(ped, 2, nose_length_f);
            SetPedFaceFeature(ped, 3, nose_length_f);
            SetPedFaceFeature(ped, 4, nose_bone_f);
            SetPedFaceFeature(ped, 5, nose_bone_twist_f);


        }
    }
}
