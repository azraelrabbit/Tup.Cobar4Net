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

namespace Tup.Cobar4Net.Config.Model
{
    /// <summary>��������һ�����ݽڵ������</summary>
    /// <author>xianmao.hexm</author>
    public sealed class DataNodeConfig
    {
        private const int DefaultPoolSize = 128;

        private const long DefaultWaitTimeout = 10*1000L;

        private const long DefaultIdleTimeout = 10*60*1000L;

        private const long DefaultHeartbeatTimeout = 30*1000L;

        private const int DefaultHeartbeatRetry = 10;

        /// <summary>
        /// </summary>
        /// <remarks>
        ///     ���ֺ������ͨ����Ĭ�����ֵ
        ///     ȡ�������ӵĵȴ���ʱʱ��
        ///     ���ӳ������ӿ��г�ʱʱ��
        ///     heartbeat config
        ///     ������ʱʱ��
        ///     ������ӷ����쳣���л������Դ���
        ///     ��̬�������
        /// </remarks>
        public string HeartbeatSql { get; set; }

        public string Name { get; set; }

        public string DataSource { get; set; }

        public int PoolSize { get; set; } = DefaultPoolSize;

        public long WaitTimeout { get; set; } = DefaultWaitTimeout;

        public long IdleTimeout { get; set; } = DefaultIdleTimeout;

        public long HeartbeatTimeout { get; set; } = DefaultHeartbeatTimeout;

        public int HeartbeatRetry { get; set; } = DefaultHeartbeatRetry;

        public bool IsNeedHeartbeat
        {
            get { return HeartbeatSql != null; }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "[DataNodeConfig Name={0}, DataSource={1}, PoolSize={2}, WaitTimeout={3}, IdleTimeout={4}, HeartbeatTimeout={5}, HeartbeatRetry={6}, HeartbeatSQL={7}]",
                    Name, DataSource, PoolSize,
                    WaitTimeout, IdleTimeout,
                    HeartbeatTimeout,
                    HeartbeatRetry,
                    HeartbeatSql);
        }
    }
}