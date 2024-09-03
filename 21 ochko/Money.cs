using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_ochko
{
    public class Money
    {
        private float _playerMoney;

        public float PlayerMoney
        {
            get { return _playerMoney; }
            set { _playerMoney = value; }
        }


        public void GetCashFromWallet()
        {
            
        }

        public void AddCashToWallet()
        {

        }
        //Сделать валидацию суммы

        public bool isValid(float money)
        {
            return true;
        }




    }
}
