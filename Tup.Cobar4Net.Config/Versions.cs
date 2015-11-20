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

namespace Tup.Cobar4Net.Config
{
	/// <author>xianmao.hexm</author>
	public abstract class Versions
	{
		/// <summary>Э��汾</summary>
		public const byte ProtocolVersion = 10;

		/// <summary>�������汾</summary>
		public const byte[] ServerVersion = Sharpen.Runtime.GetBytesForString("5.1.48-cobar-1.2.7"
			);
	}

	public static class VersionsConstants
	{
	}
}
