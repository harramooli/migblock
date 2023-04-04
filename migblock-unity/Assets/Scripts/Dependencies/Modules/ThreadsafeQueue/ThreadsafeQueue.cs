
using System.Threading;
using System.Collections.Generic;

public class ThreadsafeQueue<T> {

    private Mutex mutex = new Mutex();

    private Queue<T> data = new Queue<T>();

    public void Enqueue (T item) {

        mutex.WaitOne(); try {

            data.Enqueue(item);

        } finally { mutex.ReleaseMutex(); }
    }

    public T Dequeue () {

        T item = default(T);

        mutex.WaitOne(); try {

            item = data.Dequeue();

            return item;

        } finally { mutex.ReleaseMutex(); }
    }

    public int Size () {

        mutex.WaitOne(); try {

            return data.Count;

        } finally { mutex.ReleaseMutex(); }
    }

    public int Count => Size();
}
