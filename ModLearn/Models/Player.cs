using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModLearn.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }


        public int? TeamId { get; set; }
        // навигационное свойство, для вытягивания команды из запроса
        public Team Team { get; set; }
    }
}