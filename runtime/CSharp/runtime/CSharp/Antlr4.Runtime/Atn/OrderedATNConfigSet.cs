/* Copyright (c) 2012-2016 The ANTLR Project. All rights reserved.
 * Use of this file is governed by the BSD 3-clause license that
 * can be found in the LICENSE.txt file in the project root.
 */
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
    /// <author>Sam Harwell</author>
    public partial class OrderedATNConfigSet : ATNConfigSet
    {
        public OrderedATNConfigSet(ATNConfigSet set, bool @readonly)
            : base(set)
        {
            this.readOnly = @readonly;
        }

        public ATNConfigSet Clone(bool @readonly)
        {
            Antlr4.Runtime.Atn.OrderedATNConfigSet copy = new Antlr4.Runtime.Atn.OrderedATNConfigSet(this, @readonly);
            if (!@readonly && this.IsReadOnly)
            {
                copy.AddAll(this.Elements);
            }
            return copy;
        }

        protected internal long GetKey(ATNConfig e)
        {
            return e.GetHashCode();
        }

        protected internal bool CanMerge(ATNConfig left, long leftKey, ATNConfig right)
        {
            return left.Equals(right);
        }
    }
}
