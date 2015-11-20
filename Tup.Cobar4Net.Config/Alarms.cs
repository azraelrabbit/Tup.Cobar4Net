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

namespace Tup.Cobar4Net.Config
{
    /// <summary>Cobar�����ؼ��ʶ���</summary>
    /// <author>xianmao.hexm 2012-4-19</author>
    public abstract class Alarms
    {
        /// <summary>Ĭ�ϱ����ؼ���</summary>
        public const string Default = "#!Cobar#";

        /// <summary>��Ⱥ����Ч�Ľڵ���ṩ����</summary>
        public const string ClusterEmpty = "#!CLUSTER_EMPTY#";

        /// <summary>���ݽڵ������Դ�����л�</summary>
        public const string DatanodeSwitch = "#!DN_SWITCH#";

        /// <summary>�������Ƿ��û�����</summary>
        public const string QuarantineAttack = "#!QT_ATTACK#";
    }

    public static class AlarmsConstants
    {
    }
}