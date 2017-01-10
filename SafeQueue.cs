using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestProject
{
    /// <summary>
    /// Потокобезопасная очередь, реализует операции добавления и получения элементов из очереди.
    /// </summary>
    /// <typeparam name="T">Тип элементов очереди</typeparam>
    public class SafeQueue<T>
    {
        private Queue<T> _queue;

        public SafeQueue()
        {
            _queue = new Queue<T>();
        }
                
        /// <summary>
        /// Поставить элемент в очередь
        /// </summary>
        public void Push(T item)
        {
            Monitor.Enter(_queue);
            try
            {
                _queue.Enqueue(item);
                Monitor.Pulse(_queue);
            }
            catch
            {
                throw;
            }
            finally
            {
                Monitor.Exit(_queue);
            }
        }

        /// <summary>
        /// Получить элемент из очереди. В случае отсутствия элементов, ожидается добавление нового элемента
        /// </summary>
        public T Pop()
        {
            Monitor.Enter(_queue);
            try
            {
                if (!_queue.Any())
                {
                    Monitor.Wait(_queue);
                    return Pop();
                }

                return _queue.Dequeue();
            }
            catch
            {
                throw;
            }
            finally
            {
                Monitor.Exit(_queue);
            }            
        }
    }
}
