
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

namespace nvoid.Documents
{
    public abstract class EntityDocument<T>
    {
        private Dictionary<string, Delegate> mMemberMap = new Dictionary<string, Delegate>();
        protected Dictionary<string, Delegate> Members
        {
            get { return mMemberMap; }
            set { mMemberMap = value; }
        }


        public void MapColumn<TMember>(Expression<Func<T, TMember>> selector, string altName = null)
        {
            string keyName = null;
            if (string.IsNullOrEmpty(altName))
            {
                MemberExpression propExpr = (MemberExpression)selector.Body;
                dynamic member = propExpr.Member.Name;
                keyName = member;
                if (!string.IsNullOrEmpty(altName))
                {
                    keyName = altName;
                }
            }
            else
            {
                keyName = altName;
            }

            if (mMemberMap.ContainsKey(keyName))
            {
                mMemberMap[keyName] = selector.Compile();
            }
            else
            {
                mMemberMap.Add(keyName, selector.Compile());
            }
        }
    }
} 