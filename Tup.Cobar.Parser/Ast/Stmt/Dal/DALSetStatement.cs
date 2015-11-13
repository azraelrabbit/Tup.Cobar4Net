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

using System.Collections;
using System.Collections.Generic;
using Tup.Cobar.Parser.Ast.Expression.Primary;
using Tup.Cobar.Parser.Util;
using Tup.Cobar.Parser.Visitor;
using Expr = Tup.Cobar.Parser.Ast.Expression.Expression;

namespace Tup.Cobar.Parser.Ast.Stmt.Dal
{
    /// <author><a href="mailto:shuo.qius@alibaba-inc.com">QIU Shuo</a></author>
    public class DALSetStatement : SQLStatement
    {
        private readonly IList<Pair<VariableExpression, Expr>> assignmentList;

        public DALSetStatement(IList<Pair<VariableExpression, Expr>> assignmentList)
        {
            if (assignmentList == null || assignmentList.IsEmpty())
            {
                this.assignmentList = new List<Pair<VariableExpression, Expr>>(0);
            }
            else
            {
                if (assignmentList is List<Pair<VariableExpression, Expr>>)
                {
                    this.assignmentList = assignmentList;
                }
                else
                {
                    this.assignmentList = new List<Pair<VariableExpression, Expr>>(assignmentList);
                }
            }
        }

        /// <returns>never null</returns>
        public virtual IList<Pair<VariableExpression, Expr>> GetAssignmentList()
        {
            return assignmentList;
        }

        public virtual void Accept(SQLASTVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}