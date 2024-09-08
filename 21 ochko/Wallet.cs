using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_ochko
{
    public class Wallet
    {
        private int _playerMoney;

        public int PlayerMoney => _playerMoney;


        public Wallet(int playerMoney)
        {
            _playerMoney = playerMoney;
        }

        public bool TryTakeCashFromWallet(int RequiredMoney)
        {
            bool isEnough = _playerMoney >= RequiredMoney;

            if (isEnough)
                _playerMoney -= RequiredMoney;

            return isEnough;
        }

        public void AddCashToWallet(int cashToAdd)
        {
            _playerMoney += cashToAdd;
        }





    }
}
