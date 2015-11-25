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
using NUnit.Framework;
using Sharpen;

namespace Tup.Cobar4Net.Route.Util
{
    /// <author>xianmao.hexm from PartitionUtil.main()</author>
    [NUnit.Framework.TestFixture(Category = "PartitionUtilTest")]
    public class PartitionUtilTest
    {
        [NUnit.Framework.Test]
        public virtual void TestPartition()
        {
            // �����ķ������ԣ�ϣ��������ˮƽ�ֳ�3�ݣ�ǰ���ݸ�ռ25%��������ռ50%�����ʱ����Ǿ��ȷ�����
            // |<---------------------1024------------------------>|
            // |<----256--->|<----256--->|<----------512---------->|
            // | partition0 | partition1 | partition2 |
            // | ��2��,��count[0]=2 | ��1�ݣ���count[1]=1 |
            int[] count = new int[] { 2, 1 };
            int[] length = new int[] { 256, 512 };
            PartitionUtil pu = new PartitionUtil(count, length);
            // ���������ʾ�ֱ���offerId�ֶλ�memberId�ֶθ��������������Բ�ֵķ�����
            int DefaultStrHeadLen = 8;
            // cobarĬ�ϻ�����Ϊ��ֵ
            long offerId = 12345;
            string memberId = "qiushuo";
            // ������offerId���䣬partNo1������0�������������������ԣ�offerIdΪ12345ʱ���ᱻ���䵽partition0��
            int partNo1 = pu.Partition(offerId);
            // ������memberId���䣬partNo2������2�������������������ԣ�memberIdΪqiushuoʱ���ᱻ�ֵ�partition2��
            int partNo2 = pu.Partition(memberId, 0, DefaultStrHeadLen);
            NUnit.Framework.Assert.AreEqual(0, partNo1);
            NUnit.Framework.Assert.AreEqual(2, partNo2);
        }
        [NUnit.Framework.Test]
        public virtual void TestPartitionForSingle()
        {
            PartitionForSingle.Main(null);
            NUnit.Framework.Assert.IsTrue(true);
        }
    }
}
