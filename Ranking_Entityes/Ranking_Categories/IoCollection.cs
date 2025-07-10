using RankingEntityes.IO_Entities.Interfaces;
using System.Collections;

namespace RankingEntityes.Ranking_Entityes.Ranking_Categories
{
    public class IoCollection<T> : IDeserializable, ISerializable, IEnumerable<T>
        where T : IoEntity
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

        public int Lenght { get => ValueArray.Length; }
        /// <summary>
        /// Конструктор, который использует десереалейзер для десериализации коллекции из файла.
        /// </summary>
        public IoCollection()
        {
            ValueArray = new T[0];
        }
        public IoCollection(IEnumerable<T> collectionParameter)
        {
            ValueArray = collectionParameter.ToArray();
        }
        public T this[int index]
        {
            set 
            {
                if(value is null) throw new ArgumentNullException("value");
                else if (index < 0 || index > this.Lenght) throw new IndexOutOfRangeException("index");
                ValueArray[index] = value;
            }
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

        public bool Serialize(ISerializer serializer, string path, FileMode mode)
        {
            serializer.SerializeList(this,path, mode); // Добавить обработку исключений
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
