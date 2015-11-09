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
using Tup.Cobar.Parser.Util;
using Tup.Cobar.Parser.Visitor;
using Expr = Tup.Cobar.Parser.Ast.Expression.Expression;

namespace Tup.Cobar.Parser.Ast.Fragment
{
    /// <author><a href="mailto:shuo.qius@alibaba-inc.com">QIU Shuo</a></author>
    public class GroupBy : ASTNode
    {
        /// <summary>
        /// might be
        /// <see cref="System.Collections.ArrayList{E}"/>
        ///
        /// </summary>
        private readonly IList<Pair<Expr, SortOrder
            >> orderByList;

        private bool withRollup = false;

        public virtual bool IsWithRollup()
        {
            return withRollup;
        }

        /// <returns>never null</returns>
        public virtual IList<Pair<Expr, SortOrder>>
             GetOrderByList()
        {
            return orderByList;
        }

        /// <summary>performance tip: expect to have only 1 order item</summary>
        public GroupBy(Tup.Cobar.Parser.Ast.Expression.Expression expr, SortOrder order,
            bool withRollup)
        {
            this.orderByList = new List<Pair<Expr, SortOrder>>(1);
            this.orderByList.Add(new Pair<Expr, SortOrder>(expr, order));
            this.withRollup = withRollup;
        }

        /// <summary>performance tip: linked list is used</summary>
        public GroupBy()
        {
            this.orderByList = new List<Pair<Expr, SortOrder
                >>();
        }

        public virtual Tup.Cobar.Parser.Ast.Fragment.GroupBy SetWithRollup()
        {
            withRollup = true;
            return this;
        }

        public virtual Tup.Cobar.Parser.Ast.Fragment.GroupBy AddOrderByItem(Tup.Cobar.Parser.Ast.Expression.Expression
             expr, SortOrder order)
        {
            orderByList.Add(new Pair<Expr, SortOrder>(expr, order));
            return this;
        }

        public virtual void Accept(SQLASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}