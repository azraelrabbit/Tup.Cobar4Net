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
using Sharpen;
using System;

namespace Tup.Cobar4Net.Route.Util
{
	/// <summary>���ݷ������ߵ����汾����ʹ��singleton��ģʽ���á�</summary>
	/// <author>xianmao.hexm 2009-3-16 ����11:56:45</author>
	public sealed class PartitionForSingle
	{
		private const int PartitionLength = 1024;

		private const int DefaultHashLength = 8;

		private const long AndValue = PartitionLength - 1;

		private readonly int[] segment = new int[PartitionLength];

		/// <param name="count">��ʾ����ķ�����</param>
		/// <param name="length">
		/// ��ʾ��Ӧÿ��������ȡֵ����
		/// <p>
		/// ע�⣺����count,length��������ĳ��ȱ�����һ�µġ�
		/// </p>
		/// </param>
		public PartitionForSingle(int[] count, int[] length)
		{
			// ��������:���ݶηֲ����壬����ȡģ����һ��Ҫ��2^n�� ��Ϊ����ʹ��x % 2^n == x & (2^n - 1)��ʽ�����Ż����ܡ�
			// %ת��Ϊ&�����Ļ�����ֵ
			// �����߶�
			if (count == null || length == null || (count.Length != length.Length))
			{
				throw new Exception("error,check your scope & scopeLength definition.");
			}
			int segmentLength = 0;
			for (int i = 0; i < count.Length; i++)
			{
				segmentLength += count[i];
			}
			int[] scopeSegment = new int[segmentLength + 1];
			int index = 0;
			for (int i_1 = 0; i_1 < count.Length; i_1++)
			{
				for (int j = 0; j < count[i_1]; j++)
				{
					scopeSegment[++index] = scopeSegment[index - 1] + length[i_1];
				}
			}
			if (scopeSegment[scopeSegment.Length - 1] != PartitionLength)
			{
				throw new Exception("error,check your partitionScope definition.");
			}
			// ����ӳ�����
			for (int i_2 = 1; i_2 < scopeSegment.Length; i_2++)
			{
				for (int j = scopeSegment[i_2 - 1]; j < scopeSegment[i_2]; j++)
				{
					segment[j] = (i_2 - 1);
				}
			}
		}

		public int Partition(long h)
		{
			return segment[(int)(h & AndValue)];
		}

		public int Partition(string key)
		{
			return segment[(int)(Hash(key) & AndValue)];
		}

		private static long Hash(string s)
		{
			long h = 0;
			int len = s.Length;
			for (int i = 0; (i < DefaultHashLength && i < len); i++)
			{
				h = (h << 5) - h + s[i];
			}
			return h;
		}

		// for test
		public static void Main(string[] args)
		{
            //TODO PartitionForSingle Main
            // ���Ϊ16�ݣ�ÿ�ݳ��Ⱦ�Ϊ��64��
            // Scope scope = new Scope(new int[] { 16 }, new int[] { 64 });
            // // ���Ϊ23�ݣ�ǰ8�ݳ���Ϊ��8����15�ݳ���Ϊ��64��
            // Scope scope = new Scope(new int[] { 8, 15 }, new int[] { 8, 64 });
            // // ���Ϊ128�ݣ�ÿ�ݳ��Ⱦ�Ϊ��8��
            // Scope scope = new Scope(new int[] { 128 }, new int[] { 8 });
            Tup.Cobar4Net.Route.Util.PartitionForSingle p = new Tup.Cobar4Net.Route.Util.PartitionForSingle
				(new int[] { 8, 15 }, new int[] { 8, 64 });
			string memberId = "xianmao.hexm";
			int value = 0;
			long st = Runtime.CurrentTimeMillis();
			for (int i = 0; i < 10000000; i++)
			{
				value = p.Partition(memberId);
			}
			long et = Runtime.CurrentTimeMillis();
			System.Console.Out.WriteLine("value:" + value + ",take time:" + (et - st) + " ms."
				);
		}
	}
}
