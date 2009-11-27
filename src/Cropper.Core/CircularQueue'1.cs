#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    /// Circle collection. Elements will be circled clockwise.
    /// </summary>
    internal class CircularQueue<T> : IEnumerable<T>, ICollection
    {
        #region Member Fields

        private readonly Queue<T> items;
        private readonly bool isReadOnly;

        #endregion

        #region .ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularQueue{T}"/> class.
        /// </summary>
        public CircularQueue() : this(null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularQueue{T}"/> class.
        /// </summary>
        /// <param name="items">The initial items in the <see cref="CircularQueue{T}"/>.</param>
        public CircularQueue(IEnumerable<T> items) : this(items, false) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularQueue{T}"/> class.
        /// </summary>
        /// <param name="items">The initial items in the <see cref="CircularQueue{T}"/>.</param>
        /// <param name="isReadOnly">If set to <see langword="true"/> the collection is readonly.</param>
        public CircularQueue(IEnumerable<T> items, bool isReadOnly)
        {
            this.isReadOnly = isReadOnly;
            this.items = new Queue<T>();
            if (items != null)
            {
                foreach (T item in items)
                    this.items.Enqueue(item);
            }
        }

        #endregion

        /// <summary>
        /// Returns the next item in the queue and starts from the begining when the end of 
        /// the queue is reached.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">The <see cref="CircularQueue{T}"/>
        /// is empty.</exception>
        public T Next()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("The CircularQueue is empty");

            T item = items.Dequeue();
            items.Enqueue(item);
            return item;
        }

        ///<summary>
        ///Copies the <see cref="CircularQueue{T}"></see> elements to a new array.
        ///</summary>
        ///<returns>
        ///A new array containing elements copied from the <see cref="CircularQueue{T}"></see>.
        ///</returns>
        public T[] ToArray()
        {
            return items.ToArray();
        }

        ///<summary>
        ///Sets the capacity to the actual number of elements in the <see cref="CircularQueue{T}">
        /// </see>, if that number is less than 90 percent of current capacity.
        ///</summary>
        ///
        public void TrimExcess()
        {
            if (isReadOnly)
                throw new ReadOnlyException("The collection is readonly and can not be modified.");

            items.TrimExcess();
        }

        /// <summary>
        ///Adds an object to the end of the <see cref="CircularQueue{T}"></see>.
        ///</summary>
        ///
        ///<param name="item">The object to add to the <see cref="CircularQueue{T}"></see>. 
        /// The value can be null for reference types.</param>
        public void Enqueue(T item)
        {
            if (isReadOnly)
                throw new ReadOnlyException("The collection is readonly and can not be modified.");

            items.Enqueue(item);
        }

        #region ICollection Implementation

        /// <summary>
        /// Copies the elements of the <see cref="ICollection"></see> to an 
        /// <see cref="Array"></see>, starting at a particular <see cref="Array"></see> index.
        /// </summary>
        ///
        /// <param name="array">The one-dimensional <see cref="Array"></see> that is the 
        /// destination of the elements copied from <see cref="ICollection"></see>. 
        /// The <see cref="Array"></see> must have zero-based indexing. </param>
        /// <param name="index">The zero-based index in array at which copying begins. </param>
        /// <exception cref="ArgumentNullException">array is null. </exception>
        /// <exception cref="ArgumentOutOfRangeException">index is less than zero. </exception>
        /// <exception cref="ArgumentException">array is multidimensional.-or- index is 
        /// equal to or greater than the length of array.-or- The number of elements in the source 
        /// <see cref="ICollection"></see> is greater than the available space 
        /// from index to the end of the destination array. </exception>
        /// <exception cref="InvalidCastException">The type of the source 
        /// <see cref="ICollection"></see> cannot be cast automatically to 
        /// the type of the destination array. </exception><filterpriority>2</filterpriority>
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)items).CopyTo(array, index);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ICollection"></see>.
        /// </summary>
        ///
        /// <returns>
        /// The number of elements contained in the <see cref="ICollection"></see>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public int Count
        {
            get { return items.Count; }
        }

        ///<summary>
        ///Gets an object that can be used to synchronize access to the 
        /// <see cref="ICollection"></see>.
        ///</summary>
        ///
        ///<returns>
        ///An object that can be used to synchronize access to the <see cref="ICollection"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public object SyncRoot
        {
            get { return ((ICollection)items).SyncRoot; }
        }

        ///<summary>
        ///Gets a value indicating whether access to the <see cref="ICollection"></see> 
        /// is synchronized (thread safe).
        ///</summary>
        ///
        ///<returns>
        ///true if access to the <see cref="ICollection"></see> is synchronized 
        /// (thread safe); otherwise, false.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public bool IsSynchronized
        {
            get { return ((ICollection)items).IsSynchronized; }
        }

        #endregion

        #region Enumerable<T> Implementation

        ///<summary>
        ///Returns an enumerator that iterates through the collection.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="IEnumerator{T}"></see> that can be used to iterate 
        /// through the collection.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        ///<summary>
        ///Returns an enumerator that iterates through a collection.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="IEnumerator"></see> object that can be used to iterate 
        /// through the collection.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        #endregion
    }
}