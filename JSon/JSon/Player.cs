﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSon
{

    public class RootObject
    {
        public Player[] Player { get; set; }
    }

    public class Player
    {    
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "ponts_per_game")]
        public string PointPerGame { get; set; }

        [JsonProperty(PropertyName = "second_name")]
        public string SecondName { get; set; }

        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }
       
    }

}
