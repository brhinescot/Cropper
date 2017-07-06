#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    ///     Circle collection. Elements will be circled clockwise.
    /// </summary>
    internal class CircularQueue<T> : IEnumerable<T>, ICollection
    {
        /// <summary>
        ///     Returns the next item in the queue and starts from the begining when the end of
        ///     the queue is reached.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">
        ///     The <see cref="CircularQueue{T}" />
        ///     is empty.
        /// </exception>
        public T Next()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("The CircularQueue is empty");

            T item = items.Dequeue();
            items.Enqueue(item);
            return item;
        }

        /// <summary>
        ///     Copies the <see cref="CircularQueue{T}"></see> elements to a new array.
        /// </summary>
        /// <returns>
        ///     A new array containing elements copied from the <see cref="CircularQueue{T}"></see>.
        /// </returns>
        public T[] ToArray()
        {
            return items.ToArray();
        }

        /// <summary>
        ///     Sets the capacity to the actual number of elements in the
        ///     <see cref="CircularQueue{T}">
        ///     </see>
        ///     , if that number is less than 90 percent of current capacity.
        /// </summary>
        public void TrimExcess()
        {
            if (isReadOnly)
                throw new ReadOnlyException("The collection is readonly and can not be modified.");

            items.TrimExcess();
        }

        /// <summary>
        ///     Adds an object to the end of the <see cref="CircularQueue{T}"></see>.
        /// </summary>
        /// <param name="item">
        ///     The object to add to the <see cref="CircularQueue{T}"></see>.
        ///     The value can be null for reference types.
        /// </param>
        public void Enqueue(T item)
        {
            if (isReadOnly)
                throw new ReadOnlyException("The collection is readonly and can not be modified.");

            items.Enqueue(item);
        }

        #region Member Fields

        private readonly Queue<T> items;
        private readonly bool isReadOnly;

        #endregion

        #region .ctors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircularQueue{T}" /> class.
        /// </summary>
        public CircularQueue() : this(null) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircularQueue{T}" /> class.
        /// </summary>
        /// <param name="items">The initial items in the <see cref="CircularQueue{T}" />.</param>
        public CircularQueue(IEnumerable<T> items) : this(items, false) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircularQueue{T}" /> class.
        /// </summary>
        /// <param name="items">The initial items in the <see cref="CircularQueue{T}" />.</param>
        /// <param name="isReadOnly">If set to <see langword="true" /> the collection is readonly.</param>
        public CircularQueue(IEnumerable<T> items, bool isReadOnly)
        {
            this.isReadOnly = isReadOnly;
            this.items = new Queue<T>();
            if (items != null)
                foreach (T item in items)
                    this.items.Enqueue(item);
        }

        #endregion

        #region ICollection Implementation

        /// <summary>
        ///     Copies the elements of the <see cref="ICollection"></see> to an
        ///     <see cref="Array"></see>, starting at a particular <see cref="Array"></see> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="Array"></see> that is the
        ///     destination of the elements copied from <see cref="ICollection"></see>.
        ///     The <see cref="Array"></see> must have zero-based indexing.
        /// </param>
        /// <param name="index">The zero-based index in array at which copying begins. </param>
        /// <exception cref="ArgumentNullException">array is null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">index is less than zero. </exception>
        /// <exception cref="ArgumentException">
        ///     array is multidimensional.-or- index is
        ///     equal to or greater than the length of array.-or- The number of elements in the source
        ///     <see cref="ICollection"></see> is greater than the available space
        ///     from index to the end of the destination array.
        /// </exception>
        /// <exception cref="InvalidCastException">
        ///     The type of the source
        ///     <see cref="ICollection"></see> cannot be cast automatically to
        ///     the type of the destination array.
        /// </exception>
        /// <filterpriority>2</filterpriority>
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection) items).CopyTo(array, index);
        }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="ICollection"></see>.
        /// </summary>
        /// <returns>
        ///     The number of elements contained in the <see cref="ICollection"></see>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public int Count => items.Count;

        /// <summary>
        ///     Gets an object that can be used to synchronize access to the
        ///     <see cref="ICollection"></see>.
        /// </summary>
        /// <returns>
        ///     An object that can be used to synchronize access to the <see cref="ICollection"></see>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public object SyncRoot => ((ICollection) items).SyncRoot;

        /// <summary>
        ///     Gets a value indicating whether access to the <see cref="ICollection"></see>
        ///     is synchronized (thread safe).
        /// </summary>
        /// <returns>
        ///     true if access to the <see cref="ICollection"></see> is synchronized
        ///     (thread safe); otherwise, false.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public bool IsSynchronized => ((ICollection) items).IsSynchronized;

        #endregion

        #region Enumerable<T> Implementation

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     A <see cref="IEnumerator{T}"></see> that can be used to iterate
        ///     through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///     An <see cref="IEnumerator"></see> object that can be used to iterate
        ///     through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        #endregion
    }
}