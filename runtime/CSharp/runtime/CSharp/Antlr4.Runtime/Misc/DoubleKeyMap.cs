using System;
using System.Collections.Generic;
using System.Linq;

using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Misc
{
	public class DoubleKeyMap<K1, K2, V> where V : class
	{
		Dictionary<K1, Dictionary<K2, V>> data = new Dictionary<K1, Dictionary<K2, V>>();

		public V Put(K1 k1, K2 k2, V v)
		{
			Dictionary<K2, V> data2 = data.Get(k1);
			V prev = default(V);
			if (data2 == null)
			{
				data2 = new Dictionary<K2, V>();
				data.Put(k1, data2);
			}
			else {
				prev = data2.Get(k2);
			}
			data2.Put(k2, v);
			return prev;
		}

		public V Get(K1 k1, K2 k2)
		{
			Dictionary<K2, V> data2 = data.Get(k1);
			if (data2 == null) return null;
			return data2.Get(k2);
		}

		public Dictionary<K2, V> Get(K1 k1) { return data.Get(k1); }

		/** Get all values associated with primary key */
		public ICollection<V> Values(K1 k1)
		{
			Dictionary<K2, V> data2 = data.Get(k1);
			if (data2 == null) return null;
			return data2.Values;
		}

		/** get all primary keys */
		public HashSet<K1> KeySet()
		{
			return new HashSet<K1>(data.Keys);
		}

		/** get all secondary keys associated with a primary key */
		public HashSet<K2> KeySet(K1 k1)
		{
			Dictionary<K2, V> data2 = data.Get(k1);
			if (data2 == null) return null;
			return new HashSet<K2>(data2.Keys);
		}
	}

}
