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

using System.Collections.Generic;
using Tup.Cobar4Net.Parser.Ast.Expression;
using Tup.Cobar4Net.Parser.Visitor;

namespace Tup.Cobar4Net.Parser.Ast.Fragment.Tableref
{
    /// <author>
    ///     <a href="mailto:shuo.qius@alibaba-inc.com">QIU Shuo</a>
    /// </author>
    public class InnerJoin : TableReference
    {
        private IExpression onCond;

        private IList<string> @using;

        private InnerJoin(TableReference leftTableRef,
                          TableReference rightTableRef,
                          IExpression onCond,
                          IList<string> @using)
        {
            LeftTableRef = leftTableRef;
            RightTableRef = rightTableRef;
            this.onCond = onCond;
            this.@using = EnsureListType(@using);
        }

        public InnerJoin(TableReference leftTableRef, TableReference rightTableRef)
            : this(leftTableRef, rightTableRef, null, null)
        {
        }

        public InnerJoin(TableReference leftTableRef,
                         TableReference rightTableRef,
                         IExpression onCond)
            : this(leftTableRef, rightTableRef, onCond, null)
        {
        }

        public InnerJoin(TableReference leftTableRef,
                         TableReference rightTableRef,
                         IList<string> @using)
            : this(leftTableRef, rightTableRef, null, @using)
        {
        }

        public virtual TableReference LeftTableRef { get; }

        public virtual TableReference RightTableRef { get; }

        public virtual IExpression OnCond
        {
            get { return onCond; }
        }

        public virtual IList<string> Using
        {
            get { return @using; }
        }

        public override bool IsSingleTable
        {
            get { return false; }
        }

        public override int Precedence
        {
            get { return PrecedenceJoin; }
        }

        private static IList<string> EnsureListType(IList<string> list)
        {
            if (list == null)
            {
                return null;
            }
            if (list.IsEmpty())
            {
                return new List<string>(0);
            }
            if (list is List<string>)
            {
                return list;
            }
            return new List<string>(list);
        }

        public override object RemoveLastConditionElement()
        {
            object obj;
            if (onCond != null)
            {
                obj = onCond;
                onCond = null;
            }
            else if (@using != null)
            {
                obj = @using;
                @using = null;
            }
            else
            {
                return null;
            }

            return obj;
        }

        public override void Accept(ISqlAstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}