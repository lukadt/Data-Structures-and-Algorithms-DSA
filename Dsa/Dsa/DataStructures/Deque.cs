﻿// <copyright file="Deque.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   A double ended queue - deque. This implementation uses a doubly linked
//   list as its backing data structure. While a node is more expensive in
//   terms of memory than an array based implementation we avoid O(n) copy
//   operations when we outgrow an array. Other than that the run time complexities
//   are identical.
//   By default our implementation of a deque enqueues items to the back of the
//   queue by default, e.g. a call to Add will call EnqueueBack(...). This is important
//   to remember as object initializers on collections will implicitly call the Add
//   method.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.DataStructures
{
    /// <summary>
    /// A double ended queue. Deque.
    /// </summary>
    /// <typeparam name="T">Type of the <see cref="Deque{T}"/>.</typeparam>
    public class Deque<T> : CollectionBase<T> 
        where T : IComparable<T>
    {
        private readonly DoublyLinkedList<T> m_deque;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class.
        /// </summary>
        public Deque()
        {
            m_deque = new DoublyLinkedList<T>();
        }

        /// <summary>
        /// Adds an item to the <see cref="Deque{T}"/>. This calls <see cref="EnqueueBack"/> internally.
        /// </summary>
        /// <param name="item">Item to add to the <see cref="Deque{T}"/>.</param>
        public override void Add(T item)
        {
            EnqueueBack(item);
        }

        /// <summary>
        /// Clears all items from the <see cref="ICollection{T}"/>.
        /// </summary>
        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="ICollection{T}"/> for.</param>
        /// <returns>True if the item is in the <see cref="ICollection{T}"/>; otherwise false.</returns>
        public override bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes an item from the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from collection.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Converts the collection to a single dimension array.
        /// </summary>
        /// <returns>An array of the items in the collection.</returns>
        public override T[] ToArray()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Enqueues an item into the <see cref="Deque{T}"/> at the front of the queue.
        /// </summary>
        /// <param name="item">Item to add to the front of the <see cref="Deque{T}"/>.</param>
        public void EnqueueFront(T item)
        {
            m_deque.AddFirst(item);
            Count++;
        }

        /// <summary>
        /// Enqueues an item into the <see cref="Deque{T}"/> at the back of the queue.
        /// </summary>
        /// <param name="item">Item to add to the back of the <see cref="Deque{T}"/>.</param>
        public void EnqueueBack(T item)
        {
            m_deque.AddLast(item);
            Count++;
        }

        /// <summary>
        /// Returns the item at the front of the <see cref="Deque{T}"/> and then removes that item from the
        /// <see cref="Deque{T}"/>.
        /// </summary>
        /// <returns>Item at the front of the <see cref="Deque{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Deque{T}"/> contains <strong>0</strong> items.
        /// </exception>
        public T DequeueFront()
        {
            Guard.InvalidOperation(Count == 0, Resources.DequeDequeueEmpty);

            T item = m_deque.Head.Value;
            m_deque.RemoveFirst();
            Count--;

            return item;
        }

        /// <summary>
        /// Returns the item at the back of the <see cref="Deque{T}"/> and then removes that item from the
        /// <see cref="Deque{T}"/>.
        /// </summary>
        /// <returns>Item at the back of the <see cref="Deque{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Deque{T}"/> contains <strong>0</strong> items.
        /// </exception>
        public T DequeueBack()
        {
            Guard.InvalidOperation(Count == 0, Resources.DequeDequeueEmpty);

            T item = m_deque.Tail.Value;
            m_deque.RemoveLast();
            Count--;

            return item;
        }

        /// <summary>
        /// Returns the item at the front of the <see cref="Deque{T}"/> without removing it.
        /// </summary>
        /// <returns>The item at the front of the <see cref="Deque{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Deque{T}"/> contains <strong>0</strong> items.
        /// </exception>
        public T PeekFront()
        {
            Guard.InvalidOperation(Count == 0, Resources.DequePeekEmpty);

            return m_deque.Head.Value;
        }

        /// <summary>
        /// Returns the item at the back of the <see cref="Deque{T}"/> without removing it.
        /// </summary>
        /// <returns>The item at the back of the <see cref="Deque{T}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Deque{T}"/> contains <strong>0</strong> items.
        /// </exception>
        public T PeekBack()
        {
            Guard.InvalidOperation(Count == 0, Resources.DequePeekEmpty);

            return m_deque.Tail.Value;
        }
    }
}
