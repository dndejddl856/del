using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    class Restaurant
    {
        public string contact { get; set; }//가게 전화번호 
        public string user_id { get; set; } // 유저 아이디 
        public string restaurant_name { get; set; } // 가게 이름
        public string rate { get; set; } // 평점 
        public string restaurant_address { get; set; } // 가게 주소
        public string food { get; set; } // 메뉴
        public int price { get; set; } // 가격

    }
}
