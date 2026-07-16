using System;
using System.Collections.Generic;

namespace PlayerManager2
{
    public class CompareByName : IComparer<Player>
    {
        private readonly bool _ascending;
        public CompareByName (bool ascending)
        {
            _ascending = ascending;
        }
        public int Compare(Player x, Player y)
        {
            // Validações de segurança para nulos
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Se for ordem crescente (A-Z)
            if (_ascending)
                return x.Name.CompareTo(y.Name);
            // Se for ordem decrescente (Z-A)
            else
                return y.Name.CompareTo(x.Name);
        }    
    }
}