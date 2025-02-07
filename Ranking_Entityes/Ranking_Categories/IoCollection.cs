using RankingEntityes.IO_Entities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingEntityes.Ranking_Entityes.Ranking_Categories
{
    public class IoCollection<T> : IDeserializable, ISerializable, IEnumerable<T>
        where T : ISerializable, IDeserializable
    {
        private T[] _valueArray = Array.Empty<T>();
        public T[] ValueArray
        {
            get
            {
                return _valueArray;
            }
            set
            {
                _valueArray = value;
            }
        }
        /// <summary>
        /// Конструктор, который использует десереалейзер для десериализации коллекции из файла.
        /// </summary>
        public IoCollection()
        {
            ValueArray = new T[0];
        }
        public T this[int index]
        {
            get
            {
                return ValueArray[index];
            }

        }
        public void Add(T value)
        {
            T[] tempArray = new T[ValueArray.Length + 1];
            for (int i = 0; tempArray.Length > i; i++)
            {
                if (i == tempArray.Length - 1) tempArray[i] = value;
                else if (i < tempArray.Length - 1) tempArray[i] = ValueArray[i];
            }
            ValueArray = tempArray;

        }
        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public IoCollectionEnumerator<T> GetEnumerator()
        {
            return new IoCollectionEnumerator<T>(ValueArray);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new IoCollectionEnumerator<T>(ValueArray);
        }
        #endregion
        
        public bool Deserialize(IDeserializer deserializer, string path)
        {
            var members = deserializer.DeserializeList<T>(path);
            ValueArray = members.ToArray();
            return true;
        }

        public bool Serialize(ISerializer serializer, string path)
        {
            serializer.SerializeList(this,path); // Добавить обработку исключений
            return true;
        }
    }

    public class IoCollectionEnumerator<T> : IEnumerator<T>
    {
        private T[] _valueArray;
        private int position = -1;
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return _valueArray[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception();
                }
            }
        }

        public IoCollectionEnumerator(T[] valueArray)
        {
            _valueArray = valueArray;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _valueArray.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {

        }
    }
}
