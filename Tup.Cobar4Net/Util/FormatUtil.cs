/*
* Copyright 1999-2012 Alibaba Group.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Text;

namespace Tup.Cobar4Net.Util
{
    /// <summary>��ʽ������</summary>
    /// <author>xianmao.hexm</author>
    /// <version>2008-11-24 ����12:58:17</version>
    public static class FormatUtil
    {
        public const int AlignRight = 0;

        public const int AlignLeft = 1;

        private const char defaultSplitChar = ' ';

        private static readonly string[] timeFormat = {"d ", "h ", "m ", "s ", "ms"};

        // �Ҷ����ʽ���ַ���
        // ������ʽ���ַ���
        /// <summary>��ʽ���󷵻ص��ַ���</summary>
        /// <param name="s">��Ҫ��ʽ����ԭʼ�ַ�����Ĭ�ϰ�����롣</param>
        /// <param name="fillLength">��䳤��</param>
        /// <returns>String</returns>
        public static string Format(string s, int fillLength)
        {
            return Format(s, fillLength, defaultSplitChar, AlignLeft);
        }

        /// <summary>��ʽ���󷵻ص��ַ���</summary>
        /// <param name="i">��Ҫ��ʽ�����������ͣ�Ĭ�ϰ��Ҷ��롣</param>
        /// <param name="fillLength">��䳤��</param>
        /// <returns>String</returns>
        public static string Format(int i, int fillLength)
        {
            return Format(i.ToString(), fillLength, defaultSplitChar, AlignRight);
        }

        /// <summary>��ʽ���󷵻ص��ַ���</summary>
        /// <param name="l">��Ҫ��ʽ�����������ͣ�Ĭ�ϰ��Ҷ��롣</param>
        /// <param name="fillLength">��䳤��</param>
        /// <returns>String</returns>
        public static string Format(long l, int fillLength)
        {
            return Format(l.ToString(), fillLength, defaultSplitChar, AlignRight);
        }

        /// <param name="s">��Ҫ��ʽ����ԭʼ�ַ���</param>
        /// <param name="fillLength">��䳤��</param>
        /// <param name="fillChar">�����ַ�</param>
        /// <param name="align">��䷽ʽ�������仹���ұ���䣩</param>
        /// <returns>String</returns>
        public static string Format(string s, int fillLength, char fillChar, int align)
        {
            if (s == null)
            {
                s = string.Empty;
            }
            else
            {
                s = s.Trim();
            }
            var charLen = fillLength - s.Length;
            if (charLen > 0)
            {
                var fills = new char[charLen];
                for (var i = 0; i < charLen; i++)
                {
                    fills[i] = fillChar;
                }
                var str = new StringBuilder(s);
                switch (align)
                {
                    case AlignRight:
                    {
                        str.Insert(0, fills);
                        break;
                    }

                    case AlignLeft:
                    {
                        str.Append(fills);
                        break;
                    }

                    default:
                    {
                        str.Append(fills);
                        break;
                    }
                }
                return str.ToString();
            }
            return s;
        }

        /// <summary>
        ///     ��ʽ��ʱ�����
        ///     <p>
        ///         1d 15h 4m 15s 987ms
        ///     </p>
        /// </summary>
        public static string FormatTime(long millis, int precision)
        {
            var la = new long[5];
            la[0] = millis/86400000;
            // days
            la[1] = millis/3600000%24;
            // hours
            la[2] = millis/60000%60;
            // minutes
            la[3] = millis/1000%60;
            // seconds
            la[4] = millis%1000;
            // ms
            var index = 0;
            for (var i = 0; i < la.Length; i++)
            {
                if (la[i] != 0)
                {
                    index = i;
                    break;
                }
            }
            var buf = new StringBuilder();
            var validLength = la.Length - index;
            for (var i_1 = 0; i_1 < validLength && i_1 < precision; i_1++)
            {
                buf.Append(la[index]).Append(timeFormat[index]);
                index++;
            }
            return buf.ToString();
        }
    }
}