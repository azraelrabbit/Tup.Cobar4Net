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
    /// <summary>����������ʶ����</summary>
    /// <author>xianmao.hexm</author>
    public abstract class Capabilities
    {
        /// <summary>
        ///     server capabilities
        ///     <pre>
        ///         server:        11110111 11111111
        ///         client_cmd: 11 10100110 10000101
        ///         client_jdbc:10 10100010 10001111
        /// </summary>
        /// <seealso>
        ///     http://dev.mysql.com/doc/refman/5.1/en/mysql-real-connect.html
        ///     </pre>
        /// </seealso>
        public const int ClientLongPassword = 1;

        public const int ClientFoundRows = 2;

        public const int ClientLongFlag = 4;

        public const int ClientConnectWithDb = 8;

        public const int ClientNoSchema = 16;

        public const int ClientCompress = 32;

        public const int ClientOdbc = 64;

        public const int ClientLocalFiles = 128;

        public const int ClientIgnoreSpace = 256;

        public const int ClientProtocol41 = 512;

        public const int ClientInteractive = 1024;

        public const int ClientSsl = 2048;

        public const int ClientIgnoreSigpipe = 4096;

        public const int ClientTransactions = 8192;

        public const int ClientReserved = 16384;

        public const int ClientSecureConnection = 32768;

        public const int ClientMultiStatements = 65536;

        public const int ClientMultiResults = 131072;
        // new more secure passwords
        // Found instead of affected rows
        // �����ҵ���ƥ�䣩�������������Ǹı��˵�������
        // Get all column flags
        // One can specify db on connect
        // Don't allow database.table.column
        // ���������ݿ���.����.�������������﷨�����Ƕ���ODBC�����á�
        // ��ʹ���������﷨ʱ�����������һ�����������һЩODBC�ĳ�������bug��˵�����õġ�
        // Can use compression protocol
        // ʹ��ѹ��Э��
        // Odbc client
        // Can use LOAD DATA LOCAL
        // Ignore spaces before '('
        // �����ں�������ʹ�ÿո����к���������Ԥ���֡�
        // New 4.1 protocol This is an interactive client
        // This is an interactive client
        // ����ʹ�ùر�����֮ǰ�Ĳ��������ʱ�������������ǵȴ���ʱ������
        // �ͻ��˵ĻỰ�ȴ���ʱ������Ϊ������ʱ������
        // Switch to SSL after handshake
        // ʹ��SSL��������ò�Ӧ�ñ�Ӧ�ó������ã���Ӧ�����ڿͻ��˿��ڲ������õġ�
        // �����ڵ���mysql_real_connect()֮ǰ����mysql_ssl_set()���������á�
        // IGNORE sigpipes
        // ��ֹ�ͻ��˿ⰲװһ��SIGPIPE�źŴ�������
        // ����������ڵ�Ӧ�ó����Ѿ���װ�ô�������ʱ��������䷢����ͻ��
        // Client knows about transactions
        // Old flag for 4.1 protocol
        // New 4.1 authentication
        // Enable/disable multi-stmt support
        // ֪ͨ�������ͻ��˿��Է��Ͷ�����䣨�ɷֺŷָ���������ñ�־Ϊû�б����ã��������ִ�С�
        // Enable/disable multi-results
        // ֪ͨ�������ͻ��˿��Դ����ɶ������ߴ洢����ִ�����ɵĶ�������
        // ����CLIENT_MULTI_STATEMENTSʱ�������־�Զ��ı��򿪡�
    }

    public static class CapabilitiesConstants
    {
    }
}