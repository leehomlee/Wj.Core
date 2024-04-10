using System;
using System.Collections.Generic;
using System.Linq;

namespace Wj.Bizlogic.Core
{
    public static class SeqGuid
    {
        public static string NewGuid()
        {
            // 获取唯一GUID的字节数组
            var guid = Guid.NewGuid().ToByteArray();
            // 获取当前时间的ticks数，万分之一毫秒
            var dtValue = DateTime.Now.Ticks;
            // 将时间转换成字节数组
            var dtBytes = BitConverter.GetBytes(dtValue);

            var bytes = new byte[guid.Length + dtBytes.Length];

            for (long i = 0; i < dtBytes.Length; i++)
            {
                var cvalue = dtBytes[dtBytes.Length - i - 1];
                bytes[i] = cvalue;
            }

            guid.CopyTo(bytes, dtBytes.Length);

            var b64 = Convert.ToBase64String(bytes);
            //将无序的base64转换为有序的伪base64格式
            var ss = b64.ToArray();
            for (var i = 0; i < ss.Length; i++)
            {
                ss[i] = BaseSortValueDic[ss[i]];
            }

            return new string(ss);
        }
        /// <summary>
        /// 仿base64的有序字典，其与base64相似，使用有限的字符，表示6bit的二进制，不足的地方补=。
        /// 但是，与base64的区别是，字符串是按从小到大的次序表示000000到111111的数值的.
        /// </summary>
        public static readonly Dictionary<char, char> BaseSortValueDic = new Dictionary<char, char>()
        {
            {'A','$'},{'B','-'},{'C','0'},{'D','1'},{'E','2'},{'F','3'},{'G','4'},{'H','5'},{'I','6'},{'J','7'},{'K','8'},
            {'L','9'},{'M','A'},{'N','B'},{'O','C'},{'P','D'},{'Q','E'},{'R','F'},{'S','G'},{'T','H'},{'U','I'},{'V','J'},
            {'W','K'},{'X','L'},{'Y','M'},{'Z','N'},{'a','O'},{'b','P'},{'c','Q'},{'d','R'},{'e','S'},{'f','T'},{'g','U'},
            {'h','V'},{'i','W'},{'j','X'},{'k','Y'},{'l','Z'},{'m','a'},{'n','b'},{'o','c'},{'p','d'},{'q','e'},{'r','f'},
            {'s','g'},{'t','h'},{'u','i'},{'v','j'},{'w','k'},{'x','l'},{'y','m'},{'z','n'},{'0','o'},{'1','p'},{'2','q'},
            {'3','r'},{'4','s'},{'5','t'},{'6','u'},{'7','v'},{'8','w'},{'9','x'},{'+','y'},{'/','z'},{'=','!'}
        };
    }
}
