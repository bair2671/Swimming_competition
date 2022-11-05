using System;

namespace Model
{
    [Serializable]
    public class Entity<TID>
    {
        private TID ID;

        public TID GetID() { return ID; }

        public void SetID(TID id) { ID = id; }

    }
}
