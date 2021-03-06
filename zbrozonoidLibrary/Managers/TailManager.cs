﻿/*
Copyright(C) 2018 Tomasz Zbrożek

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see<https://www.gnu.org/licenses/>.
*/
namespace zbrozonoidLibrary.Managers
{
    using System.Collections;
    using System.Collections.Generic;

    using zbrozonoidLibrary.Interfaces;

    public class TailManager : ITailManager
    {
        private readonly Dictionary<IBall, ITail> tails = new Dictionary<IBall, ITail>();

        public void Add(IBall ball)
        {
            ITail tail = new Tail();
            tails.Add(ball, tail);
        }

        public void Remove(IBall ball)
        {
            tails.Remove(ball);
        }
        
        public ITail Find(IBall ball)
        {
            if (tails.ContainsKey(ball))
            {
                return tails[ball];
            }

            return null;
        }
        
        public void Clear()
        {
            tails.Clear();
        }

        public IEnumerator<ITail> GetEnumerator()
        {
            return tails.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //forces use of the non-generic implementation on the Values collection
            return ((IEnumerable)tails.Values).GetEnumerator();
        }
    }
}
