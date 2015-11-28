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

using System;
using Tup.Cobar4Net.Util;

namespace Tup.Cobar4Net.Route.Util
{
    /// <summary>���ݷ�������</summary>
    /// <author>xianmao.hexm 2009-3-16 ����11:56:45</author>
    public sealed class PartitionUtil
    {
        private const int PartitionLength = 1024;

        private const long AndValue = PartitionLength - 1;

        private readonly int[] segment = new int[PartitionLength];

        /// <summary><pre></summary>
        /// <param name="count">��ʾ����ķ�����</param>
        /// <param name="length">
        /// ��ʾ��Ӧÿ��������ȡֵ����
        /// ע�⣺����count,length��������ĳ��ȱ�����һ�µġ�
        /// Լ����1024 = sum((count[i]*length[i])). count��length���������ĵ�������1024
        /// </pre>
        /// </param>
        public PartitionUtil(int[] count, int[] length)
        {
            // ��������:���ݶηֲ����壬����ȡģ����һ��Ҫ��2^n�� ��Ϊ����ʹ��x % 2^n == x & (2^n - 1)��ʽ�����Ż����ܡ�
            // %ת��Ϊ&�����Ļ�����ֵ
            // �����߶�
            if (count == null || length == null || (count.Length != length.Length))
            {
                throw new ArgumentException("error,check your scope & scopeLength definition.");
            }
            int segmentLength = 0;
            for (int i = 0; i < count.Length; i++)
            {
                segmentLength += count[i];
            }
            int[] ai = new int[segmentLength + 1];
            int index = 0;
            for (int i_1 = 0; i_1 < count.Length; i_1++)
            {
                for (int j = 0; j < count[i_1]; j++)
                {
                    ai[++index] = ai[index - 1] + length[i_1];
                }
            }
            if (ai[ai.Length - 1] != PartitionLength)
            {
                throw new ArgumentException("error,check your partitionScope definition.");
            }
            // ����ӳ�����
            for (int i_2 = 1; i_2 < ai.Length; i_2++)
            {
                for (int j = ai[i_2 - 1]; j < ai[i_2]; j++)
                {
                    segment[j] = (i_2 - 1);
                }
            }
        }

        public int Partition(long hash)
        {
            return segment[(int)(hash & AndValue)];
        }

        public int Partition(string key, int start, int end)
        {
            return Partition(StringUtil.Hash(key, start, end));
        }
    }
}