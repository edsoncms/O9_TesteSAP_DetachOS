/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OutSystems.RuntimeCommon {

    public static partial class CollectionsExtensions {

        /// <summary>
        /// Applies the action to each element in the collection. This method fails 
        /// if the actions remove elements from the underlying collection.
        /// </summary>
        [DebuggerNonUserCode]
        public static void Apply<Type>(this IEnumerable<Type> collection, Action<Type> action) {
            foreach (Type item in collection) {
                action(item);
            }
        }

        [DebuggerNonUserCode]
        public static void Apply<Type>(this IEnumerable<Type> collection, Action<Type, int> action) {
            int index = 0;
            foreach (Type item in collection) {
                action(item, index);
                index++;
            }
        }

        [DebuggerNonUserCode]
        public static bool IsOneOf<Type>(this Type obj, params Type[] collection) {
            return collection.Contains(obj);
        }

        [DebuggerNonUserCode]
        public static bool IsOneOfReferentially<Type>(this Type obj, params Type[] collection) {
            return collection.Any(o => ReferenceEquals(o, obj));
        }

        [DebuggerNonUserCode]
        public static T2 FirstNotNull<T1, T2>(this IEnumerable<T1> collection, Func<T1, T2> selector)
            where T2 : class {

            foreach (T1 item in collection) {
                T2 value = selector(item);
                if (value != null) {
                    return value;
                }
            }

            return null;
        }

        [DebuggerNonUserCode]
        public static T GetValueOrDefault<K, T>(this IDictionary<K, T> collection, K key) {
            return GetValueOrDefault(collection, key, default(T));
        }

        [DebuggerNonUserCode]
        public static T GetValueOrDefault<K, T>(this IDictionary<K, T> collection, K key, T defaultValue) {
            T item;
            if (collection.TryGetValue(key, out item)) {
                return item;
            } else {
                return defaultValue;
            }
        }

        [DebuggerNonUserCode]
        public static string GetValueOrEmpty<K>(this IDictionary<K, string> collection, K key) {
            return GetValueOrDefault(collection, key, string.Empty);
        }

        [DebuggerNonUserCode]
        public static T Second<T>(this IEnumerable<T> collection) {
            return collection.ElementAt(1);
        }

        [DebuggerNonUserCode]
        public static T Third<T>(this IEnumerable<T> collection) {
            return collection.ElementAt(2);
        }

        [DebuggerNonUserCode]
        public static T Fourth<T>(this IEnumerable<T> collection) {
            return collection.ElementAt(3);
        }

        [DebuggerNonUserCode]
        public static T Fifth<T>(this IEnumerable<T> collection) {
            return collection.ElementAt(4);
        }

        [DebuggerNonUserCode]
        public static T RemoveLast<T>(this IList<T> list) {
            T obj = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return obj;
        }

        [DebuggerNonUserCode]
        public static T RemoveFirst<T>(this IList<T> list) {
            T obj = list[0];
            list.RemoveAt(0);
            return obj;
        }

        [DebuggerNonUserCode]
        public static bool RemoveFirst<T>(this IList<T> list, Predicate<T> predicate) {
            int index = 0;
            foreach (T obj in list) {
                if (predicate(obj)) {
                    list.RemoveAt(index);
                    return true;
                }
                index++;
            }

            return false;
        }

        [DebuggerNonUserCode]
        public static int RemoveAll<T>(this IList<T> list, Predicate<T> predicate) {
            int numRemoved = 0;
            // Iterate backwards, to avoid a runtime exception when removing
            for (var i = list.Count - 1; i >= 0; i--) {
                if (predicate(list[i])) {
                    list.RemoveAt(i);
                    numRemoved++;
                }
            }
            return numRemoved;
        }

        [DebuggerNonUserCode]
        public static IEnumerable<T> ToEnumerable<T>(this T obj) {
            if (obj != null) {
                yield return obj;
            }
        }

        [DebuggerNonUserCode]
        public static int IndexOf<Type>(this IEnumerable<Type> collection, Type item) {
            var list = collection as IList<Type>;
            if (list != null) {
                return list.IndexOf(item);
            }

            using (var iter = collection.GetEnumerator()) {
                int i = 0;
                while (iter.MoveNext()) {
                    if (iter.Current.Equals(item)) {
                        return i;
                    } else {
                        i += 1;
                    }
                }
            }

            return -1;
        }

        [DebuggerNonUserCode]
        public static bool CountEquals<Type>(this IEnumerable<Type> collection, int countToCompare) {
            ICollection<Type> col = collection as ICollection<Type>;
            if (col != null) {
                return col.Count == countToCompare;
            } else {
                int count = 0;
                if (collection != null) {
                    using (var iter = collection.GetEnumerator()) {
                        while (iter.MoveNext()) {
                            count += 1;
                            if (count > countToCompare) {
                                return false;
                            }
                        }
                    }
                }
                return count == countToCompare;
            }
        }

        [DebuggerNonUserCode]
        public static bool CountBiggerThan<Type>(this IEnumerable<Type> collection, int countToCompare) {
            ICollection<Type> col = collection as ICollection<Type>;
            if (col != null) {
                return col.Count > countToCompare;
            } else {
                int count = 0;
                if (collection != null) {
                    using (var iter = collection.GetEnumerator()) {
                        while (iter.MoveNext()) {
                            count += 1;
                            if (count > countToCompare) {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        [DebuggerNonUserCode]
        public static int IndexOf<Type>(this IEnumerable<Type> collection, Predicate<Type> match) {
            using (var iter = collection.GetEnumerator()) {
                int i = 0;
                while (iter.MoveNext()) {
                    if (match(iter.Current)) {
                        return i;
                    } else {
                        i += 1;
                    }
                }
            }
            return -1;
        }

        [DebuggerNonUserCode]
        public static Pair<int, Type> GetIndexOfAndObject<Type>(this IEnumerable<Type> collection, Predicate<Type> match) {
            using (var iter = collection.GetEnumerator()) {
                int i = 0;
                while (iter.MoveNext()) {
                    var current = iter.Current;
                    if (match(current)) {
                        return Pair.Create(i, current);
                    } else {
                        i += 1;
                    }
                }
            }
            return null;
        }

        [DebuggerNonUserCode]
        public static bool IsEmpty(this byte[] byteArray) {
            return byteArray == null || byteArray.Length == 0;
        }

        [DebuggerNonUserCode]
        public static bool IsEmpty<T>(this T[] array) {
            return array.Length == 0;
        }

        [DebuggerNonUserCode]
        public static bool IsEmpty<T>(this ICollection<T> collection) {
            return collection.Count == 0;
        }

        [DebuggerNonUserCode]
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection) {
            return collection == null || collection.IsEmpty();
        }

        [DebuggerNonUserCode]
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) {
            var collection = enumerable as ICollection<T>;
            if (collection != null) {
                return collection.Count == 0;
            } else {
                using (var iter = enumerable.GetEnumerator()) {
                    return !iter.MoveNext();
                }
            }
        }


        [DebuggerNonUserCode]
        public static Pair<IEnumerable<T>, IEnumerable<T>> Partition<T>(this IEnumerable<T> collection, Func<T, bool> predicate) {
            return Pair.Create<IEnumerable<T>, IEnumerable<T>>(collection.Where(predicate), collection.Where(elem => !predicate(elem)));
        }

        //for performance reasons, avoid implicit convertion to IEnumerable<char>
        [DebuggerNonUserCode]
        public static bool IsNullOrEmpty(this string s) {
            return string.IsNullOrEmpty(s);
        }

        [DebuggerNonUserCode]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) {
            return enumerable == null || enumerable.IsEmpty();
        }

        [DebuggerNonUserCode]
        public static bool IsSingle<T>(this T[] array) {
            return array.Length == 1;
        }

        [DebuggerNonUserCode]
        public static bool IsSingle<T>(this ICollection<T> collection) {
            return collection.Count == 1;
        }

        [DebuggerNonUserCode]
        public static bool IsSingle<T>(this IEnumerable<T> enumerable) {
            var collection = enumerable as ICollection<T>;
            if (collection != null) {
                return collection.Count == 1;
            } else {
                using (var iter = enumerable.GetEnumerator()) {
                    return iter.MoveNext() && !iter.MoveNext();
                }
            }
        }

        [DebuggerNonUserCode]
        public static bool IsEmptyOrSingle<T>(this T[] array) {
            return array.Length == 0 || array.Length == 1;
        }

        [DebuggerNonUserCode]
        public static bool IsEmptyOrSingle<T>(this ICollection<T> collection) {
            return collection.Count == 0 || collection.Count == 1;
        }

        [DebuggerNonUserCode]
        public static bool IsEmptyOrSingle<T>(this IEnumerable<T> enumerable) {
            var collection = enumerable as ICollection<T>;
            if (collection != null) {
                return collection.Count == 0 || collection.Count == 1;
            } else {
                using (var iter = enumerable.GetEnumerator()) {
                    if (!iter.MoveNext()) {
                        return true;
                    } else {
                        return !iter.MoveNext();
                    }
                }
            }
        }

        [DebuggerNonUserCode]
        public static Type FirstIfSingleOrDefault<Type>(this IEnumerable<Type> collection) {

            using (var iter = collection.GetEnumerator()) {
                if (iter.MoveNext()) {
                    Type first = iter.Current;
                    if (!iter.MoveNext()) {
                        return first;
                    } else {
                        return default(Type);
                    }
                }
            }

            return default(Type);
        }

        [DebuggerNonUserCode]
        public static Type FirstIfSingleOrDefault<Type>(this IEnumerable<Type> collection, Predicate<Type> match) {

            using (var iter = collection.Where(obj => match(obj)).GetEnumerator()) {
                if (iter.MoveNext()) {
                    Type first = iter.Current;
                    if (!iter.MoveNext()) {
                        return first;
                    } else {
                        return default(Type);
                    }
                }
            }

            return default(Type);
        }

        [DebuggerNonUserCode]
        public static int AddRange<Type>(this ICollection<Type> collection, IEnumerable<Type> otherCollection) {
            int count = 0;

            var set = collection as HashSet<Type>;
            if (set != null) {
                foreach (Type item in otherCollection) {
                    if (set.Add(item)) {
                        count += 1;
                    }
                }
            } else if (collection != null) {
                foreach (Type item in otherCollection) {
                    collection.Add(item);
                    count += 1;
                }
            }

            return count;
        }

        [DebuggerNonUserCode]
        public static void CopyTo<Type>(this IEnumerable<Type> collection, Type[] array) {
            int i = 0;
            foreach (Type item in collection) {
                array[i++] = item;
            }
        }

        [DebuggerNonUserCode]
        public static void CopyTo<Type>(this IEnumerable<Type> collection, Type[] array, int arrayIndex) {
            int i = 0;
            foreach (Type item in collection) {
                array[arrayIndex + i++] = item;
            }
        }

        [DebuggerNonUserCode]
        public static string StrCat<T>(this IEnumerable<T> source, string separator) {
            var sb = new StringBuilder();
            bool first = true;
            foreach (T elem in source) {
                if (first) {
                    first = false;
                } else {
                    sb.Append(separator);
                }
                sb.Append(elem.ToString());
            }
            return sb.ToString();
        }

        [DebuggerNonUserCode]
        public static string StrCat(this IEnumerable<string> source, string separator) {
            var sb = new StringBuilder();
            bool first = true;
            foreach (string elem in source) {
                if (first) {
                    first = false;
                } else {
                    sb.Append(separator);
                }
                sb.Append(elem ?? "");
            }
            return sb.ToString();
        }

        [DebuggerNonUserCode]
        public static string StrCat(this IEnumerable<string> source, string separator, bool skipEmptyElements) {
            if (skipEmptyElements) {
                return StrCat(source.Where(e => !e.IsEmpty()), separator);
            } else {
                return StrCat(source, separator);
            }
        }

        [DebuggerNonUserCode]
        public static string StrCat(this IList<string> source, string separator, string lastSeparator) {
            var sb = new StringBuilder();
            for (int i = 0; i < source.Count; ++i) {
                if (i != 0) {
                    if (i == source.Count - 1) {
                        sb.Append(lastSeparator);
                    } else if (i != 0) {
                        sb.Append(separator);
                    }
                }
                sb.Append(source[i] ?? "");
            }
            return sb.ToString();
        }

        [DebuggerNonUserCode]
        public static IEnumerable<Type> Concat<Type>(this IEnumerable<Type> collection, params Type[] extraItems) {
            return collection.Concat(extraItems.AsEnumerable());
        }

        [DebuggerNonUserCode]
        public static byte[] Concat(this byte[] a, byte[] b) {
            // this implementation exists because Sharptranslator has problems with the generic translation
            var result = new byte[a.Length + b.Length];
            Array.Copy(a, result, a.Length);
            Array.Copy(b, 0, result, a.Length, b.Length);
            return result;
        }

        [DebuggerNonUserCode]
        public static bool StartsWith<T>(this IEnumerable<T> firstCollection, IEnumerable<T> secondCollection) {
            using (var secondCollectionEnumerator = secondCollection.GetEnumerator()) {
                foreach (T firstCollectionElem in firstCollection) {
                    if (!secondCollectionEnumerator.MoveNext()) {
                        return true;
                    }
                    if (!firstCollectionElem.Equals(secondCollectionEnumerator.Current)) {
                        return false;
                    }
                }
            }

            return true;
        }

        [DebuggerNonUserCode]
        private static void Move<Type>(this IList<Type> list, int from, int to) {
            var value = list[from];
            list.RemoveAt(from);
            list.Insert(to, value);
        }

        [DebuggerNonUserCode]
        public static void SetOrderTo<Type>(this IList<Type> list, IEnumerable<Type> orderList) {
            list.SetOrderTo<Type, Type>(orderList, (a, b) => Equals(a, b));
        }

        [DebuggerNonUserCode]
        public static void SetOrderTo<Type>(this IList<Type> list, IEnumerable<Type> orderList, Action<int, int> move) {
            list.SetOrderTo(orderList, (a, b) => Equals(a, b), move);
        }

        [DebuggerNonUserCode]
        public static void SetOrderTo<Type1, Type2>(this IList<Type1> list, IEnumerable<Type2> orderList, Func<Type1, Type2, bool> equals) {
            list.SetOrderTo(orderList, equals, (from, to) => list.Move(from, to));
        }

        [DebuggerNonUserCode]
        public static void SetOrderTo<Type1, Type2>(this IList<Type1> list, IEnumerable<Type2> orderList, Func<Type1, Type2, bool> equals, Action<int, int> move) {
            using (var orderListIter = orderList.GetEnumerator()) {
                orderListIter.MoveNext();
                for (int i = 0; i < list.Count; ++i, orderListIter.MoveNext()) {
                    var desiredItem = orderListIter.Current;
                    if (!equals(list[i], desiredItem)) {
                        int j = i;
                        do {
                            j += 1;
                            if (j >= list.Count) {
                                throw new InvalidOperationException("Object not found: " + desiredItem.ToString());
                            }
                        } while (!equals(list[j], desiredItem));
                        move(j, i);
                    }
                }
            }
        }

        [DebuggerNonUserCode]
        public static void QuickSort<T>(this IList<T> collection, Func<T, T, int> compare) {
            collection.QuickSort(
                compare,
                (i, j) => {
                    var temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;
                });
        }

        [DebuggerNonUserCode]
        public static void QuickSort<T>(this IList<T> collection, Func<T, T, int> compare, Action<int, int> swap) {
            collection.QuickSort(0, collection.Count - 1, compare, swap);
        }

        [DebuggerNonUserCode]
        private static void QuickSort<T>(this IList<T> collection, int i, int j, Func<T, T, int> compare, Action<int, int> swap) {
            if (i < j) {
                int q = Partition(collection, i, j, compare, swap);
                QuickSort(collection, i, q, compare, swap);
                QuickSort(collection, q + 1, j, compare, swap);
            }
        }

        [DebuggerNonUserCode]
        private static int Partition<T>(IList<T> collection, int p, int r, Func<T, T, int> compare, Action<int, int> swap) {
            T x = collection[p];
            int i = p - 1;
            int j = r + 1;
            while (true) {
                do {
                    j -= 1;
                } while (compare(collection[j], x) > 0);
                do {
                    i += 1;
                } while (compare(collection[i], x) < 0);
                if (i < j) {
                    swap(i, j);
                } else {
                    return j;
                }
            }
        }

        [DebuggerNonUserCode]
        public static Func<A, R> Memoize<A, R>(this Func<A, R> f) {
            var map = new Dictionary<A, R>();
            return a => {
                R value;
                if (map.TryGetValue(a, out value)) {
                    return value;
                }
                value = f(a);
                map.Add(a, value);
                return value;
            };
        }

        [DebuggerNonUserCode]
        public static Func<A, B, R> Memoize<A, B, R>(this Func<A, B, R> f) {
            var map = CreateDictionaryOf<R>.WithKey(new { a = default(A), b = default(B) });
            return (a, b) => {
                var tuple = new { a, b };
                R value;
                if (map.TryGetValue(tuple, out value)) {
                    return value;
                }
                value = f(a, b);
                map.Add(tuple, value);
                return value;
            };
        }

        [DebuggerNonUserCode]
        public static Func<A, B, C, R> Memoize<A, B, C, R>(this Func<A, B, C, R> f) {
            var map = CreateDictionaryOf<R>.WithKey(new { a = default(A), b = default(B), c = default(C) });
            return (a, b, c) => {
                var tuple = new { a, b, c };
                R value;
                if (map.TryGetValue(tuple, out value)) {
                    return value;
                }
                value = f(a, b, c);
                map.Add(tuple, value);
                return value;
            };
        }

        private static class CreateDictionaryOf<Value> {
            public static Dictionary<Key, Value> WithKey<Key>(Key prototype) {
                return new Dictionary<Key, Value>();
            }
        }

        [DebuggerNonUserCode]
        public static IEnumerable<TSource> Distinct<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> comparer) {
            return source.Distinct(new DynamicEqualityComparer<TSource, TResult>(comparer));
        }

        [DebuggerNonUserCode]
        public static IOrderedEnumerable<T> OrderBy<T, TT>(this IEnumerable<T> source, Func<T, TT> selector, Func<TT, TT, int> comparer) {
            return source.OrderBy(obj => selector(obj), new DynamicComparer<TT>(comparer));
        }

        [DebuggerNonUserCode]
        public static IOrderedEnumerable<T> OrderByDescending<T, TT>(this IEnumerable<T> source, Func<T, TT> selector, Func<TT, TT, int> comparer) {
            return source.OrderByDescending(obj => selector(obj), new DynamicComparer<TT>(comparer));
        }

        [DebuggerNonUserCode]
        public static IOrderedEnumerable<T> ThenBy<T, TT>(this IOrderedEnumerable<T> source, Func<T, TT> selector, Func<TT, TT, int> comparer) {
            return source.ThenBy(obj => selector(obj), new DynamicComparer<TT>(comparer));
        }

        [DebuggerNonUserCode]
        public static IComparer<T> ToComparer<T>(this Func<T, T, int> comparer) {
            return new DynamicComparer<T>(comparer);
        }

        [DebuggerNonUserCode]
        public static bool Contains<TSource, TResult>(this IEnumerable<TSource> source, TResult value, Func<TSource, TResult> selector) {
            foreach (TSource sourceItem in source) {
                TResult sourceValue = selector(sourceItem);
                if (sourceValue.Equals(value))
                    return true;
            }
            return false;
        }

        [DebuggerNonUserCode]
        public static Expression<Func<T, R>> AsExpression<T, R>(Expression<Func<T, R>> f) {
            return f;
        }

        [DebuggerNonUserCode]
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dic) {
            return dic.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        [DebuggerNonUserCode]
        public static Func<T, R> AsFunc<T, R>(Func<T, R> f) {
            return f;
        }

        [DebuggerNonUserCode]
        public static bool ArrayEquals(this byte[] a, byte[] b) {
            if (a.Length != b.Length) {
                return false;
            }
            for (int i = 0; i < a.Length; ++i) {
                if (a[i] != b[i]) {
                    return false;
                }
            }
            return true;
        }

        [DebuggerNonUserCode]
        //Note: This method returns true only if the two enumerables have the same elements in the same order.
        public static bool HasSameElements<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2) {

            using (var enum1 = seq1.GetEnumerator()) {
                using (var enum2 = seq2.GetEnumerator()) {

                    int count1 = 0;
                    int count2 = 0;

                    while (enum1.MoveNext()) {
                        count1++;
                        if (!enum2.MoveNext()) {
                            break;
                        }
                        count2++;
                        if (!enum1.Current.Equals(enum2.Current)) {
                            return false;
                        }
                    }

                    bool seq2Empty = !enum2.MoveNext();
                    return count1 == count2 && seq2Empty;
                }
            }
        }

        [DebuggerNonUserCode]
        public static bool HasSameElementsIgnoreOrder<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2) {
            var seq2Array = seq2.ToArray();
            var seq2Size = seq2.Count();
            List<int> matchedIndex = new List<int>();

            if (seq1.Count() == seq2Size) {

                foreach (var element in seq1) {
                    var noMatch = true;
                    for (var i = 0; i < seq2Size; i++) {
                        if (seq2Array[i].Equals(element) && !matchedIndex.Contains(i)) {
                            matchedIndex.Add(i);
                            noMatch = false;
                            break;
                        }
                    }
                    if (noMatch) {
                        return false;
                    }
                }
                return true;
            } else {
                return false;
            }
        }

        [DebuggerNonUserCode]
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> fromEnumerable) {
            var hashSet = fromEnumerable as HashSet<T>;
            if (hashSet != null) {
                return hashSet;
            } else {
                return new HashSet<T>(fromEnumerable);
            }
        }

        [DebuggerNonUserCode]
        public static Func<TKey, TValue> ToFunc<TKey, TValue>(this IDictionary<TKey, TValue> dict) {
            return key => dict.GetValueOrDefault(key);
        }

        [DebuggerNonUserCode]
        public static bool IsBetween(this int value, int start, int end) {
            return start <= value && value <= end;
        }

        [DebuggerNonUserCode]
        public static bool HasDuplicates(this IEnumerable enumerable) {
            var hashSet = new HashSet<object>();
            foreach (var item in enumerable) {
                if (!hashSet.Add(item)) {
                    return true;
                }
            }
            return false;
        }

        [DebuggerNonUserCode]
        public static ICollection<T> AsCollection<T>(this ICollection<T> collection) {
            return collection;
        }

        [DebuggerNonUserCode]
        public static IEnumerable<Pair<T1, T2>> ZipWith<T1, T2>(this IEnumerable<T1> self, IEnumerable<T2> other) {
            using (var selfEnum = self.GetEnumerator()) {
                using (var otherEnum = other.GetEnumerator()) {
                    while (selfEnum.MoveNext() && otherEnum.MoveNext()) {
                        yield return Pair.Create(selfEnum.Current, otherEnum.Current);
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to get the value from the dictionary or add a default (running the supplied getter) if
        /// no value was found.
        /// Getter may run several times on concurrent accesses.
        /// </summary>
        [DebuggerNonUserCode]
        public static TVal GetOrAdd<TKey, TVal>(this IDictionary<TKey, TVal> self, TKey key, Func<TVal> valGetter) {
            TVal valueToAdd;
            lock (self) {
                if (self.TryGetValue(key, out valueToAdd)) {
                    return valueToAdd;
                }

            }
            valueToAdd = valGetter();
            lock (self) {
                self[key] = valueToAdd;
                return valueToAdd;
            }
        } 

    }
}