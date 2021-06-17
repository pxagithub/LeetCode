using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace _65._有效数字
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s=new Solution();
            
            Console.WriteLine(s.IsNumber("."));
        }
    }
    public class Solution
    {
        public bool IsNumber(string s)
        {
            Dictionary<State, Dictionary<CharType, State>> transfer = new Dictionary<State, Dictionary<CharType, State>>();
            Dictionary<CharType, State> initialDictionary = new Dictionary<CharType, State>{
                {CharType.CharNumber,State.StateInteger},
                {CharType.CharPoint,State.StatePointWithoutInt},
                {CharType.CharSign,State.StateIntSign}
            };
            transfer.Add(State.StateInitial, initialDictionary);

            Dictionary<CharType, State> intSignDictionary = new Dictionary<CharType, State>
            {
                {CharType.CharNumber, State.StateInteger},
                {CharType.CharPoint, State.StatePointWithoutInt}
            };
            transfer.Add(State.StateIntSign, intSignDictionary);

            Dictionary<CharType, State> integerDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateInteger},
                {CharType.CharExp, State.StateExp},
                {CharType.CharPoint, State.StatePoint}
            };
            transfer.Add(State.StateInteger, integerDictionary);

            Dictionary<CharType, State> pointDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateFraction},
                {CharType.CharExp, State.StateExp}
            };
            transfer.Add(State.StatePoint, pointDictionary);

            Dictionary<CharType, State> pointWithoutIntDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateFraction}
            };
            transfer.Add(State.StatePointWithoutInt, pointWithoutIntDictionary);

            Dictionary<CharType, State> fractionDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateFraction},
                {CharType.CharExp, State.StateExp}
            };
            transfer.Add(State.StateFraction, fractionDictionary);

            Dictionary<CharType, State> expDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateExpNumber},
                {CharType.CharSign, State.StateExpSign}
            };
            transfer.Add(State.StateExp, expDictionary);

            Dictionary<CharType, State> expSignDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateExpSign}
            };
            transfer.Add(State.StateExpSign, expSignDictionary);

            Dictionary<CharType, State> expNumbDictionary = new Dictionary<CharType, State>()
            {
                {CharType.CharNumber, State.StateExpNumber}
            };
            transfer.Add(State.StateExpNumber, expNumbDictionary);

            int length = s.Length;
            State state = State.StateInitial;

            for (int i = 0; i < length; i++)
            {
                CharType type = ToCharType(s[i]);
                if (!transfer[state].ContainsKey(type))
                {
                    return false;
                }
                else
                {
                    state = transfer[state][type];
                }
            }

            return state == State.StateInteger || state == State.StatePoint || state == State.StateFraction ||
                   state == State.StateExpNumber || state == State.StateEnd;
        }
        CharType ToCharType(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return CharType.CharNumber;
            }
            else if (ch == 'e' || ch == 'E')
            {
                return CharType.CharExp;
            }
            else if (ch == '.')
            {
                return CharType.CharPoint;
            }
            else if (ch == '+' || ch == '-') return CharType.CharSign;
            else return CharType.CharIllegal;
        }
    }

    
    enum State
    {
        StateInitial,
        StateIntSign,
        StateInteger,
        StatePoint,
        StatePointWithoutInt,
        StateFraction,
        StateExp,
        StateExpSign,
        StateExpNumber,
        StateEnd
    }

    enum CharType
    {
        CharNumber,
        CharExp,
        CharPoint,
        CharSign,
        CharIllegal
    }
}
